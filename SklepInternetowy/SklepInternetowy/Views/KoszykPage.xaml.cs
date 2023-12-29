using SklepInternetowy.Models;
using SklepInternetowy.ViewModels;
using SklepInternetowy.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SklepInternetowy.Views
{
    public partial class KoszykPage : ContentPage
    {
        KoszykViewModel _viewModel;

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