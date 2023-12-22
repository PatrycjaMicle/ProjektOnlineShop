using SklepInternetowy.Models;
using SklepInternetowy.Views;
using System;
using System.Collections.Generic;
using System.Text;
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

        async void GoToDaneOsobowe()
        {
            await Shell.Current.GoToAsync(nameof(DaneOsobowePage));
        }

        async void GoToAdresy()
        {
            await Shell.Current.GoToAsync(nameof(AdresyPage));
        }
    }
}