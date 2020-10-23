using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Infrastructure.Middleware
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerManager _logger;

        //public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        //{
        //    _logger = logger;
        //    _next = next;
        //}

        public ExceptionMiddleware(RequestDelegate next)
        {
            
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            dynamic json = new 
            {
                data = "",
                status = false,
                message = exception.Message,

            };



            //convert json to a stream
            var buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(json, Formatting.Indented));
            await context.Response.Body.WriteAsync(buffer);

        
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
