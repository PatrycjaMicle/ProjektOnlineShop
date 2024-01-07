using SklepInternetowy.Helpers;
using SklepInternetowy.WWW.Services;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.WWWW.Services.DataStore
{
    public class TowarZamowieniaDataStore : ADataStore<TowarZamowienium>
    {
        public TowarZamowieniaDataStore(UserService userService) : base(userService)
        {
            GetItems();
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
            GetItems();            
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

        private void GetItems()
        {
            items = sklepInternetowyService.TowarZamowieniumAllAsync()
                .GetAwaiter()
                .GetResult()
             //   .Where(a => a.IdZamowienia == CartService.IdZamowienia)
                .ToList();
        }
    }
}