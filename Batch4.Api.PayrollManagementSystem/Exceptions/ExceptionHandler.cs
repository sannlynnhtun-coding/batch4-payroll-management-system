using Azure;
using Batch4.Api.PayrollManagementSystem.Shared.Exceptions;
using System.Net;

namespace Batch4.Api.PayrollManagementSystem.Exceptions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
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
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(exception.Message);

            httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                DBModifyException => (int)HttpStatusCode.InternalServerError,
                _ => (int)HttpStatusCode.InternalServerError,
            };
        }
    }
}
