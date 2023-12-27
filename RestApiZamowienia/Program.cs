using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestApiZamowienia.Helpers;
using RestApiZamowienia.Models.Context;
using RestApiZamowienia.Services;
using RestApiZamowienia.Services.Interfaces;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using RestApiZamowienia.Exceptions;
using RestApiZamowienia.Models;
using RestApiZamowienia.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SklepInternetowyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SklepInternetowyEntities")));

// Add services to the container.

var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(configuration =>
{
    configuration.RequireHttpsMetadata = false;
    configuration.SaveToken = true;
    configuration.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPasswordHasher<Uzytkownik>, PasswordHasher<Uzytkownik>>();
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<SklepInternetowyContext>();
var pendingMigrations = dbContext.Database.GetPendingMigrations();
if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

if (!dbContext.Uzytkowniks.Any())
{
    dbContext.Seed();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Temporary disable the AppExceptionHandler via middleware (causing Errors)
// app.UseMiddleware<AppExceptionHandler>();


// Apply the Auth Middleware to specific endpoint path
app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/Towar"), appBuilder =>
{
    appBuilder.UseMiddleware<AuthMiddleware>();
});

//this would apply Auth to all andpoints (even to api/Konto)
// app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
