﻿using SklepInternetowy.Models;
using SklepInternetowy.ViewModels.Deprecated;
using Xamarin.Forms;

namespace SklepInternetowy.Views
{
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

        public Item Item { get; set; }
    }
}