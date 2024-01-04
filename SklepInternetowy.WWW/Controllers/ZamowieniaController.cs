using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWWW.Services.DataStore;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly ILogger<ZamowieniaController> _logger;
        private readonly ZamowienieDataStore _dataStore;

        public ZamowieniaController(ILogger<ZamowieniaController> logger)
        {
            _logger = logger;
            _dataStore = new ZamowienieDataStore();
        }

        public IActionResult Zamowienia()
        {
            try
            {
                var zamowienia = _dataStore.items.ToList();
                return View(zamowienia);
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