using SklepInternetowy.Services.DataStore;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels.Abstract
{
    public abstract class ANewItemViewModel<T> : BaseViewModel
    {
        public ANewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public abstract bool ValidateSave();

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public abstract T SetItem();

        private async void OnSave()
        {
            await DataStore.AddItemAsync(SetItem());
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}