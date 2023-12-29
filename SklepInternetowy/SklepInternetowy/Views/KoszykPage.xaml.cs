using SklepInternetowy.ViewModels;
using Xamarin.Forms;

namespace SklepInternetowy.Views
{
    public partial class KoszykPage : ContentPage
    {
        private readonly KoszykViewModel _viewModel;

        public KoszykPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new KoszykViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}