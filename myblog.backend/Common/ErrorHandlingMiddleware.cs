using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using MyBlog.Models;
using Newtonsoft.Json;

namespace MyBlog.Common
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, loggerFactory);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is NotImplementedException)
                code = HttpStatusCode.NotImplemented;

            var result = JsonConvert.SerializeObject(new ExceptionModel { Message = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
