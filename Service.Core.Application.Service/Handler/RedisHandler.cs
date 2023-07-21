using Service.Core.Application.Dto.Service.Core.Model.Entities;
using Service.Core.Application.Helper;
using Service.Core.Model.Entities;
using Service.Core.Model.IFactory;
using Service.Core.Model.IHandler;
using Service.Core.Model.IRepository;

namespace Service.Core.Application.Service.Handler
{
    public class RedisHandler : IHandler
    {

        private readonly ICacheFactory _cacheFactory;
        private IHandler _nextHandler;

        public RedisHandler(ICacheFactory cacheFactory)
        {
            _cacheFactory = cacheFactory;
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public async Task<BookInfoDto> Handle(int id)
        {
            var stringID = id.ToString();

            ICacheData memoryCache = _cacheFactory.CacheManager("memory");
            
            ICacheData redisCache = _cacheFactory.CacheManager("redis");

            var redisCachedData = await redisCache.GetCacheDataAsync<BookInfoEntity>(stringID);

            if (redisCachedData != null)
            {

                await memoryCache.SetCacheDataAsync(stringID, redisCachedData);
                return redisCachedData.ToDto();
            }

            else if (_nextHandler != null)
            {
                return await _nextHandler.Handle(id);
            }

            return null;
        }
    }
}
