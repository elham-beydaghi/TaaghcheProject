using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Service.Core.Model.IFactory;
using Service.Core.Model.IRepository;
using Service.Infrastructure.CacheRepository.Repository;

namespace Service.Infrastructure.CacheRepository.Factory
{
    public class CacheFactory : ICacheFactory
    {

        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _redisCache;
        public CacheFactory(IMemoryCache memoryCache, IDistributedCache redisCache)
        {
            _redisCache = redisCache;
            _memoryCache = memoryCache;
        }

        public ICacheData CacheManager(string cacheName)
        {
            return cacheName switch
            {
                "redis" => new Redis(_redisCache),
                "memory" => new Memory(_memoryCache),
                _ => throw new ArgumentException("Invalid cache name"),
            };
        }
    }
}
