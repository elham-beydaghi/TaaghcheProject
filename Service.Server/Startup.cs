using Service.Core.Application.IService;
using Service.Core.Application.Service.Service;
using Service.Core.Model.IFactory;
using Service.Infrastructure.CacheRepository.Factory;
using Service.Core.Model.IExternalService;
using Service.Infrastructure.ExternalService.ExternalService;

namespace Service.Server
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = _configuration.GetSection("RedisCacheUrl").Value;
                options.InstanceName = "";
            });
            services.AddControllers();
            services.AddHttpClient();
            services.AddMemoryCache();
            services.AddSingleton<IBookInfoService, BookInfoService>();
            services.AddSingleton<ICacheFactory, CacheFactory>();
            services.AddSingleton<ITaghcheExternalService, TaghcheExternalService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseEndpoints(endpionts =>
            {
                endpionts.MapControllers();
            });
        }
    }
}
