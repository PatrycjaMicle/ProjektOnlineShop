using SklepInternetowy.ViewModels;
using Xamarin.Forms;

namespace SklepInternetowy.Views
{
    public partial class SzczegolyZamowieniaPage : ContentPage
    {
        private readonly SzczegolyZamowieniaViewModel _viewModel;

        public SzczegolyZamowieniaPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SzczegolyZamowieniaViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}