namespace RestApiZamowienia.Middlewares;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Threading.Tasks;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task<IActionResult> InvokeAsync(HttpContext context)
    {
        var userToken = context.Request.Headers["token"].ToString();
        Console.WriteLine("get got a token:" + userToken);
        // Make sure we have the token
        if (userToken == "" ) {

            context.Response.StatusCode = 403;
      
            return new ObjectResult("Forbidden") { StatusCode = 403 };

            //throw new Exception("Forbidden");
        }

        // TODO: Validate the token


        // All ok
        context.Response.Headers.Add("X-Custom-Header", "Hello from Custom Middleware!");
        await _next(context);

        return new ObjectResult("ok") { StatusCode = 200 };
    }
}
