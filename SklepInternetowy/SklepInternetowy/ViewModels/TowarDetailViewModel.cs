using System;
using System.Diagnostics;
using SklepInternetowy.Services.DataStore;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class TowarDetailViewModel : BaseViewModel
    {
        private double? cena;
        public TowaryDataStore dataStore = new TowaryDataStore();

        private int itemId;
        private string kod;
        private string nazwa;
        private string opis;
        private string url;
        public int Id { get; set; }

        public string Opis
        {
            get => opis;
            set => SetProperty(ref opis, value);
        }


        public string Url
        {
            get => url;
            set => SetProperty(ref url, value);
        }

        public double? Cena
        {
            get => cena;
            set
            {
                if (cena != value)
                {
                    cena = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Kod
        {
            get => kod;
            set => SetProperty(ref kod, value);
        }

        public string Nazwa
        {
            get => nazwa;
            set => SetProperty(ref nazwa, value);
        }

        public int ItemId
        {
            get => itemId;
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await dataStore.GetItemAsync(itemId);
                Id = item.IdTowaru;
                Cena = item.Cena;
                Opis = item.Opis;
                Kod = item.Kod;
                Nazwa = item.Nazwa;
                Url = item.ZdjecieUrl;

                Debug.WriteLine($"URL: {Url}");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}