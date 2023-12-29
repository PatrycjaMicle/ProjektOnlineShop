using SklepInternetowy.Views;
using System;
using SklepInternetowy.Views.LoginAndRegister;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SklepInternetowy.Services.DataStore;
using SklepInternetowy.Services;

namespace SklepInternetowy
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<UzytkownikDataStore>();
            DependencyService.Register<TowaryDataStore>();
            DependencyService.Register<ElementKoszykaDataStore>();
            DependencyService.Register<ElementKoszykaForViewDataStore>();
            DependencyService.Register<LoginAndRegisterService>();

            DependencyService.RegisterSingleton(new UserService());

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
