using GestionLibreria.Application.DTOs;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionLibreria.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public ActionResult<Product> Create([FromBody] CreateProductRequest request)
        {
            try
            {
                Product product = _productService.AddProduct(request);
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        public ActionResult<IReadOnlyList<Product>> GetAll()
        {
            var products = _productService.GetAllProducts();
            if (!products.Any())
            {
                return NotFound("No products found.");
            }
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(Guid id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);
        }

        [HttpPatch("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
        {
            if (!_productService.UpdateProductDetails(id, request))
            {
                return NotFound("Product not found.");
            }
            return NoContent();
        }

        [HttpPatch("{id}/availability")]
        public ActionResult SetAvailability([FromRoute] Guid id, [FromBody] SetAvailabilityRequest request)
        {
            if (!_productService.SetProductAvailability(id, request))
            {
                return NotFound("Product not found.");
            }
            return NoContent();
        }
    }
}
