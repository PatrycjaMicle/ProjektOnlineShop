using SklepInternetowy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SklepInternetowy.Views.LoginAndRegister
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}