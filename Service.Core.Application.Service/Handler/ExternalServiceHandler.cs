using Service.Core.Application.Dto.Service.Core.Model.Entities;
using Service.Core.Application.Helper;
using Service.Core.Model.IExternalService;
using Service.Core.Model.IFactory;
using Service.Core.Model.IHandler;
using Service.Core.Model.IRepository;

namespace Service.Core.Application.Service.Handler
{
    public class ExternalServiceHandler: IHandler
    {
        private readonly ITaghcheExternalService _taghcheExternalService;
        private readonly ICacheFactory _cacheFactory;
        private IHandler _nextHandler;

        public ExternalServiceHandler(ITaghcheExternalService taghcheExternalService, ICacheFactory cacheFactory)
        {
            _cacheFactory = cacheFactory;
            _taghcheExternalService = taghcheExternalService;
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public async Task<BookInfoDto> Handle(int id)
        {
            var stringID = id.ToString();
            var bookInfo = await _taghcheExternalService.GetBookInfoById(id);
            
            ICacheData memoryCache = _cacheFactory.CacheManager("memory");

            ICacheData redisCache = _cacheFactory.CacheManager("redis");

            await memoryCache.SetCacheDataAsync(stringID, bookInfo);
            await redisCache.SetCacheDataAsync(stringID, bookInfo);
            return bookInfo.ToDto();
        }

        public IHandler GetNextHandler()
        {
            return _nextHandler;
        }
    }
}
