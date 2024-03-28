using System.Net;
using System.Text.Json;
using UniforBackend.Domain.Exceptions;

namespace UniforBackend.API.Exceptions
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is CustomException customException)
            {
                // Handle UserFriendlyException with custom error message.
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errorResponse = new ErrorResponse
                {
                    Message = customException.ErrorResponse.Message,
                    StatusCode = customException.ErrorResponse.StatusCode
                };
                var json = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(json);
            }
            else
            {
                _logger.LogError(exception.Message + exception.StackTrace);
                //return a generic error response.
                var errorResponse = new ErrorResponse
                {
                    Message = "Oops! Something went wrong!",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                var json = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(json);
            }
        }

        public class ErrorResponse
        {
            public string Message { get; set; }
            public int StatusCode { get; set; }
        }
    }
}
