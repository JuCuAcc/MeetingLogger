namespace MeetingLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProductNames")]
        public IActionResult GetProductNames()
        {
            // Fetch product names from the database
            var productNames = _context.ProductsServiceTbls
                               .Select(p => p.ProductName)
                               .ToList();

            if (productNames == null || productNames.Count == 0)
            {
                return NotFound("No products found");
            }

            return Ok(productNames);
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            // Fetch all products from the database
            List<ProductsServiceTbl> products = await _context.ProductsServiceTbls.ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound("No products found");
            }

            return Ok(products);
        }

        [HttpGet("GetProductByName")]
        public IActionResult GetProductByName(string productName)
        {
            var product = _context.ProductsServiceTbls
                          .FirstOrDefault(p => p.ProductName == productName);

            if (product == null)
            {
                return NotFound();
            }

            var productDetails = new { ProductName = product.ProductName, Unit = product.Unit };
            return Ok(productDetails);
        }

        [HttpGet("GetUnitForProduct")]
        public IActionResult GetUnitForProduct(string productName)
        {
            var product = _context.ProductsServiceTbls
                          .FirstOrDefault(p => p.ProductName == productName);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.Unit);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            // Fetch a specific product by ID
            var product = _context.ProductsServiceTbls
                         .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

    }
}
