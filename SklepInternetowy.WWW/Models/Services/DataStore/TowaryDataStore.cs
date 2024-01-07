using SklepInternetowy.Helpers;
using SklepInternetowy.WWWW.Services.DataStore;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.WWW.Services.DataStore
{
    public class TowaryDataStore : ADataStore<Towar>
    {
        public TowaryDataStore(UserService userService) : base(userService)
        {
            items = sklepInternetowyService.TowarAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override Towar Find(Towar item)
        {
            return items.FirstOrDefault(a => a.IdTowaru == item.IdTowaru);
        }

        public override Towar Find(int id)
        {
            return items.FirstOrDefault(towar => towar.IdTowaru == id);
        }

        public override async Task Refresh()
        {
            items = (await sklepInternetowyService.TowarAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Towar item)
        {
            return await sklepInternetowyService.TowarZamowieniumDELETEAsync(item.IdTowaru).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Towar item)
        {
            throw new NotImplementedException();
        }

        public override async Task<Towar> AddItemToService(Towar item)
        {
            return await sklepInternetowyService.TowarPOSTAsync(item).HandleRequest();
        }
    }
}