using System;
using System.Linq;
using System.Threading.Tasks;
using SklepInternetowy.Helpers;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.Services.DataStore
{
    public class ElementKoszykaDataStore : ADataStore<ElementKoszyka>
    {
        public ElementKoszykaDataStore()
        {
            items = sklepInternetowyService.ElementKoszykaAllAsync().GetAwaiter().GetResult().ToList();
        }
        public override ElementKoszyka Find(ElementKoszyka item)
        {
            return items.FirstOrDefault(a => a.IdTowaru == item.IdTowaru);
        }

        public override ElementKoszyka Find(int id)
        {
            return items.FirstOrDefault(e => e.IdElementuKoszyka == id);
        }

        public override async Task Refresh()
        {
            items = (await sklepInternetowyService.ElementKoszykaAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(ElementKoszyka item)
        {
            return await sklepInternetowyService.UzytkownikDELETEAsync(item.IdElementuKoszyka).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(ElementKoszyka item)
        {
            throw new NotImplementedException();
        }

        public override async Task<ElementKoszyka> AddItemToService(ElementKoszyka item)
        {
            return await sklepInternetowyService.ElementKoszykaPOSTAsync(item).HandleRequest();
        }
    }
}
