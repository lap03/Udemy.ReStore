using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        } 

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")] // api/products/3
        public ActionResult<Product> GetProduct(int id)
        {
            return _context.Products.Find(id);
        }
    }
}
