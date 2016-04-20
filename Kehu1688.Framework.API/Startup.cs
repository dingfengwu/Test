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
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public static string PublicClientId { get; private set; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:Connections:WriteConnectionString"]));
            
            //标识身份验证
            services.AddIdentity<User, IdentityRole>(options=> {
                options.Cookies.ApplicationCookie.AuthenticationScheme = "ApplicationCookie";
                //options.Cookies.ApplicationCookie.DataProtectionProvider = new DataProtectionProvider(new DirectoryInfo("C:\\Github\\Identity\\artifacts"));
                options.Cookies.ApplicationCookie.CookieName = "Interop";

                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonLetterOrDigit = false;
                options.Password.RequireUppercase = false;

                options.User.AllowedUserNameCharacters = null;
                // "abcdefghijklmnopqrstuvwxyz0123456789";
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddPermission();
            services.AddStore();
            
            services.AddMvc(options=> {
                options.Filters.Add(PermissionAuthorizeFilter<PermissionRequirement>.Default);

                options.Filters.Add(new GlobalException());
            });
            services.AddCors();

            //services.AddCaching();
            //services.AddSession();
            
            //增加注入
            services.AddInstance(typeof(IConfigurationRoot), Configuration);
            Register.RegisterService(services);
            return Register.Get<IServiceProvider>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            PublicClientId = "self";
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddProvider(new TextLoggerProvider(options=> {
                options.LoggerPath = env.MapPath("./Logs/");
            }));
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseSecurity(new SecurityMiddlewareOption()
                {
                    AllowArgumentEncrypt = true,
                    ValidateData = true,
                    AppId = PublicClientId
                });

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            //app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseRightHandler(new List<RightHandler<RightOption>>
            {
               new OperateRightHandler(new RightOption { Order=0, Scheme="Automic" })
            });
            //app.UseSession();
            

            //使用OAuth服务
            app.UseOAuthBearerTokens(options =>
            {
                options.TokenEndpointPath = new PathString("/Token");
                options.AuthorizeEndpointPath = new PathString("/Authorize");
                options.AccessTokenExpireTimeSpan = TimeSpan.FromDays(1);
                options.AuthorizationCodeExpireTimeSpan = TimeSpan.FromDays(30);

                options.Provider = new ApplicationOAuthProvider(PublicClientId);
                options.AccessTokenProvider = app.CreateAccessTokenProvider();
                options.RefreshTokenProvider = app.CreateRefreshTokenProvider();
                options.AuthorizationCodeProvider = app.CreateAuthorizationCodeProvider();

                //在生产模式下设 AllowInsecureHttp = false
                options.AllowInsecureHttp = true;
            });

            app.UseCors(string.Empty);
            app.UseMvc();
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
