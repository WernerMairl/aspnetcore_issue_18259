using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sample.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            lifetime.ApplicationStarted.Register(() =>
            {
                var logger = app.ApplicationServices.GetRequiredService<ILogger<Startup>>();
                logger.LogInformation(101, $"Application started");
            });

            lifetime.ApplicationStopping.Register(() =>
            {
                var logger = app.ApplicationServices.GetRequiredService<ILogger<Startup>>();
                logger.LogInformation(102, $"Application stop requested");
            });

            lifetime.ApplicationStopped.Register(() =>
            {
                var logger = app.ApplicationServices.GetRequiredService<ILogger<Startup>>();
                logger.LogInformation(103, $"Application stopped");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); //wwwroot/index.html the one and only output provided by this app!
        }
    }
}

