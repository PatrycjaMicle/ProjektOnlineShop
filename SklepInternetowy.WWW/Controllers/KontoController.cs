using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Controllers
{
    public class KontoController : Controller
    {
        private readonly ILogger<KontoController> _logger;

        public KontoController(ILogger<KontoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Konto()
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