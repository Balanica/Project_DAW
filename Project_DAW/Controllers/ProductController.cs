using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_DAW.Helpers.Attributes;
using Project_DAW.Models;
using Project_DAW.Models.DTOs;
using Project_DAW.Models.Roles;
using Project_DAW.Services.ProductService;

namespace Project_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPut("update-product")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> UpdateProduct(ProductDTO _product, Guid productId)
        {
            var product = await this._productService.Update(productId, _product);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("getAll-product")]
        [Authorization(Role.Admin, Role.Customer)]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await this._productService.GetAll());
        }

        [HttpPost("add-product")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> AddProduct(ProductDTO product)
        {
            await this._productService.Create(product);
            return Ok(product);
        }

        [HttpDelete("delete-product")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await this._productService.Delete(id);
            return Ok("Product has been deleted!");
        }

        [HttpGet("get-by-brand")]
        public async Task<IActionResult> GetProductByBrand(string brand)
        {
            var products = this._productService.GetByBrand(brand);
            return Ok(products);
        }
    }
}
