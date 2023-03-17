using Domain.DTO;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var products = await _productService.GetProduct(id);

                if (products == null)
                    return NotFound("No products found");
                return Ok(products);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Product not found")
                    return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productService.GetProducts();

                if (!products.Any())
                    return NotFound("No products found");
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO model)
        {
            try
            {
                var product = await _productService.AddProduct(model);
                if (product == null)
                    return BadRequest("Error while adding product");
                return Ok(product);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest("Some field is empty - " + ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductDTO model)
        {
            try
            {
                var product = await _productService.UpdateProduct(model);
                if (product == null)
                    return BadRequest("Error while updating product");
                return Ok(product);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest("Some field is empty - " + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Product not found")
                    return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return Ok("Product deleted!");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Product not found")
                    return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
