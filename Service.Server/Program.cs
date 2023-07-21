using Service.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var myHost = ProgramBuilder.CreateHostBuilder<Startup>(args).Build();
        myHost.Run();
    }
}