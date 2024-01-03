using SklepInternetowy.WWW.Services.DataStore;
using SklepInternetowyServiceReference;
using System.Net.Http.Headers;

namespace SklepInternetowy.WWWW.Services.DataStore
{
    public abstract class ADataStore<T> : IDataStore<T> where T : class
    {
        //private readonly UserService _userToken; 
        protected readonly SklepInternetowyService sklepInternetowyService;
        public List<T> items;

        public ADataStore()
        {
           // _userToken = /

            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization =
            //new AuthenticationHeaderValue("Bearer", _userToken.Token);
            
            //POKI NIE MA USER SERVICE I LOGOWANIA WBILAM SWOJ TOKEN RECZNIE - DELETE ME!!!
            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzA5NDI0OTk4LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUyMTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUyMTkifQ.wnS0xIlyeKdwjaTSTNCq80NBEQ42teH7m9P6X-327FQ");

            sklepInternetowyService = new SklepInternetowyService("http://localhost:5219/", httpClient);
        }


        public async Task<bool> AddItemAsync(T item)
        {
            await AddItemToService(item);
            await Refresh();
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            var oldItem = Find(item);
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Find(id);
            await DeleteItemFromService(oldItem);
            await Refresh();

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(Find(id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await Refresh();
            return await Task.FromResult(items);
        }

        public abstract T Find(T item);
        public abstract T Find(int id);
        public abstract Task Refresh();
        public abstract Task<bool> DeleteItemFromService(T item);
        public abstract Task<bool> UpdateItemInService(T item);
        public abstract Task<T> AddItemToService(T item);
    }
}
