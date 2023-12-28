namespace RestApiZamowienia.Middlewares;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using RestApiZamowienia.Services;
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
        Console.WriteLine("we got a token:" + userToken);
        // Make sure we have the token
        if (userToken == "" ) {

            context.Response.StatusCode = 403;
      
            return new ObjectResult("Forbidden") { StatusCode = 403 };

            //throw new Exception("Forbidden");
        }

        //Validate the token
        var userID = JwtService.GetUserFromToken(userToken);

        if (userID == string.Empty) {
            context.Response.StatusCode = 403;

            return new ObjectResult("Invalid user") { StatusCode = 403 };
        }

        Console.WriteLine("Added user ID to context..." + userID);
        context.Items.Add("user_id", userID);

        // All ok
        context.Response.Headers.Add("X-Custom-Header", "Hello from Custom Middleware!");
        await _next(context);

        return new ObjectResult("ok") { StatusCode = 200 };
    }
}
