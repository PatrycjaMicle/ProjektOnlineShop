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
        private readonly TowarZamowieniaDataStore _dataStoreTowarZamowienia;

        public ZamowieniaController(ILogger<ZamowieniaController> logger)
        {
            _logger = logger;
            _dataStore = new ZamowienieDataStore();
            _dataStoreTowarZamowienia = new TowarZamowieniaDataStore();
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

        public async Task<ActionResult> OtworzSzczegoly(int id)
        {
            return RedirectToAction("ZamowienieDetail", new { id = id });
        }

        public async Task<ActionResult> ZamowienieDetail(int id)
        {
            try
            {
                var orderItems = _dataStoreTowarZamowienia.items
                    .Where(a => a.IdZamowienia == id)
                    .ToList();

                return View(orderItems);
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