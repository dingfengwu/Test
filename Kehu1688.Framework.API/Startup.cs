﻿using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Permission.Service;
using Kehu1688.Framework.Store;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Kehu1688.Framework.Middleware;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc.Filters;
using Kehu1688.Framework.DI;

namespace Kehu1688.Framework.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            
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

                options.User.AllowedUserNameCharacters = null;// "abcdefghijklmnopqrstuvwxyz0123456789";
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            
            services.AddMvc(options=> {
                options.Filters.Add(PermissionAuthorizeFilter<PermissionRequirement>.Default);
            });
            services.AddCors();


            //验证权限
            //services.AddAuthorization(option =>
            //{
            //    option.AddPolicy("default",
            //        policy => policy.AddRequirements(new PermissionRequirement()));
            //});
            //services.AddSingleton<IAuthorizationHandler, DefaultPermissionHandler>();



            services.AddSingleton(typeof(RoleService));
            services.AddSingleton(typeof(UserService));
            services.AddSingleton(typeof(ApplicationUserStore));
            services.AddSingleton(typeof(ApplicationRoleStore));
            services.AddSingleton(typeof(PermissionService));
            services.AddInstance(typeof(IConfigurationRoot), Configuration);

            ////增加注入
            //services.AddInstance(typeof(IConfigurationRoot), Configuration);
            //Register.RegisterService(services);
            //return Register.Get<IServiceProvider>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            PublicClientId = "self";
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSecurity(new SecurityMiddlewareOption()
            {
                AllowArgumentEncrypt = false,
                ValidateData=false,
                AppId = PublicClientId
            });
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

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
            
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                AuthorizeEndpointPath = new PathString("/Authorize"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AuthorizationCodeExpireTimeSpan = TimeSpan.FromDays(30),

                Provider = new ApplicationOAuthProvider(PublicClientId),
                AccessTokenProvider = app.CreateAccessTokenProvider(),
                RefreshTokenProvider = app.CreateRefreshTokenProvider(),
                AuthorizationCodeProvider = app.CreateAuthorizationCodeProvider(),
                
                //在生产模式下设 AllowInsecureHttp = false
                AllowInsecureHttp = true
            };
            app.UseOAuthBearerTokens(OAuthOptions);
            
            app.UseCors(string.Empty);
            app.UseMvc();
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
