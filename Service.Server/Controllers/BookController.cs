using Microsoft.AspNetCore.Mvc;
using Service.Core.Application.Dto;
using Service.Core.Application.Dto.Service.Core.Model.Entities;
using Service.Core.Application.IService;


namespace Service.Server.Controllers
{
    [Route("book")]
    public class BookInfoController : ControllerBase
    {
        private readonly IBookInfoService _bookInfoService;

        public BookInfoController(IBookInfoService bookInfoService)
        {
            _bookInfoService = bookInfoService;
        }
        
        [HttpGet]
        [Route("{id}")]
        public Task<BookInfoDto> GetBookInfoById(int id)
        {
            return _bookInfoService.GetBookInfoById(id);
        }


    }
}
