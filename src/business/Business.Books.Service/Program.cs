using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MicroservicesGrpcExample.Client
{
    /// <summary>
    /// Program class. Service entrypoint 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method. Service entrypoint 
        /// </summary>
        public static Task Main(string[] args) =>
            CreateHostBuilder(args)
                .Build()
                .RunAsync();
        

        /// <summary>
        /// Program class. Service entrypoint 
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(opt =>
                {
                    opt.ClearProviders();
                    opt.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}