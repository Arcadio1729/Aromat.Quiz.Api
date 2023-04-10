using Aromat.Upload.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException notFoundException)
            {
                this._logger.LogError(notFoundException, notFoundException.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch(Exception e)
            {
                this._logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                //await context.Response.WriteAsync("Message "+e.Message+"\nInner Exception: "+e.InnerException);
                await context.Response.WriteAsync("Something went  wrong");
            }
        }
    }
}
