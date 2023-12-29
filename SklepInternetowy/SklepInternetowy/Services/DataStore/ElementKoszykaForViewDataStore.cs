using System.Linq;
using System.Threading.Tasks;
using SklepInternetowy.Helpers;
using SklepInternetowy.Models;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.Services.DataStore
{
    public class ElementKoszykaForViewDataStore : ADataStore<ElementKoszykaForView>
    {
        private readonly ElementKoszykaMapper mapper;
        private readonly UserService _userService;

        public ElementKoszykaForViewDataStore()
        {
            _userService = DependencyService.Get<UserService>();
            
            var towaryDataStore = new TowaryDataStore();
            mapper = new ElementKoszykaMapper(towaryDataStore);

            GetItems();
        }

        public override ElementKoszykaForView Find(ElementKoszykaForView item)
        {
            return items.FirstOrDefault(a => a.IdTowaru == item.IdTowaru);
        }

        public override ElementKoszykaForView Find(int id)
        {
            return items.FirstOrDefault(e => e.IdElementuKoszyka == id);
        }

        public override async Task Refresh()
        {
            var towaryDataStore = new TowaryDataStore();

            GetItems();
        }

        public override async Task<bool> DeleteItemFromService(ElementKoszykaForView item)
        {
            return await sklepInternetowyService.ElementKoszykaDELETEAsync(item.IdElementuKoszyka).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(ElementKoszykaForView item)
        {
            return true;
        }
        
        public override async Task<ElementKoszykaForView> AddItemToService(ElementKoszykaForView item)
        {
            var elementKoszyka = new ElementKoszyka
            {
                IdUzytkownika = item.IdUzytkownika,
                IdTowaru = item.IdTowaru,
                DataUtworzenia = item.DataUtworzenia,
                Ilosc = item.Ilosc
            };
            await sklepInternetowyService.ElementKoszykaPOSTAsync(elementKoszyka).HandleRequest();
            return item;
        }

        private void GetItems()
        {
            items = sklepInternetowyService.ElementKoszykaAllAsync()
                .GetAwaiter().GetResult()
                .Where(a=> a.IdUzytkownika == _userService.UserId)
                .Select(elementKoszyka => mapper.MapToElementKoszykaForView(elementKoszyka))
                .ToList();
        }
    }
}