namespace MeetingLogger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}