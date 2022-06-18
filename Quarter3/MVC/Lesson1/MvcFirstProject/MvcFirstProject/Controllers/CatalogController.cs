using Microsoft.AspNetCore.Mvc;
using MvcFirstProject.Models;

namespace MvcFirstProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly Catalog _catalog;

        public CatalogController(Catalog catalog)
        {
            _catalog = catalog;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Catalog"] = _catalog;
            return View();
        }

        [HttpGet]
        public IActionResult SkuCreating()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SkuCreating([FromForm] Sku sku)
        {
            _catalog.AddSku(sku);
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
            _catalog.RemoveSku(sku.Id);
            return View();
        }
    }
}
