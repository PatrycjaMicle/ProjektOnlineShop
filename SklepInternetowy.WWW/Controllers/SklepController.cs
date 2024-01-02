using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly ILogger<SklepController> _logger;

        public SklepController(ILogger<SklepController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            var model = new List<Towar>()
            {
                new Towar()
                {
                    nazwa= "opona",
                    cena=350
                },
                 new Towar()
                {
                    nazwa= "kierownica",
                    cena=800
                }
            };


            return View(model);
        }

        public IActionResult Koszyk()
        {
            return View();
        }

        public IActionResult Zamowienia()
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