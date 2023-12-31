using SklepInternetowy.ViewModels;
using Xamarin.Forms;

namespace SklepInternetowy.Views
{
    public partial class ZamowienieDetailsPage : ContentPage
    {
        private readonly ZamowienieDetailsViewModel _viewModel;

        public ZamowienieDetailsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ZamowienieDetailsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}