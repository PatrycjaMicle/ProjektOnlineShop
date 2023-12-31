using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SklepInternetowy.Models;
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
        public Command<Zamowienie> GoToDetailsCommand => new Command<Zamowienie>(GoToDetails);

        public ZamowieniaViewModel() : base("Aktualne zamowienia")
        {
        }

        public async void GoToDetails(Zamowienie item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync(
               $"{nameof(ZamowienieDetailsPage)}?{nameof(ZamowienieDetailsViewModel.IdZamowienia)}={item.IdZamowienia}");
        
        }

        public override void GoToAddPage()
        {
        }

        public override void OnItemSelected(Zamowienie item)
        {
        }
    }
}
