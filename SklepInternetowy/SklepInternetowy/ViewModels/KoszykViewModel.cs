﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using SklepInternetowy.Models;
using SklepInternetowy.Services;
using SklepInternetowy.Services.DataStore;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowy.Views;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class KoszykViewModel : AListViewModel<ElementKoszykaForView>
    {
        #region decl

        private ADataStore<Towar> towaryDataStore = new TowaryDataStore();
        private ADataStore<Zamowienie> zamowienieDataStore = new ZamowienieDataStore();
        private ADataStore<ElementKoszykaForView> elementKoszykaForViewDataStore = new ElementKoszykaForViewDataStore();

        private double? suma;
        public double? Suma
        {
            get { return suma; }
            set
            {
                if (suma != value)
                {
                    suma = value;
                    OnPropertyChanged(nameof(Suma));
                }
            }
        }
        #endregion

        #region base

        public KoszykViewModel()
            : base("Koszyk")
        {
            InitializeSumaAsync();
            Suma = CartService.Suma;
            CartService.OnSumaChanged += (sender, args) =>
            {
                Suma = CartService.Suma;
            };
        }

        public override async void GoToAddPage()
        {
        }

        public override void OnItemSelected(ElementKoszykaForView item)
        {
        }
        #endregion

        #region Place order

        public ICommand PlaceOrderCommand => new Command(OnPlaceOrder);

        private async void OnPlaceOrder()
        {
            try
            {
                Zamowienie zamowienie = new Zamowienie();

                zamowienie.DataZamowienia = DateTime.Now;
                zamowienie.Suma = Suma;
                zamowienie.IdMetodyPlatnosci = 1;
                zamowienie.TerminDostawy = DateTime.Now.Add(TimeSpan.FromDays(7));

                var addedItem = await zamowienieDataStore.AddItemToService(zamowienie);
                if (addedItem == null) Console.WriteLine("Failed to add new ElementKoszyka.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // TODO set ElementsKoszyka to TowaryZamowienia
            // TODO delete ElementsKoszyka for a given IdUzytkownika
        }

        private async void InitializeSumaAsync()
        {
            try
            {
                var koszykItems = await elementKoszykaForViewDataStore.GetItemsAsync(true);
                CartService.Suma = koszykItems.Sum(x => (x.TowarCena ?? 0) * x.Ilosc.GetValueOrDefault());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during sum calculation: {ex.Message}");
            }
        }
        #endregion
    }
}
