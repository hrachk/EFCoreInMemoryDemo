using EFCoreInMemoryDemo.DatabaseContext;
using EFCoreInMemoryDemo.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInMemoryDemo.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDatabaseContext databaseContext;

        public ProductController(MyDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet]
        [Route("GetProductList")]
        public async Task<IActionResult> GetProductList()
        {
            return Ok(await databaseContext.Products.ToListAsync());
        }

        [HttpPost]
        [Route("PostProduct")]
        public async Task<IActionResult> PostProduct(ProductDataModel newProduct)
        {
            ProductDataModel product = new ProductDataModel
            {
                Id = Guid.NewGuid(),
                Price = newProduct.Price,
                ProductName = newProduct.ProductName,
                Category = newProduct.Category
            };
            await databaseContext.Products.AddAsync(product);
            await databaseContext.SaveChangesAsync();

            return Ok(product);
        }
    }
}
