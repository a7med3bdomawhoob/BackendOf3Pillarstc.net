namespace HubTask.Helpers
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pass control to the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Handle the exception
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Log the exception (use your preferred logging library)
            Console.WriteLine($"An error occurred: {exception.Message}");
            // Prepare the error response
            var response = context.Response;
            response.ContentType = "application/json";
            // Set the status code based on the exception type
            response.StatusCode = exception switch
            {
                ArgumentNullException => (int)HttpStatusCode.BadRequest, // 400
                KeyNotFoundException => (int)HttpStatusCode.NotFound,    // 404
                _ => (int)HttpStatusCode.InternalServerError             // 500
            };
            var errorResponse = new
            {
                StatusCode = response.StatusCode,
                Message = exception.Message,
                Details = exception.InnerException?.Message
            };
            // Serialize the error response as JSON
            var errorJson = JsonSerializer.Serialize(errorResponse);
            // Write the response
            return response.WriteAsync(errorJson);
        }
    }
}
