using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Models.Services.DataStore;
using SklepInternetowy.WWW.Services;
using SklepInternetowy.WWW.Services.DataStore;
using SklepInternetowy.WWWW.Services.DataStore;
using SklepInternetowyServiceReference;
using System.Diagnostics;
using SklepInternetowy.WWW.Extensions;

namespace SklepInternetowy.WWW.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly ILogger<ZamowieniaController> _logger;
        private readonly ZamowienieDataStore _dataStore;
        private readonly TowarZamowieniaDataStore _dataStoreTowarZamowienia;
        private readonly ElementKoszykaDataStore _dataStoreElementKoszyka;
        private readonly KodPromocjiDataStore _kodPromocjiDataStore;
        
        public ZamowieniaController(TowarZamowieniaDataStore dataStoreTowarZamowienia, ElementKoszykaDataStore dataStoreElementKoszyka, KodPromocjiDataStore kodPromocjiDataStore, ZamowienieDataStore dataStore, ILogger<ZamowieniaController> logger)
        {
            _dataStoreTowarZamowienia = dataStoreTowarZamowienia;
            _dataStoreElementKoszyka = dataStoreElementKoszyka;
            _kodPromocjiDataStore = kodPromocjiDataStore;
            _dataStore = dataStore;
            _logger = logger;
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
        
        public async Task<ActionResult> ZamowienieMessage()
        {
            return View();
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

        public async Task<ActionResult> ZlozZamowienie()
        {

            try
            {
                Zamowienie zamowienie = new Zamowienie();
                zamowienie.IdKoduPromocji = CartService.IdKoduPromocji;
                //create order
                var addedOrder = await _dataStore.AddItemToService(zamowienie);
                if (addedOrder == null)
                {
                    Console.WriteLine("Failed to add a new order.");
                    RedirectToAction("Zamowienia"); ;
                }

                //create OrderItems
                var items = await _dataStoreElementKoszyka.GetItemsAsync(true);
                foreach (var item in items)
                {
                    TowarZamowienium towarZamowienia = new TowarZamowienium();
                    var addedOrderItem = await _dataStoreTowarZamowienia.AddItemAsync(towarZamowienia);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            CartService.Znizka = null;
            return RedirectToAction("ZamowienieMessage");
        }

        public async Task<ActionResult> DodajKodRabatowy(string id)
        {
            var kodPromocyjnyResponse = await _kodPromocjiDataStore.GetZnizka(id);

            CartService.Znizka = kodPromocyjnyResponse.Znizka;
            CartService.IdKoduPromocji = kodPromocyjnyResponse.IdKoduPromocji;
            this.SetNotification("Discount applied!");
            return RedirectToAction("Koszyk", "Koszyk");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}