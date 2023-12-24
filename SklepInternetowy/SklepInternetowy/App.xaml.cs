using SklepInternetowy.Services;
using SklepInternetowy.Views;
using System;
using SklepInternetowy.Views.LoginAndRegister;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SklepInternetowy
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            DependencyService.Register<UzytkownikDataStore>();
            DependencyService.Register<LoginAndRegisterService>();

            if (!IsUserLoggedIn)
            {
                MainPage = new LoginPage();
            }
            else
            {
                MainPage = new AppShell();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
