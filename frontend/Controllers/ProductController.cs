using frontend.Models.ProductModels;
using frontend.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace frontend.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;

        public ProductController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productApiClient.GetProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productApiClient.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create(CreateProductDto product)
        {
            if (ModelState.IsValid)
            {   
                var success = await _productApiClient.CreateProductAsync(product);

                if (success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Erro ao criar o produto.");
                    return View(product);
                }
            }

            return View(product);
        }
        

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productApiClient.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var success = await _productApiClient.UpdateProductAsync(id, product);
                
                if (success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Erro ao atualizar o produto.");
                    return View(product);
                }
            }

            return View(product); // Retorna o modelo com erros caso não seja válido
        }


        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _productApiClient.DeleteProductAsync(id);
            
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            
            ModelState.AddModelError("", "Failed to delete the product.");
            return View("Index", await _productApiClient.GetProductsAsync());
        }
    }
}