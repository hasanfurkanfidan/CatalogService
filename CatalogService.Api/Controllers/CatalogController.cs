using CatologService.Core.DataAccess.Abstract;
using CatologService.Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CatalogService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(IProductRepository productRepository,ILogger<CatalogController>logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var list = await _productRepository.GetProductsAsync();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetProductById(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                _logger.LogError($"Product with id:{id} not found!");
                return NotFound();
            }
            
            var data = await _productRepository.GetProductByIdAsync(id);
            return Ok(data);
        }
        [HttpGet("getbycategory/{category}")]
        public async Task<IActionResult>GetProductsWithCategory(string category)
        {
            if (String.IsNullOrEmpty(category))
            {
                _logger.LogError($"Product with category:{category} not found!");
                return NotFound();
            }
            var data = await _productRepository.GetProductsByCategoryAsync(category);
            return Ok(data);
        }
        [HttpGet("getbyname/{name}")]
        [ProducesResponseType(typeof(List<Product>),(int)HttpStatusCode.OK)]

        public async Task<IActionResult>GetProductWithName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                _logger.LogError($"Product with name:{name} not found!");

                return NotFound();
            }
            var data = await _productRepository.GetProductsByNameAsync(name);
            return Ok(data);

        }
        [HttpPost]
        public async Task<IActionResult>Add(Product product)
        {
            if (product==null)
            {
                return BadRequest();
            }
            await _productRepository.CreateAsync(product);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult>Put(Product product)
        {
            if (product==null)
            {
                return BadRequest();
            }
            var result = await _productRepository.UpdateAsync(product);
            if (result)
            {
                return NoContent();
            }
            return BadRequest("Güncelleme işlemi başarısız");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var data = await _productRepository.GetProductByIdAsync(id);
            if (data == null)
            {
                return BadRequest();
            }
           var result =  await _productRepository.DeleteAsync(data);
            if (!result)
            {
                return BadRequest("İşlem başarısız");
            }
            return NoContent();

        }

    }
}
