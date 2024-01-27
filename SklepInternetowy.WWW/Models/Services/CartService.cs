using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Models.Services.DataStore;
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
        public static int? IdKoduPromocji = null;

        private readonly ElementKoszykaDataStore _elementyKoszykaDataStore;
        private readonly ElementKoszykaForViewDataStore _elementyKoszykaForViewdataStore;
        
        public CartService(ElementKoszykaDataStore elementyKoszykaDataStore, ElementKoszykaForViewDataStore elementyKoszykaForViewdataStore)
        {
            _elementyKoszykaDataStore = elementyKoszykaDataStore;
            _elementyKoszykaForViewdataStore = elementyKoszykaForViewdataStore;
            ElementyKoszykaForView = new ObservableCollection<ElementKoszykaForView>();
            ExecuteLoadItemsAsync().Wait();
        }

        public async Task AddToCart(int idTowaru)
        {
            var elementKoszyka = new ElementKoszyka { IdTowaru = idTowaru };
            await _elementyKoszykaDataStore.AddItemToService(elementKoszyka);
        }
        
        public async Task DeleteFromCart(int idTowaru)
        {
            var elementKoszyka = new ElementKoszyka { IdTowaru = idTowaru };
            var item = _elementyKoszykaDataStore.Find(elementKoszyka);
            if (item.Ilosc > 1)
            {
                item.Ilosc--;
                await _elementyKoszykaDataStore.UpdateItemInService(item);
            }
            else
            {
                //TODO tutaj cos z respnsem jest nie tak, zwraca 204 i apka sie nie zawiesza mimo ze leci exception
                await _elementyKoszykaDataStore.DeleteItemFromService(item);
            }
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
