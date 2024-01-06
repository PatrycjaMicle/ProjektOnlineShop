using SklepInternetowy.Helpers;
using SklepInternetowy.WWWW.Services.DataStore;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.WWW.Models.Services.DataStore;

public class UzytkownikDataStore : ADataStore<Uzytkownik>
{
    public UzytkownikDataStore()
    {
        items = sklepInternetowyService.UzytkownikAllAsync().GetAwaiter().GetResult().ToList();
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
        items = (await sklepInternetowyService.UzytkownikAllAsync()).ToList();
    }

    public override async Task<bool> DeleteItemFromService(Uzytkownik item)
    {
        return await sklepInternetowyService.UzytkownikDELETEAsync(item.IdUzytkownika).HandleRequest();
    }

    public override async Task<bool> UpdateItemInService(Uzytkownik item)
    {
        throw new NotImplementedException();
    }

    public override async Task<Uzytkownik> AddItemToService(Uzytkownik item)
    {
        return await sklepInternetowyService.UzytkownikPOSTAsync(item).HandleRequest();
    }
}