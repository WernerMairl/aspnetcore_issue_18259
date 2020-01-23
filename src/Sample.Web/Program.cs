using System;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Sample.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Issue Sample App");

            if (System.Linq.Enumerable.Contains(args.Select(a => a.ToLowerInvariant()), "--info"))
            {
                Environment.Exit(0);
            }

            var builder = WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>();

            builder.Build().Run();
        }
    }
}
