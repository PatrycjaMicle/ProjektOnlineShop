using SklepInternetowy.Models;
using SklepInternetowy.Services.DataStore;
using SklepInternetowyServiceReference;
using System;
using System.Linq;

namespace SklepInternetowy.Services
{
    public class CartService
    {
        public static event EventHandler OnIdZamowieniaChanged;
        public static event EventHandler OnSumaChanged;

        private static double? _suma;
        private static int? _idZamowienia;
        private ADataStore<Zamowienie> zamowienieDataStore = new ZamowienieDataStore();
        private ADataStore<TowarZamowienium> towarZamowieniaDataStore = new TowarZamowieniaDataStore();
        private ADataStore<ElementKoszykaForView> elementKoszykaForViewDataStore = new ElementKoszykaForViewDataStore();

        public static double? Suma
        {
            get { return _suma; }
            set
            {
                if (_suma != value)
                {
                    _suma = value;
                    OnSumaChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public static int? IdZamowienia
        {
            get { return _idZamowienia; }
            set
            {
                if (_idZamowienia != value)
                {
                    _idZamowienia = value;
                    OnIdZamowieniaChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public async void OnPlaceOrder()
        {
            try
            {
                Zamowienie zamowienie = new Zamowienie();
                zamowienie.Suma = Suma;

                var addedOrder = await zamowienieDataStore.AddItemToService(zamowienie);
                if (addedOrder == null)
                {
                    Console.WriteLine("Failed to add a new order.");
                    return;
                }

                var items = await elementKoszykaForViewDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    TowarZamowienium towarZamowienia = new TowarZamowienium
                    {
                        NazwaTowaru = item.TowarNazwa,
                        IdZamowienia = addedOrder.IdZamowienia,
                        Ilosc = item.Ilosc,
                        Aktywny = true,
                        Cena = item.TowarCena
                    };
                    IdZamowienia = towarZamowienia.IdZamowienia;
                    var addedOrderItem = await towarZamowieniaDataStore.AddItemAsync(towarZamowienia);
                    await elementKoszykaForViewDataStore.DeleteItemFromService(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async void InitializeSumaAsync()
        {
            try
            {
                var koszykItems = await elementKoszykaForViewDataStore.GetItemsAsync(true);
                Suma = koszykItems.Sum(x => (x.TowarCena ?? 0) * x.Ilosc.GetValueOrDefault());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during sum calculation: {ex.Message}");
            }
        }
    }
}
