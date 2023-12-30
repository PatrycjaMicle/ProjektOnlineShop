using System;
using System.Linq;
using System.Threading.Tasks;
using SklepInternetowy.Helpers;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.Services.DataStore
{
    public class TowarZamowieniaDataStore : ADataStore<TowarZamowienium>
    {
        public TowarZamowieniaDataStore()
        {
            items = sklepInternetowyService.TowarZamowieniumAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override TowarZamowienium Find(TowarZamowienium item)
        {
            return items.FirstOrDefault(a => a.IdTowaruZamowienia == item.IdTowaruZamowienia);
        }

        public override TowarZamowienium Find(int id)
        {
            return items.FirstOrDefault(towar => towar.IdTowaruZamowienia == id);
        }

        public override async Task Refresh()
        {
            items = (await sklepInternetowyService.TowarZamowieniumAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(TowarZamowienium item)
        {
            return await sklepInternetowyService.TowarZamowieniumDELETEAsync(item.IdTowaruZamowienia).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(TowarZamowienium item)
        {
            throw new NotImplementedException();
        }

        public override async Task<TowarZamowienium> AddItemToService(TowarZamowienium item)
        {
            return await sklepInternetowyService.TowarZamowieniumPOSTAsync(item).HandleRequest();
        }
    }
}