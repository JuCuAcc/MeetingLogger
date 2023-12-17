namespace MeetingLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MeetingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SaveMeetingMinutes([FromBody] MeetingData meetingData)
        {
            try
            {
                DateOnly? convertedMeetingDate = meetingData.meetingMinutesMasterTbl.MeetingDate.HasValue ?
                    new DateOnly(
                        meetingData.meetingMinutesMasterTbl.MeetingDate.Value.Year,
                        meetingData.meetingMinutesMasterTbl.MeetingDate.Value.Month,
                        meetingData.meetingMinutesMasterTbl.MeetingDate.Value.Day
                    ) : (DateOnly?)null;

                TimeOnly? convertedMeetingTime = meetingData.meetingMinutesMasterTbl.MeetingTime.HasValue ?
                    new TimeOnly(
                        meetingData.meetingMinutesMasterTbl.MeetingTime.Value.Hour,
                        meetingData.meetingMinutesMasterTbl.MeetingTime.Value.Minute,
                        meetingData.meetingMinutesMasterTbl.MeetingTime.Value.Second
                    ) : (TimeOnly?)null;


                // Assign converted values back to the object
                meetingData.meetingMinutesMasterTbl.MeetingDate = convertedMeetingDate;
                meetingData.meetingMinutesMasterTbl.MeetingTime = convertedMeetingTime;

                _context.MeetingMinutesMasterTbls.Add(meetingData.meetingMinutesMasterTbl);
                _context.SaveChanges();

                // Associate details with the master record
                meetingData.meetingMinutesDetailsTbl.MeetingId = meetingData.meetingMinutesMasterTbl.Id;
                _context.MeetingMinutesDetailsTbls.Add(meetingData.meetingMinutesDetailsTbl);
                _context.SaveChanges();

                // Execute the stored procedures
                await MeetingMinutesMasterSaveSPAsync(
                    meetingData.meetingMinutesMasterTbl.CustomerType,
                    meetingData.meetingMinutesMasterTbl.CustomerName,
                    convertedMeetingDate,
                    convertedMeetingTime,
                    meetingData.meetingMinutesMasterTbl.MeetingPlace,
                    meetingData.meetingMinutesMasterTbl.AttendsFromClientSide,
                    meetingData.meetingMinutesMasterTbl.AttendsFromHostSide,
                    meetingData.meetingMinutesMasterTbl.MeetingAgenda,
                    meetingData.meetingMinutesMasterTbl.MeetingDiscussion,
                    meetingData.meetingMinutesMasterTbl.MeetingDecision
                );

                await MeetingMinutesDetailsSaveSPAsync(
                    meetingData.meetingMinutesDetailsTbl.MeetingId,
                    meetingData.meetingMinutesDetailsTbl.ProductId,
                    meetingData.meetingMinutesDetailsTbl.Quantity
                );

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<int> MeetingMinutesDetailsSaveSPAsync(int? MeetingId, int? ProductId, int? Quantity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter("@returnValue", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            var sqlParameters = new[]
            {
                new SqlParameter("@MeetingId", MeetingId ?? (object)DBNull.Value),
                new SqlParameter("@ProductId", ProductId ?? (object)DBNull.Value),
                new SqlParameter("@Quantity", Quantity ?? (object)DBNull.Value),
                parameterreturnValue
            };

            var result = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[Meeting_Minutes_Details_Save_SP] @MeetingId, @ProductId, @Quantity", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return result;
        }

        public async Task<int> MeetingMinutesMasterSaveSPAsync(string CustomerType, string CustomerName, DateOnly? MeetingDate, TimeOnly? MeetingTime, string MeetingPlace, string AttendsFromClientSide, string AttendsFromHostSide, string MeetingAgenda, string MeetingDiscussion, string MeetingDecision, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter("@returnValue", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            var sqlParameters = new[]
            {
                new SqlParameter("@CustomerType", CustomerType ?? (object)DBNull.Value),
                new SqlParameter("@CustomerName", CustomerName ?? (object)DBNull.Value),
                new SqlParameter("@MeetingDate", MeetingDate ?? (object)DBNull.Value),
                new SqlParameter("@MeetingTime", MeetingTime ?? (object)DBNull.Value),
                new SqlParameter("@MeetingPlace", MeetingPlace ?? (object)DBNull.Value),
                new SqlParameter("@AttendsFromClientSide", AttendsFromClientSide ?? (object)DBNull.Value),
                new SqlParameter("@AttendsFromHostSide", AttendsFromHostSide ?? (object)DBNull.Value),
                new SqlParameter("@MeetingAgenda", MeetingAgenda ?? (object)DBNull.Value),
                new SqlParameter("@MeetingDiscussion", MeetingDiscussion ?? (object)DBNull.Value),
                new SqlParameter("@MeetingDecision", MeetingDecision ?? (object)DBNull.Value),
                parameterreturnValue
            };

            var result = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[Meeting_Minutes_Master_Save_SP] @CustomerType, @CustomerName, @MeetingDate, @MeetingTime, @MeetingPlace, @AttendsFromClientSide, @AttendsFromHostSide, @MeetingAgenda, @MeetingDiscussion, @MeetingDecision", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return result;
        }

    }
    public class MeetingData
    {
        public MeetingMinutesMasterTbl meetingMinutesMasterTbl { get; set; }
        public MeetingMinutesDetailsTbl meetingMinutesDetailsTbl { get; set; }
    }
}
