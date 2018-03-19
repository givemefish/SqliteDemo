// =================================================================
// File: Program.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/15 下午 04:12
// Update Date: 2018/03/16 上午 11:03
// =================================================================
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace SqliteApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .Build();
        }
    }
}