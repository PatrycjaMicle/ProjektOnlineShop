using SklepInternetowy.Views;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class KontoViewModel : BaseViewModel
    {
        public KontoViewModel()
        {
            GoToDaneOsoboweCommand = new Command(GoToDaneOsobowe);
            GoToAdresyCommand = new Command(GoToAdresy);
        }

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