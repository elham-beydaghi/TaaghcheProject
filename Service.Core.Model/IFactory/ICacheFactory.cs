using Service.Core.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Model.IFactory
{
    public interface ICacheFactory
    {
        ICacheData CacheManager(string cacheName);
    }
}
