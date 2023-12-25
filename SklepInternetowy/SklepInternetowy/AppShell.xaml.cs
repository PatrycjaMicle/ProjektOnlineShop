using SklepInternetowy.ViewModels;
using SklepInternetowy.Views;
using System;
using System.Collections.Generic;
using SklepInternetowy.Views.LoginAndRegister;
using Xamarin.Forms;

namespace SklepInternetowy
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            //NASZE
            Routing.RegisterRoute(nameof(DaneOsobowePage), typeof(DaneOsobowePage));
            Routing.RegisterRoute(nameof(AdresyPage), typeof(AdresyPage));
        }
    }
}
