using ArtistPlatform.Application.Exceptions;

namespace ArtistPlatform.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                NotFoundExceptions => StatusCodes.Status404NotFound,
                ValidationExceptions => StatusCodes.Status400BadRequest,
                ConflictException => StatusCodes.Status409Conflict,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };
            var result = new
            {
                error = exception.Message,
                statusCode = context.Response.StatusCode
            };
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
