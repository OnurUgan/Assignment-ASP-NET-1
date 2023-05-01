using Frontend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _productService.GetAll());
        }

        public async Task<IActionResult> Detail(string id)
        {
            return View(await _productService.GetById(id));
        }
    }
}
