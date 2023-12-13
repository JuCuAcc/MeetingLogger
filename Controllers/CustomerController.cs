namespace MeetingLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetCustomerNames")]
        public IActionResult GetCustomerNames(string customerType)
        {
            if (customerType == "Corporate")
            {
                var corporateCustomerNames = _context.MeetingMinutesMasterTbls
                                            .Where(c => c.CustomerType == "Corporate")
                                            .Select(c => c.CustomerName).ToList();
                return Ok(corporateCustomerNames);
            }
            else if (customerType == "Individual")
            {
                var individualCustomerNames = _context.MeetingMinutesMasterTbls
                                             .Where(c => c.CustomerType == "Individual")
                                             .Select(c => c.CustomerName).ToList();
                return Ok(individualCustomerNames);
            }

            return BadRequest("Invalid customer type");
        }

    }
}
