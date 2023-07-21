using Service.Core.Model.IRepository;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Service.Infrastructure.CacheRepository.Repository
{
    public class Memory : ICacheData
    {
        private readonly IMemoryCache _memoryCache;

        public Memory(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<T> GetCacheDataAsync<T>(string cacheKey)
        {

            // use built in methid for cleaning the green line GetOrCreateAsync
            if (_memoryCache.TryGetValue(cacheKey, out string? cacheData))
            {
                return JsonSerializer.Deserialize<T>(cacheData);
            }


            return default;
        }

        public async Task RemoveCacheDataAsync(string cacheKey)
        {
            // Remove the cache data
            await Task.Run(() => _memoryCache.Remove(cacheKey));
        }

        public async Task SetCacheDataAsync<T>(string cacheKey, T cacheValue)
        {

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));

            await Task.Run(() => _memoryCache.Set(cacheKey, JsonSerializer.Serialize(cacheValue), cacheEntryOptions));
        }
    }
}
