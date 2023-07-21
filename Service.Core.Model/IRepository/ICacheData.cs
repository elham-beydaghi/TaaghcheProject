using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Model.IRepository
{
    public interface ICacheData
    {
        Task<T> GetCacheDataAsync<T>(string cacheKey);
        Task RemoveCacheDataAsync(string cacheKey);
        Task SetCacheDataAsync<T>(string cacheKey, T cacheValue);
    }

}
