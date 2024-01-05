using System;
using System.Linq;
using System.Windows.Input;
using SklepInternetowy.Models;
using SklepInternetowy.Services;
using SklepInternetowy.Services.DataStore;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowy.Views;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class KoszykViewModel : AListViewModel<ElementKoszykaForView>
    {
        public ICommand PlaceOrderCommand => new Command(PlaceOrder);
        public ICommand AddPromotionCodeCommand => new Command<string>(AddPromotionCode);

        private double? suma;
        private string promotionCode;
        private double? znizka;
        private ADataStore<Towar> towaryDataStore = new TowaryDataStore();
        private KodPromocjiDataStore kodPromocjiDataStore = new KodPromocjiDataStore();
        private CartService cartService = new CartService();

        public KoszykViewModel()
         : base("Koszyk")
        {
            cartService.InitializeSumaAsync();
            Znizka = 0;
            Suma = CartService.Suma;
            CartService.OnSumaChanged += (sender, args) =>
            {
                Suma = CartService.Suma;
            };
        }

        public string PromotionCode
        {
            get { return promotionCode; }
            set
            {
                if (promotionCode != value)
                {
                    promotionCode = value;
                    OnPropertyChanged(nameof(PromotionCode));
                }
            }
        }

        public double? Suma
        {
            get { return suma; }
            set
            {
                if (suma != value)
                {
                    suma = value;
                    OnPropertyChanged(nameof(Suma));
                }
            }
        }

        public double? Znizka
        {
            get { return znizka; }
            set
            {
                if (znizka != value)
                {
                    znizka = value;
                    OnPropertyChanged(nameof(Znizka));
                }
            }
        }

        public override async void GoToAddPage()
        {
        }

        public override void OnItemSelected(ElementKoszykaForView item)
        {
        }

        private void PlaceOrder()
        {
            cartService.OnPlaceOrder();
            base.Items.Clear();
            GoToSzczegolyZamowienia();
            Znizka = 0;
        }

        private async void AddPromotionCode(string kodPromocyjny)
        {   
            var kodPromocyjnyResponse = await kodPromocjiDataStore.GetZnizka(kodPromocyjny);
            Znizka = kodPromocyjnyResponse.Znizka;

            CartService.Znizka = Znizka;
            CartService.IdKoduPromocji= kodPromocyjnyResponse.IdKoduPromocji;
            cartService.InitializeSumaAsync();
        }

        private async void GoToSzczegolyZamowienia()
        {
            await Shell.Current.GoToAsync(nameof(SzczegolyZamowieniaPage));
        }
    }
}
