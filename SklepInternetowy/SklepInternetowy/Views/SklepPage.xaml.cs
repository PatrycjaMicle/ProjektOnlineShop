using SklepInternetowy.ViewModels;
using Xamarin.Forms;

namespace SklepInternetowy.Views
{
    public partial class SklepPage : ContentPage
    {
        private readonly SklepViewModel _viewModel;

        public SklepPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SklepViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}