using SklepInternetowy.Helpers;
using SklepInternetowy.WWWW.Services.DataStore;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.WWW.Services.DataStore
{
    public class KodPromocjiDataStore : ADataStore<KodPromocji>
    {
        public KodPromocjiDataStore()
        {
            items = sklepInternetowyService.KodPromocjisAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override KodPromocji Find(KodPromocji item)
        {
            return items.FirstOrDefault(a => a.IdKoduPromocji == item.IdKoduPromocji);
        }

        public override KodPromocji Find(int id)
        {
            return items.FirstOrDefault(towar => towar.IdKoduPromocji == id);
        }

        public override async Task Refresh()
        {
            items = (await sklepInternetowyService.KodPromocjisAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(KodPromocji item)
        {
            return await sklepInternetowyService.KodPromocjisDELETEAsync(item.IdKoduPromocji).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(KodPromocji item)
        {
            throw new NotImplementedException();
        }

        public override async Task<KodPromocji> AddItemToService(KodPromocji item)
        {
            return await sklepInternetowyService.KodPromocjisPOSTAsync(item).HandleRequest();
        }


        public async Task<KodPromocjiResponse> GetZnizka(string kod)
        {
            return await sklepInternetowyService.GetZnizkaAsync(kod);
        }
    }
}