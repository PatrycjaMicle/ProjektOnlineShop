using SklepInternetowy.Services.DataStore;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels.Deprecated
{
    public class NewItemViewModel : BaseViewModel
    {
        private readonly TowaryDataStore _towaryDataStore;
        private string description;
        private string text;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            _towaryDataStore = new TowaryDataStore();
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(text)
                   && !string.IsNullOrWhiteSpace(description);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var newItem = new Towar
            {
                Nazwa = Text,
                Opis = description
            };

            await _towaryDataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}