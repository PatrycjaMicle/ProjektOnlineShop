using System;
using System.Diagnostics;
using SklepInternetowy.Services;
using SklepInternetowy.Services.DataStore;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class DaneOsoboweViewModel : BaseViewModel
    {
        public int Id { get; set; }

        private readonly UzytkownikDataStore _uzytkownikDataStore = new UzytkownikDataStore();
        private string imie;
        private string nazwisko;
        private readonly UserService _userService;


        public DaneOsoboweViewModel()
        {
            _userService = DependencyService.Get<UserService>();
            LoadItemId(_userService.UserId);
        }

        public string Imie
        {
            get => imie;
            set => SetProperty(ref imie, value);
        }

        public string Nazwisko
        {
            get => nazwisko;
            set => SetProperty(ref nazwisko, value);
        }

        public async void LoadItemId(int id)
        {
            try
            {
                var item = _uzytkownikDataStore.Find(id);
                Id = item.IdUzytkownika;
                Imie = item.Imie;
                Nazwisko = item.Nazwisko;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}