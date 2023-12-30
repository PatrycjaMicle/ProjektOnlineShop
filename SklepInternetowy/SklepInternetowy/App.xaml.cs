using SklepInternetowy.Services;
using SklepInternetowy.Services.DataStore;
using SklepInternetowy.Views.LoginAndRegister;
using Xamarin.Forms;

namespace SklepInternetowy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<UzytkownikDataStore>();
            DependencyService.Register<TowaryDataStore>();
            DependencyService.Register<ElementKoszykaDataStore>();
            DependencyService.Register<ElementKoszykaForViewDataStore>();
            DependencyService.Register<TowarZamowieniaDataStore>();
            DependencyService.Register<ZamowienieDataStore>();
            DependencyService.Register<LoginAndRegisterService>();

            DependencyService.RegisterSingleton(new UserService());

            if (!IsUserLoggedIn)
                MainPage = new LoginPage();
            else
                MainPage = new AppShell();
        }

        public static bool IsUserLoggedIn { get; set; }

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