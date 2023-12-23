using SklepInternetowy.Services;
using SklepInternetowy.ViewModels.Abstract;
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

    }
}