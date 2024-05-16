using System.Net;
using System.Text.Json;
using Library.System.Errors;

namespace Library.System.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment en;

        public ExceptionMiddleware(RequestDelegate next , ILogger<ExceptionMiddleware> logger, IHostEnvironment en)
        {
            this.next = next;
            this.logger = logger;
            this.en = en;
        }
        public async Task InvokeAsync (HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var response = en.IsDevelopment() ?
                                    new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                                    new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };    
                var json = JsonSerializer.Serialize(response);

                await httpContext.Response.WriteAsync(json);
               
            }
        }
    }
}
