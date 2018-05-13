using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using MyBlog.Models;

namespace MyBlog.Common
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        readonly ILoggerFactory _loggerFactory;

        public ApiExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider,
            ILoggerFactory loggerFactory
        )
        {
            _loggerFactory = loggerFactory;
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            Exception innerException = context.Exception;

            // 根据 ExceptionContext.Exception 记录日志
            string aName = context.ActionDescriptor.DisplayName;
            //string cName = context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string query = context.HttpContext.Request.GetDisplayUrl();
            string body = await context.HttpContext.Request.GetRawBodyAsStringAsync();

            // 这里可以根据项目需要返回到客户端特定的状态码。
            /*if (context.Exception is NotImplementedException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
            }
            else if (context.Exception is TimeoutException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }*/

            ResultModel result = new ResultModel()
            {
                StatusCode = context.HttpContext.Response.StatusCode,
                Message = innerException.Message,
            };
            context.Result = new JsonResult(result);

            context.ExceptionHandled = true;

            await base.OnExceptionAsync(context);
        }
    }
}
