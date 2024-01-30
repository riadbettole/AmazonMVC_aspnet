using AmazonMVC.Models;
using AmazonMVC.Repositories;
using AmazonMVC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmazonMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string sterm="",int genreId=0)
        {
            IEnumerable<Product> products = await _homeRepository.GetProducts(sterm, genreId);
            IEnumerable<Genre> genres = await _homeRepository.Genres();
            ProductDisplayModel productModel = new ProductDisplayModel
            {
              Products = products,
              Genres=genres,
              STerm=sterm,
              GenreId=genreId
            };
            return View(productModel);
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