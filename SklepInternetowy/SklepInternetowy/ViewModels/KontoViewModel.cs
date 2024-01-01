using SklepInternetowy.Services;
using SklepInternetowy.Services.DataStore;
using SklepInternetowy.Views;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class KontoViewModel : BaseViewModel
    {
        private readonly UserService _userService;
        private readonly UzytkownikDataStore _uzytkownikDataStore;
        public KontoViewModel()
        {
            _userService = DependencyService.Get<UserService>();
            _uzytkownikDataStore = new UzytkownikDataStore();
            
            GoToDaneOsoboweCommand = new Command(GoToDaneOsobowe);
            GoToAdresyCommand = new Command(GoToAdresy);
        }

        public string Header => $"Czesc {_uzytkownikDataStore.Find(_userService.UserId).Imie}";

        public Command GoToDaneOsoboweCommand { get; }
        public Command GoToAdresyCommand { get; }

        private async void GoToDaneOsobowe()
        {
            await Shell.Current.GoToAsync(nameof(DaneOsobowePage));
        }

        private async void GoToAdresy()
        {
            await Shell.Current.GoToAsync(nameof(AdresyPage));
        }
    }
}