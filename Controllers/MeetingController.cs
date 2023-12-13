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
        public IActionResult SaveMeetingMinutes(MeetingMinutesViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map MeetingMinutesViewModel to MeetingMinutesMasterTbl
                var meetingMinutes = new MeetingMinutesMasterTbl
                {
                    CustomerType = model.CustomerType,
                    CustomerName = model.CustomerName,
                    MeetingDate = model.MeetingDate,
                    MeetingTime = model.MeetingTime,

                    // Map the additional fields
                    MeetingPlace = model.MeetingPlace,
                    AttendsFromClientSide = model.AttendsFromClientSide,
                    AttendsFromHostSide = model.AttendsFromHostSide,
                    MeetingAgenda = model.MeetingAgenda,
                    MeetingDiscussion = model.MeetingDiscussion,
                    MeetingDecision = model.MeetingDecision
                };

                // Add the new meetingMinutes to the context
                _context.MeetingMinutesMasterTbls.Add(meetingMinutes);

                // Save changes to the database
                _context.SaveChanges();

                return Ok("Data Saved Successfuly.");
            }

            // If the model is not valid, return to the same view with errors
            return BadRequest();
        }
    }
}
