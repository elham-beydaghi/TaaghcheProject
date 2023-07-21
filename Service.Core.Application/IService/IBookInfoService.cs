using Service.Core.Application.Dto;
using Service.Core.Application.Dto.Service.Core.Model.Entities;

namespace Service.Core.Application.IService
{
    public interface IBookInfoService
    {
        Task<BookInfoDto> GetBookInfoById(int id);
    }
}
