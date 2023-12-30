using SklepInternetowy.ViewModels;
using Xamarin.Forms;

namespace SklepInternetowy.Views
{
    public partial class TowarDetailPage : ContentPage
    {
        public TowarDetailPage()
        {
            InitializeComponent();
            BindingContext = new TowarDetailViewModel();
        }
    }
}