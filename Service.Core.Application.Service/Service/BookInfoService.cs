using Service.Core.Application.Dto.Service.Core.Model.Entities;
using Service.Core.Application.IService;
using Service.Core.Application.Service.Handler;
using Service.Core.Model.IExternalService;
using Service.Core.Model.IFactory;
using Service.Core.Model.IHandler;

namespace Service.Core.Application.Service.Service
{
    public class BookInfoService : IBookInfoService
    {
        private readonly ITaghcheExternalService _taghcheExternalService;
        private readonly ICacheFactory _cacheFactory;
        public BookInfoService(ITaghcheExternalService taghcheExternalService, ICacheFactory cacheFactory)
        {
            _cacheFactory = cacheFactory;
            _taghcheExternalService = taghcheExternalService;
        }
        public async Task<BookInfoDto> GetBookInfoById(int id)
        {
           
            IHandler memoryCacheHandler = new MemoryCacheHandler(_cacheFactory);
            IHandler redisCacheHandler = new RedisHandler(_cacheFactory);
            IHandler externalServiceHandler = new ExternalServiceHandler(_taghcheExternalService, _cacheFactory);

            memoryCacheHandler.SetNext(redisCacheHandler).SetNext(externalServiceHandler);

            var bookInfoDto = await memoryCacheHandler.Handle(id);
            return bookInfoDto;



        }
    }
}
