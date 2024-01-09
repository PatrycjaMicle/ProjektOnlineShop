using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Services.DataStore;
using System.Diagnostics;
using SklepInternetowy.WWW.Models.ViewModels;
using SklepInternetowyServiceReference;

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

        public async Task<IActionResult> OtworzSzczegoly(int id)
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

        public IActionResult DodajProdukt()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DodajProdukt(DodajProduktViewModel produktViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(produktViewModel);
            }
            var towar = new Towar()
            {
                Nazwa = produktViewModel.Nazwa,
                Kod = produktViewModel.Kod,
                IdKategorii = produktViewModel.IdKategorii,
                Cena = produktViewModel.Cena,
                NaStanie = produktViewModel.NaStanie,
                ZdjecieUrl = produktViewModel.ZdjecieUrl,
                Opis = produktViewModel.Opis
            };
            
            if (towar != null)
            {
                await _dataStore.AddItemToService(towar);
            }
            return RedirectToAction(nameof(Sklep));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}