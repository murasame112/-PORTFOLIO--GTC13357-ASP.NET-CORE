using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class MyExceptionAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if(context.Exception is MyException)
        {
            var body = new Dictionary<string, Object>();
            body["error"] = context.Exception.Message;
            context.Result = new BadRequestObjectResult(body);
        }
    }
}