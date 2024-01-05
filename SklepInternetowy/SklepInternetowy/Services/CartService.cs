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
        public static event EventHandler OnIdKoduPromocji;
        public static event EventHandler OnSumaChanged;
        public static event EventHandler OnZnizkaChanged;

        private static double? _suma;
        private static int? _idKoduPromocji;
        private static double? _znizka;
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

        public static double? Znizka
        {
            get { return _znizka; }
            set
            {
                if (_znizka != value)
                {
                    _znizka = value;
                    OnZnizkaChanged?.Invoke(null, EventArgs.Empty);
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

        public static int? IdKoduPromocji
        {
            get { return _idKoduPromocji; }
            set
            {
                if (_idKoduPromocji != value)
                {
                    _idKoduPromocji = value;
                    OnIdKoduPromocji?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public async void OnPlaceOrder()
        {
            
            try
            {
                Zamowienie zamowienie = new Zamowienie();
                zamowienie.IdKoduPromocji = IdKoduPromocji; 
                
                //create order
                var addedOrder = await zamowienieDataStore.AddItemToService(zamowienie);
                if (addedOrder == null)
                {
                    Console.WriteLine("Failed to add a new order.");
                    return;
                }

                //create OrderItems
                var items = await elementKoszykaForViewDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    TowarZamowienium towarZamowienia = new TowarZamowienium();

                    IdZamowienia = towarZamowienia.IdZamowienia;
                    var addedOrderItem = await towarZamowieniaDataStore.AddItemAsync(towarZamowienia);
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

                double baseSuma = koszykItems.Sum(x => (x.TowarCena ?? 0) * x.Ilosc.GetValueOrDefault());

                if(_znizka != null && _znizka != 0)
                {
                    double? discountedSuma = ApplyZnizka(baseSuma);
                    Suma = discountedSuma;

                }else
                {
                    Suma = baseSuma;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during sum calculation: {ex.Message}");
            }
        }

        private double? ApplyZnizka(double baseSuma)
        {
            double? znizkaPercentage = Znizka;

            double? discountedAmount = baseSuma * (znizkaPercentage / 100);

            double? discountedSuma = baseSuma - discountedAmount;

            return discountedSuma;
        }

    }
}
