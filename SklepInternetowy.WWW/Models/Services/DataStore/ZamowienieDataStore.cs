using SklepInternetowy.Helpers;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.WWWW.Services.DataStore
{
    public class ZamowienieDataStore : ADataStore<Zamowienie>
    {
        public ZamowienieDataStore()
        {
           items = sklepInternetowyService.ZamowieniesAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override Zamowienie Find(Zamowienie item)
        {
            return items.FirstOrDefault(a => a.IdZamowienia == item.IdZamowienia);
        }

        public override Zamowienie Find(int id)
        {
            return items.FirstOrDefault(towar => towar.IdZamowienia == id);
        }

        public override async Task Refresh()
        {
            items = (await sklepInternetowyService.ZamowieniesAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Zamowienie item)
        {
            return await sklepInternetowyService.UzytkownikDELETEAsync(item.IdZamowienia).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Zamowienie item)
        {
            throw new NotImplementedException();
        }

        public override async Task<Zamowienie> AddItemToService(Zamowienie item)
        {
            return await sklepInternetowyService.ZamowieniesPOSTAsync(item).HandleRequest();
        }
    }
}