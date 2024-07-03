namespace Batch4.Api.PayrollManagementSystem.Exceptions
{
    public static class ExceptionMiddlewareExtentions
    {
        public static void CustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();
        }
    }
}
