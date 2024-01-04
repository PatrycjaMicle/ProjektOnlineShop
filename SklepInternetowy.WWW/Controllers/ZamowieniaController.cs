using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Models.Services.DataStore;
using SklepInternetowy.WWWW.Services.DataStore;
using SklepInternetowyServiceReference;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly ILogger<ZamowieniaController> _logger;
        private readonly ZamowienieDataStore _dataStore;
        private readonly TowarZamowieniaDataStore _dataStoreTowarZamowienia;
        private readonly ElementKoszykaDataStore _dataStoreElementKoszyka;

        public ZamowieniaController(ILogger<ZamowieniaController> logger)
        {
            _logger = logger;
            _dataStore = new ZamowienieDataStore();
            _dataStoreTowarZamowienia = new TowarZamowieniaDataStore();
            _dataStoreElementKoszyka = new ElementKoszykaDataStore();
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

            return RedirectToAction("ZamowienieMessage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}