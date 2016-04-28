using Kehu1688.Framework.Base;
using Kehu1688.Framework.DI;
using Kehu1688.Framework.Middleware;
using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Permission.Service;
using Kehu1688.Framework.Store;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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
