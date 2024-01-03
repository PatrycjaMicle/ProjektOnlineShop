using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Services;
using SklepInternetowy.WWW.Services.DataStore;
using SklepInternetowyServiceReference;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly ILogger<SklepController> _logger;
        private readonly TowaryDataStore _dataStore;
        private readonly CartService _cartService;

        public SklepController(ILogger<SklepController> logger, CartService cartService)
        {
            _logger = logger;
            _dataStore = new TowaryDataStore();
            _cartService = cartService;
        }

        public IActionResult Sklep()
        {
            List<Towar> towary = new List<Towar>();
            try
            {
                towary = _dataStore.items.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystapil blad podczas pobierania produktow");                
                return View(new List<Towar>());
            }

            return View(towary);
        }

        public IActionResult Koszyk()
        {
            List<ElementKoszykaForView> elementsInCart = _cartService.ElementyKoszykaForView.ToList();
            return View(elementsInCart);
        }

        public IActionResult Zamowienia()
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