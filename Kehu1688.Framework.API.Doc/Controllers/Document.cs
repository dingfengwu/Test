/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Document.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-29 15:33:23
//----------------------------------------------------------------*/



using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace Kehu1688.Framework.API.Doc.Controllers
{
    public class DocumentController: Controller
    {
        ILogger _logger;

        public DocumentController(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger(nameof(DocumentController));
        }

        /// <summary>
        /// OAuth介绍
        /// </summary>
        /// <returns></returns>
        public IActionResult Authorize()
        {
            return View();
        }

        /// <summary>
        /// 授权错误响应
        /// </summary>
        /// <returns></returns>
        public IActionResult AuthorizeError()
        {
            return View();
        }

        /// <summary>
        /// Authorization Code授权
        /// </summary>
        /// <returns></returns>
        public IActionResult AuthorizeCode()
        {
            return View();
        }

        /// <summary>
        /// Implicit Grant授权
        /// </summary>
        /// <returns></returns>
        public IActionResult ImplicitGrant()
        {
            return View();
        }

        /// <summary>
        /// Client Credentials授权
        /// </summary>
        /// <returns></returns>
        public IActionResult ClientCredentials()
        {
            return View();
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <returns></returns>
        public IActionResult RefreshToken()
        {
            return View();
        }
        
        /// <summary>
        /// API文档
        /// </summary>
        /// <returns></returns>
        [ResponseCache(CacheProfileName ="Default")]
        public IActionResult API(string viewName)
        {
            var env = HttpContext.ApplicationServices.GetService(typeof(IApplicationEnvironment)) as IApplicationEnvironment;
            var root = env.ApplicationBasePath;
            _logger.LogInformation(root);

            var defaultFilename = Path.Combine(root, "wwwroot", "html", "default.html");
            var filename = Path.Combine(root, "wwwroot", "html", $"{viewName?.ToLower()}.html");
            FileInfo file = new FileInfo(filename);
            if (!file.Exists)
            {
                file = new FileInfo(defaultFilename);
            }
            var content = file.OpenText().ReadToEndAsync();
            ViewBag.html = content.Result;

            return View();
        }
    }
}
