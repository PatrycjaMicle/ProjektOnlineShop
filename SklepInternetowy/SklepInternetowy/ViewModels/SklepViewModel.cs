using System;
using System.Windows.Input;
using SklepInternetowy.Services.DataStore;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowy.Views;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class SklepViewModel : AListViewModel<Towar>
    {
        private readonly ElementKoszykaDataStore _elementKoszykaDataStore;
        public SklepViewModel() : base("Sklep")
        {
            _elementKoszykaDataStore = new ElementKoszykaDataStore();
        }

        public ICommand AddToCartCommand => new Command<Towar>(OnAddToCart);
        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        public override async void OnItemSelected(Towar item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.IdTowaru}");
        }
        
        private async void OnAddToCart(Towar item)
        {
            try
            {
                ElementKoszyka elementKoszyka = new ElementKoszyka
                {
                    IdTowaru = item.IdTowaru,
                    DataUtworzenia = DateTime.Now,
                    Ilosc = 1
                };

                var addedItem = await _elementKoszykaDataStore.AddItemToService(elementKoszyka);

                if (addedItem == null)
                {
                    Console.WriteLine("Failed to add new ElementKoszyka.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}