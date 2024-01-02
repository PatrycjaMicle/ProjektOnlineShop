using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Services.DataStore;
using SklepInternetowyServiceReference;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace SklepInternetowy.WWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly ILogger<SklepController> _logger;
        private TowaryDataStore _dataStore;

        public SklepController(ILogger<SklepController> logger)
        {
            _logger = logger;
            _dataStore = new TowaryDataStore();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Index()
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