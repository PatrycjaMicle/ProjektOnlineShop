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
        private double? suma;
        private ADataStore<Towar> towaryDataStore = new TowaryDataStore();
        private CartService cartService = new CartService();

        public ICommand PlaceOrderCommand => new Command(PlaceOrder);

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

        public KoszykViewModel()
            : base("Koszyk")
        {
            cartService.InitializeSumaAsync();
            Suma = CartService.Suma;
            CartService.OnSumaChanged += (sender, args) =>
            {
                Suma = CartService.Suma;
            };
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
        }

        private async void GoToSzczegolyZamowienia()
        {
            await Shell.Current.GoToAsync(nameof(SzczegolyZamowieniaPage));
        }
    }
}
