using Service.Core.Application.Dto.Service.Core.Model.Entities;

namespace Service.Core.Model.IHandler
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        Task<BookInfoDto> Handle(int id);
    }
}
