using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SklepInternetowy.Services;
using SklepInternetowy.Services.DataStore;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowy.Views;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class ZamowieniaViewModel : AListViewModel<Zamowienie>
    {
        public ZamowieniaViewModel() : base("Aktualne zamowienia")
        {
            GoToDetailsCommand = new Command(GoToDetails);
        }

        public Command GoToDetailsCommand { get; }

        private async void GoToDetails()
        {
            await Shell.Current.GoToAsync(nameof(SzczegolyZamowieniaPage));
        }

        public override void GoToAddPage()
        {
        }


        public override void OnItemSelected(Zamowienie item)
        {
        }
    }

}
