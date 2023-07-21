namespace Service.Server
{
    public class ProgramBuilder
    {
        public static IHostBuilder CreateHostBuilder<T>(params string[] args)
        where T : Startup
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(defaults => defaults.UseStartup<T>());
        }
    }
}
