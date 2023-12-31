using SklepInternetowy.Views;
using Xamarin.Forms;

namespace SklepInternetowy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TowarDetailPage), typeof(TowarDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            //NASZE
            Routing.RegisterRoute(nameof(DaneOsobowePage), typeof(DaneOsobowePage));
            Routing.RegisterRoute(nameof(AdresyPage), typeof(AdresyPage));
            Routing.RegisterRoute(nameof(SzczegolyZamowieniaPage), typeof(SzczegolyZamowieniaPage));
            Routing.RegisterRoute(nameof(ZamowienieDetailsPage), typeof(ZamowienieDetailsPage));
        }
    }
}