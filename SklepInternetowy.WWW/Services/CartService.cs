using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Services.DataStore;
using SklepInternetowyServiceReference;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Services
{
    public class CartService
    {
        public ObservableCollection<ElementKoszykaForView> ElementyKoszykaForView { get; }

        private ElementKoszykaDataStore _elementyKoszykaDataStore;
        private ElementKoszykaForViewDataStore _elementyKoszykaForViewdataStore;

        public CartService()
        {
            _elementyKoszykaDataStore = new ElementKoszykaDataStore();
            _elementyKoszykaForViewdataStore = new ElementKoszykaForViewDataStore();
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
