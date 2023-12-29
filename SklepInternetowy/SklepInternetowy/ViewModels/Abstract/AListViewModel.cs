using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SklepInternetowy.Services.DataStore;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels.Abstract
{
    public abstract class AListViewModel<T> : BaseViewModel
    {
        private T _selectedItem;

        public AListViewModel(string title)
        {
            Title = title;
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<T>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
        }

        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        public ObservableCollection<T> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<T> ItemTapped { get; }

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items) Items.Add(item);
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
            SelectedItem = default;
        }

        public abstract void GoToAddPage();

        public async void OnAddItem(object obj)
        {
            GoToAddPage();
        }

        public abstract void OnItemSelected(T item);
    }
}