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
            return await sklepInternetowyService.ElementKoszykaDELETEAsync(item.IdElementuKoszyka).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(ElementKoszyka item)
        {
            Console.WriteLine("Updating CartItem...**********");
            try
            {
                var existingItem = items.FirstOrDefault(e => e.IdElementuKoszyka == item.IdElementuKoszyka);

                if (existingItem != null)
                {
                    existingItem.Ilosc++;

                    return await sklepInternetowyService.ElementKoszykaPUTAsync(existingItem.IdElementuKoszyka, existingItem)
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

        public override async Task<ElementKoszyka> CheckIfExistsInService(ElementKoszyka item)
        {
            Console.WriteLine("Checking if cartItem already exists...");
            return await sklepInternetowyService.CheckIfExistsAsync(item).HandleRequest();

        }
    }
}
