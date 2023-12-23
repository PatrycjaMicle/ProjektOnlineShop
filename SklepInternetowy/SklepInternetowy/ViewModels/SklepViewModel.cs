using SklepInternetowy.Services;
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

        public TowaryDataStore dataStore = new TowaryDataStore();
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
                var items = await dataStore.GetItemsAsync(true);
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

        //TODO
        //Wyswietlanie szczegolow towaru - czy potrzebne? mozna zastapic od razu komenda dodawania do koszyka onClick
        async void OnItemSelected(Towar item)
        {
            if (item == null)
                return;
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