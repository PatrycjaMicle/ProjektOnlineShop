using SklepInternetowy.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SklepInternetowy.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}