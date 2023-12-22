using SklepInternetowy.Views;
using SklepInternetowyServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class SklepViewModel : BaseViewModel
    {
        #region Declarations
        private Towar _selectedItem;

        public ObservableCollection<Towar> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Towar> ItemTapped { get; }

        #endregion

        #region Constructor
        public SklepViewModel()
        {
            Title = "Sklep";
            Items = new ObservableCollection<Towar>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Towar>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }
        #endregion

        #region Commands
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = new List<Towar>
                {
                    new Towar
                    {
                        IdTowaru = 1,
                        Nazwa = "Opony",
                        Cena = 800,
                        Opis = "Wytrzymale opony na zime"
                    },
                    new Towar
                    {
                        IdTowaru = 2,
                        Nazwa = "Hamulce",
                        Cena = 570,
                        Opis = "Mocne Hamulce"
                    },
                    new Towar
                    {
                        IdTowaru = 3,
                        Nazwa = "Sprzeglo",
                        Cena = 1270,
                        Opis = "Sprzeglo dla Audi A6"
                    }
                };
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Towar item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.IdTowaru}");
        }

        #endregion

        #region Properties

        public Towar SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        #endregion
    }
}