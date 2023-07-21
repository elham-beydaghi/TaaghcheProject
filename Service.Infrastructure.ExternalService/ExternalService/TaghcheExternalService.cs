using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Service.Core.Model.Entities;
using Service.Core.Model.IExternalService;

namespace Service.Infrastructure.ExternalService.ExternalService
{
    public class TaghcheExternalService: ITaghcheExternalService
    {

        private readonly IConfiguration _configuration;
        private readonly string _bookInfoUrl;
        private readonly HttpClient _httpClient;
        public TaghcheExternalService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _bookInfoUrl = _configuration.GetSection("ExternalServiceAddress").GetSection("BookInfoUrl").Value;
            _httpClient = httpClient;   
        }
        public async Task<BookInfoEntity> GetBookInfoById(int id)
        {
            var url = $"{_bookInfoUrl}/{id}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // throw an exception if the response is not successful
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<BookInfoEntity>(responseBody, options);

        }

    }
}