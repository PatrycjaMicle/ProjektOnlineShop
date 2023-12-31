using System;
using System.Diagnostics;
using SklepInternetowy.Services;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    [QueryProperty(nameof(IdZamowienia), nameof(IdZamowienia))]
    public class ZamowienieDetailsViewModel : AListViewModel<TowarZamowienium>
    {
        private int idZamowienia { get; set; }

        public ZamowienieDetailsViewModel() : base("wroc do listy zamowien")
        {
        }

        public override void GoToAddPage()
        {
        }

        public override void OnItemSelected(TowarZamowienium item)
        {
        }

        public int IdZamowienia
        {
            get => idZamowienia;
            set
            {
                idZamowienia = value;
                LoadItemId(value);
            }
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                CartService.IdZamowienia = idZamowienia;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
