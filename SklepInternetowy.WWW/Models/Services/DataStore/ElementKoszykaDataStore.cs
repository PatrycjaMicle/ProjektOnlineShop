using SklepInternetowy.Helpers;
using SklepInternetowy.WWWW.Services.DataStore;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.WWW.Models.Services.DataStore
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
            return await sklepInternetowyService.ElementKoszykaDELETEAsync(item.IdElementuKoszyka).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(ElementKoszyka item)
        {
            try
            {
                var existingItem = items.FirstOrDefault(e => e.IdElementuKoszyka == item.IdElementuKoszyka);

                if (existingItem != null)
                {
                    existingItem.Ilosc++;

                    return await sklepInternetowyService
                        .ElementKoszykaPUTAsync(existingItem.IdElementuKoszyka, existingItem)
                        .HandleRequest();
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during item update: {ex.Message}");
                return false;
            }
        }


        public override async Task<ElementKoszyka> AddItemToService(ElementKoszyka item)
        {
            return await sklepInternetowyService.ElementKoszykaPOSTAsync(item).HandleRequest();
        }
    }
}