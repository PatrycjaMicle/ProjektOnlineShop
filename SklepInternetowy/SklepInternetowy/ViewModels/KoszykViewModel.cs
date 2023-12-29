using System;
using System.ComponentModel;
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
        #region decl

        private ADataStore<Towar> towaryDataStore = new TowaryDataStore();
        private ADataStore<ElementKoszykaForView> elementKoszykaForViewDataStore = new ElementKoszykaForViewDataStore();

        private double? suma;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region base

        public KoszykViewModel()
            : base("Koszyk")
        {
            InitializeSumaAsync();
            Suma = CartService.suma;
        }
        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }


        public override void OnItemSelected(ElementKoszykaForView item)
        {
        }

        #endregion

        #region Place order

        public ICommand PlaceOrderCommand => new Command<ElementKoszyka>(OnPlaceOrder);

        private async void OnPlaceOrder(ElementKoszyka item)
        {
        }

        private async void InitializeSumaAsync()
        {
            try
            {
                var koszykItems = await elementKoszykaForViewDataStore.GetItemsAsync(true);
                CartService.suma = koszykItems.Sum(x => x.TowarCena ?? 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during sum calculation: {ex.Message}");
            }
        }

        #endregion
    }
}