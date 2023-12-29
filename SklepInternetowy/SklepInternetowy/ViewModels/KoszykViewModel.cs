using SklepInternetowy.Models;
using SklepInternetowy.Services.DataStore;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowy.Views;
using SklepInternetowyServiceReference;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class KoszykViewModel : AListViewModel<ElementKoszykaForView>
    {
        #region base
        public KoszykViewModel()
           : base("Koszyk")
        {
        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }


        public override void OnItemSelected(ElementKoszykaForView item)
        {
        }

        #endregion

        #region Override

        ADataStore<Towar> towaryDataStore = new TowaryDataStore();

       
        #endregion

        #region Place order

        //ADataStore<ElementKoszyka> elementKoszykaDataStore = new ElementKoszykaDataStore();

        public ICommand PlaceOrderCommand => new Command<ElementKoszyka>(OnPlaceOrder);

        private async void OnPlaceOrder(ElementKoszyka item)
        {

        }

        #endregion
    }
}