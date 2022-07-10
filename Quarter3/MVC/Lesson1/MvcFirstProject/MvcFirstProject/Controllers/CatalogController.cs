using Microsoft.AspNetCore.Mvc;
using MvcFirstProject.Models;
using MvcFirstProject.Services;

namespace MvcFirstProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogManager _catalogManager;

        public CatalogController(ICatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Catalog"] = _catalogManager.GetList();
            return View();
        }

        [HttpGet]
        public IActionResult SkuCreating()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SkuCreating([FromForm] Sku sku, CancellationToken cancellationToken)
        {
            await _catalogManager.CreateAsync(sku, cancellationToken);
            return View();
        }

        [HttpGet]
        public IActionResult SkuDeleting()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SkuDeleting([FromForm] Sku sku)
        {
            _catalogManager.Delete(sku.Id);
            return View();
        }
    }
}
