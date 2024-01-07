using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Services.DataStore;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly ILogger<SklepController> _logger;
        private readonly TowaryDataStore _dataStore;

        public SklepController(ILogger<SklepController> logger,TowaryDataStore dataStore)
        {
            _logger = logger;
            _dataStore = dataStore;
        }

        public IActionResult Sklep()
        {
            try
            {
                var towary = _dataStore.items.ToList();
                return View(towary);
            }
            catch (Exception)
            {
                Console.WriteLine("Wystapil blad podczas pobierania produktow");
                return View();
            }
        }

        public async Task<ActionResult> OtworzSzczegoly(int id)
        {
            return RedirectToAction("ProduktDetail", new { id = id });
        }

        public async Task<ActionResult> ProduktDetail(int id)
        {
            try
            {
                var towar = _dataStore.Find(id);
                return View(towar);
            }
            catch (Exception)
            {
                Console.WriteLine("Wystapil blad podczas pobierania produktow");
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}