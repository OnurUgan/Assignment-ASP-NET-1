using Backend.Models.DTO;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductRepository _repository;

        public ProductsController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();

            return Ok(products);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest req)
        {
            if (ModelState.IsValid)
            {
                var product = await _repository.CreateAsync(req);
                if (product != null)
                {
                    return Created("", product);
                }

            }
            return BadRequest();
        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete (Guid id)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        BadRequest();
        //    }

        //    await _repository.DeleteAsync(id);
        //}

        //Fixa detta senare

        [HttpGet("tag/{tag}")]
        public async Task<IActionResult> Get(string tag)
        {
            var product = await _repository.GetByTagAsync(tag);
            if (product != null && product.Any())
            {
                return Ok(product);
            }
            return NotFound();
        }

    }
}
