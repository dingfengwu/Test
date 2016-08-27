using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Kehu1688.Framework.API
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            ConfigEnvironment();
        }

        public IConfigurationRoot Configuration { get; set; }

        public static string PublicClientId { get; private set; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return ConfigServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            ConfigSetting(app, env, loggerFactory);
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
