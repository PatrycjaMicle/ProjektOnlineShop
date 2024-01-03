using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Services.DataStore;
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
