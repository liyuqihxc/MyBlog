using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyBlog.Common
{
    public class ApiActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //var errStates = context.ModelState.Where(m => m.Value.Errors.Any());
                //var messages = errStates.Select(m => new { m.Value, SubMessage = string.Join("\r\n", m.Value.Errors.Select(e => e.ErrorMessage)) });
                throw new ArgumentException("Invalid model!");
            }
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
