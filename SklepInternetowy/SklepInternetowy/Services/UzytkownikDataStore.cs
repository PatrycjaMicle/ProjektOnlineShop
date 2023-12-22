using System;
using System.Linq;
using System.Threading.Tasks;
using SklepInternetowy.Helpers;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.Services
{
    public class UzytkownikDataStore : ADataStore<Uzytkownik>
    {
        public UzytkownikDataStore() 
        {
           items = _sklepInternetowyService.UzytkownikAllAsync().GetAwaiter().GetResult().ToList();
        }
        public override Uzytkownik Find(Uzytkownik item)
        {
            return items.FirstOrDefault(a => a.IdUzytkownika == item.IdUzytkownika);
        }

        public override Uzytkownik Find(int id)
        {
            return items.FirstOrDefault(user => user.IdUzytkownika == id);
        }

        public override async Task Refresh()
        {
            items = (await _sklepInternetowyService.UzytkownikAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Uzytkownik item)
        {
            return await _sklepInternetowyService.UzytkownikDELETEAsync(item.IdUzytkownika).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Uzytkownik item)
        {
            throw new NotImplementedException();
        }

        public override async Task<Uzytkownik> AddItemToService(Uzytkownik item)
        {
            return await _sklepInternetowyService.UzytkownikPOSTAsync(item).HandleRequest();
        }
    }
}
