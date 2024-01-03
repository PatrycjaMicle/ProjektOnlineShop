using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Services;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly ILogger<ZamowieniaController> _logger;

        public ZamowieniaController(ILogger<ZamowieniaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Zamowienia()
        {
            try
            {
                // var zamowienia = _dataStore.items.ToList();
                // return View(zamowienia);
                return View();

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