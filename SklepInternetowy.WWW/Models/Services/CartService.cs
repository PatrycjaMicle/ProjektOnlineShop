using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Models.Services.DataStore;
using SklepInternetowy.WWW.Models.ViewModels;
using SklepInternetowy.WWW.Services.DataStore;
using SklepInternetowyServiceReference;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Services
{
    public class CartService
    {
        public ObservableCollection<ElementKoszykaForView> ElementyKoszykaForView { get; }
        public static double? Znizka;
        public static double? Suma;
        public static int IdKoduPromocji;

        private readonly ElementKoszykaDataStore _elementyKoszykaDataStore;
        private readonly ElementKoszykaForViewDataStore _elementyKoszykaForViewdataStore;
        
        public CartService(ElementKoszykaDataStore elementyKoszykaDataStore, ElementKoszykaForViewDataStore elementyKoszykaForViewdataStore)
        {
            _elementyKoszykaDataStore = elementyKoszykaDataStore;
            _elementyKoszykaForViewdataStore = elementyKoszykaForViewdataStore;
            ElementyKoszykaForView = new ObservableCollection<ElementKoszykaForView>();
            ExecuteLoadItemsAsync().Wait();
        }

        public async Task addToCart(int idTowaru)
        {
            ElementKoszyka elementKoszyka = new ElementKoszyka() { IdTowaru = idTowaru };
            await _elementyKoszykaDataStore.AddItemToService(elementKoszyka);
        }

        private async Task ExecuteLoadItemsAsync()
        {
            try
            {
                ElementyKoszykaForView.Clear();

                var items = await _elementyKoszykaForViewdataStore.GetItemsAsync(true);
                foreach (var item in items)
                    ElementyKoszykaForView.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
