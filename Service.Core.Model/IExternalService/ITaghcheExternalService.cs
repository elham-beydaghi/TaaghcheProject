using Service.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Model.IExternalService
{
    public interface ITaghcheExternalService
    {
        Task<BookInfoEntity> GetBookInfoById(int id);
    }
}
