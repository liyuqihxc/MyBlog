using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyBlog.Common
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            Exception innerException = context.Exception;

            // 根据 ExceptionContext.Exception 记录日志
            string aName = context.ActionDescriptor.DisplayName;
            //string cName = context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string query = context.HttpContext.Request.GetDisplayUrl();
            string body = context.HttpContext.Request.Body.ReadAsStringAsync().Result ?? "";

            // 这里可以根据项目需要返回到客户端特定的状态码。
            if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
            else if (actionExecutedContext.Exception is TimeoutException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.RequestTimeout);
            }
            else
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            ErrorMessage msg = new ErrorMessage()
            {
                Code = (int)actionExecutedContext.Response.StatusCode,
                Message = innerException.Message,
            };

            actionExecutedContext.Response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(msg));

            await base.OnExceptionAsync(context);
        }
    }
}
