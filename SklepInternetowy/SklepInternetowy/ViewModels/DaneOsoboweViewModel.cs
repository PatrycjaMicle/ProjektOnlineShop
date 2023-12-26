using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SklepInternetowy.Services.DataStore;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class DaneOsoboweViewModel : BaseViewModel
    {
        private readonly UzytkownikDataStore _uzytkownikDataStore = new UzytkownikDataStore();
        private string text;
        private string description;

        public DaneOsoboweViewModel()
        {
            LoadItemId(1);
        }
        public int Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public async void LoadItemId(int id)
        {
            try
            {
                var item = _uzytkownikDataStore.Find(id);
                Id = item.IdUzytkownika;
                Text = "Fullname";
                Description = $"{item.Imie + " " + item.Nazwisko}";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
