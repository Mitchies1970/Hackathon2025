using Hackathon2025.BuisinessLogic;
using Hackathon2025.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hackathon2025.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductSearch _productSearch;

        public HomeController(ILogger<HomeController> logger, Hackathon2025.BuisinessLogic.ProductSearch productSearch)
        {
            _logger = logger;
            _productSearch = productSearch;
        }

        public IActionResult Index()
        {
            return View(new SearchModel("I would like to find products that I can play sport with"));
        }

        [HttpPost]
        public IActionResult Search(SearchModel searchModel)
        {
            if (searchModel == null || string.IsNullOrEmpty(searchModel.SearchText.Trim()))
            {
                return View("Index", new SearchModel("", true, "Enter a search in English"));
            }

            List<DTOs.Product> products = _productSearch.FindProducts(searchModel.SearchText);

            searchModel.ProductsFound = products;

            return View("Index", searchModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
