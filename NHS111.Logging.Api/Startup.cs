using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NHS111.Logging.Api.Services;

namespace NHS111.Logging.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogService>(new LogService(Configuration["TableStorageAccountName"], Configuration["TableStorageAccountKey"], Configuration["TableStorageName"]));
            services.AddSingleton<IMonitorService>(new MonitorService());
            services.AddScoped<ApiExceptionFilter>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddLogging(log =>
                log.AddLog4Net(Configuration.GetValue<string>("Logging:Log4NetConfigFile:Name"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            using (StreamReader iisUrlRewriteStreamReader = File.OpenText("wwwroot/web.config"))
            {
                var options = new RewriteOptions().AddIISUrlRewrite(iisUrlRewriteStreamReader);
                app.UseRewriter(options);
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
