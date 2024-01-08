using AutoMapper;
using GrantAdvance.Domain.Models;
using GrantAdvance.Domain.ViewModel;
using GrantAdvance.Infras.Services;
using GrantAdvance.Infras.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GrantAdvance.API.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create the product
        /// </summary>
        /// <param name="productRequest"></param>
        /// <returns>Product created</returns>
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductRequestViewModel productRequest)
        {
            var product = new Product
            {
                Price = productRequest.Price,
                Name = productRequest.Name
            };

            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync(product);
                if (!response.Success)
                {
                    return BadRequest(response.Message);
                }

                return Ok(response.Product);
            }

            return BadRequest();
        }

        /// <summary>
        /// Get all the products
        /// </summary>
        /// <returns>All the products</returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllProductAsync()
        {
             return Ok(await _productService.GetAll());
        }

        /// <summary>
        /// Get the product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get the product</returns>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetProductByIdAsync(Guid id)
        {
            return Ok(await _productService.FindByIdAsync(id));
        }
    }
}
