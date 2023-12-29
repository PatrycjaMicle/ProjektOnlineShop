﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.Services.DataStore
{
    public abstract class ADataStore<T> : IDataStore<T> where T : class
    {
        private readonly UserService _userToken;
        protected readonly SklepInternetowyService sklepInternetowyService;
        public List<T> items;

        public ADataStore()
        {
            _userToken = DependencyService.Get<UserService>();
            
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _userToken.Token);

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