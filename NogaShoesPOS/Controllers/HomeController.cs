using Microsoft.AspNetCore.Mvc;
using NogaShoesPOS.Models;
using System.Diagnostics;

namespace NogaShoesPOS.Controllers
    {
    public class HomeController : Controller
        {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
            {
            _logger = logger;
            }

        public IActionResult Index()
            {
            return View();
            }

        public IActionResult Privacy()
            {
            return View();
            }
        
        public IActionResult Cash()
            {
            return View();
            }

        public IActionResult Product()
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
