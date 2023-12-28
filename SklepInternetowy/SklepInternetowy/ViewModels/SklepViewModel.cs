using SklepInternetowy.Services.DataStore;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowy.Views;
using SklepInternetowyServiceReference;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class SklepViewModel : AListViewModel<Towar>
    {

        public SklepViewModel()
           : base("Sklep")
        {
        }

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

        #region Adding to cart

        ADataStore<ElementKoszyka> elementKoszykaDataStore = new ElementKoszykaDataStore();

        public ICommand AddToCartCommand => new Command<Towar>(OnAddToCart);

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

                var existingCartItem = await elementKoszykaDataStore.CheckIfExistsInService(elementKoszyka);

                if (existingCartItem != null)
                {
                    bool updateSuccess = await elementKoszykaDataStore.UpdateItemInService(existingCartItem);

                    if (!updateSuccess)
                    {
                        Console.WriteLine("Failed to update ElementKoszyka.");
                    }
                }
                else
                {
                    ElementKoszyka addedItem = await elementKoszykaDataStore.AddItemToService(elementKoszyka);

                    if (addedItem == null)
                    {
                        Console.WriteLine("Failed to add new ElementKoszyka.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        #endregion
    }
}