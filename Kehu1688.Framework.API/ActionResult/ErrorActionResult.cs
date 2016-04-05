﻿/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：ErrorApiResult.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-23 17:16:33
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kehu1688.Framework.API
{
    public class ErrorApiResult : ApiResult,IActionResult
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错识描述
        /// </summary>
        public string ErrorMsg { get; set; }
        
        public static ErrorApiResult FromModelState(ModelStateDictionary modelState)
        {
            if(modelState==null)
            {
                return new ErrorApiResult { Result = false, ErrorCode = InnerErrorCode.MODEL_NOT_NULL, ErrorMsg = Resource.ResourceManager.GetString("MODEL_NOT_NULL") };
            }

            StringBuilder errorBuilder = new StringBuilder();
            if (!modelState.IsValid)
            {
                foreach(var model in modelState)
                {
                    if(model.Value.Errors.Count>0)
                    {
                        foreach (var error in model.Value.Errors)
                        {
                            errorBuilder.Append(error.ErrorMessage);
                            errorBuilder.Append(";");
                        }
                    }
                }
            }
            return new ErrorApiResult { Result = false, ErrorCode = InnerErrorCode.MODEL_INVOLID, ErrorMsg = errorBuilder.ToString() };
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 400;
            context.HttpContext.Response.ContentType = "application/json;chatset=utf-8";
            context.HttpContext.Response.Headers["Cache-Control"] = "no-store";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";

            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
            await context.HttpContext.Response.Body.WriteAsync(bytes,0,bytes.Length);
        }
    }
}
