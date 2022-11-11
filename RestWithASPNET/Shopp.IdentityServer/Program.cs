using Microsoft.AspNetCore;

namespace Shopp.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder();
                builder.AddCommandLine(args);

                var config = builder.Build();
                var pathToContentRoot = Directory.GetCurrentDirectory();

                var webHostArgs = args.Where(arg => arg != "--console").ToArray();

                var host = WebHost.CreateDefaultBuilder(webHostArgs)
                         .UseConfiguration(config)
                         .UseContentRoot(pathToContentRoot)
                         .UseStartup<Startup>()
                         .Build();

                host.Run();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}