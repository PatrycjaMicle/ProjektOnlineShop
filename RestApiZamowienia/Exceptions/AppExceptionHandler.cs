namespace RestApiZamowienia.Exceptions;

public class AppExceptionHandler : IMiddleware
{
    //TODO we can add logger here
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (BadRequestException badRequestException)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(badRequestException.Message);
        }
    }
}