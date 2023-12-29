using System;
using System.Linq;
using System.Threading.Tasks;
using SklepInternetowy.Helpers;
using SklepInternetowy.Models;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.Services.DataStore
{
    public class ElementKoszykaForViewDataStore : ADataStore<ElementKoszykaForView>
    {
        private readonly ElementKoszykaMapper mapper;

        public ElementKoszykaForViewDataStore()
        {
            var towaryDataStore = new TowaryDataStore(); 
            mapper = new ElementKoszykaMapper(towaryDataStore);

            items = sklepInternetowyService.ElementKoszykaAllAsync()
                .GetAwaiter().GetResult()
                .Select(elementKoszyka => mapper.MapToElementKoszykaForView(elementKoszyka))
                .ToList();
        }

        public override ElementKoszykaForView Find(ElementKoszykaForView item)
        {
            return items.FirstOrDefault(a => a.IdTowaru == item.IdTowaru);
        }

        public override ElementKoszykaForView Find(int id)
        {
            return items.FirstOrDefault(e => e.IdElementuKoszyka == id);
        }

        public override async Task Refresh()
        {
        }

        public override async Task<bool> DeleteItemFromService(ElementKoszykaForView item)
        {
            return await sklepInternetowyService.ElementKoszykaDELETEAsync(item.IdElementuKoszyka).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(ElementKoszykaForView item)
        {
            return true;
        }


        public override async Task<ElementKoszykaForView> AddItemToService(ElementKoszykaForView item)
        {
            ElementKoszyka elementKoszyka = new ElementKoszyka();
            elementKoszyka.IdUzytkownika = item.IdUzytkownika;
            elementKoszyka.IdTowaru = item.IdTowaru;
            elementKoszyka.DataUtworzenia = item.DataUtworzenia;
            elementKoszyka.Ilosc=item.Ilosc;
            sklepInternetowyService.ElementKoszykaPOSTAsync(elementKoszyka).HandleRequest();
            return item;

        }
    }
}
