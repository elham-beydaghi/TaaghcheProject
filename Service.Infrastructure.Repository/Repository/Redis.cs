using Microsoft.Extensions.Caching.Distributed;
using Service.Core.Model.IRepository;
using System.Text.Json;


namespace Service.Infrastructure.CacheRepository.Repository
{
    public class Redis : ICacheData
    {
        private readonly IDistributedCache _redis;

        public Redis(IDistributedCache redis)
        {
            _redis = redis;
        }

        public async Task<T> GetCacheDataAsync<T>(string cacheKey)
        {

            string cacheData = await _redis.GetStringAsync(cacheKey);


            if (!string.IsNullOrEmpty(cacheData))
            {

                return JsonSerializer.Deserialize<T>(cacheData);
            }


            return default;
        }

        public async Task RemoveCacheDataAsync(string cacheKey)
        {
            // Remove the cache data
            await _redis.RemoveAsync(cacheKey);
        }

        public async Task SetCacheDataAsync<T>(string cacheKey, T cacheValue)
        {
            var cacheExpiry = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10.0),
                SlidingExpiration = TimeSpan.FromMinutes(5.0)
            };

            await _redis.SetStringAsync(cacheKey, JsonSerializer.Serialize(cacheValue), cacheExpiry);
        }


    }
}
