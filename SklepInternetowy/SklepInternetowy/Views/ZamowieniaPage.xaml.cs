using SklepInternetowy.ViewModels;
using Xamarin.Forms;

namespace SklepInternetowy.Views
{
    public partial class ZamowieniaPage : ContentPage
    {
        private readonly ZamowieniaViewModel _viewModel;

        public ZamowieniaPage()
        {
            InitializeComponent();
           BindingContext = _viewModel = new ZamowieniaViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
          _viewModel.OnAppearing();
        }
    }
}