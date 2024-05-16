using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
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

        [HttpPost("search-product")]
        public ActionResult<List<Product>> SearchProducts(String name)
        {
            List<Product> rs = new List<Product>();
            var list = _context.Products.ToList();
            foreach (var product in list)
            {
                if(product.Name.ToLower().Contains(name.ToLower()))
                {
                    rs.Add(product);
                }
            }
            return Ok(rs);
        }
    }
}
