using SklepInternetowy.WWW.Models.Services.DataStore;
using SklepInternetowy.WWW.Services;
using SklepInternetowy.WWW.Services.DataStore;
using SklepInternetowy.WWWW.Services.DataStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<ElementKoszykaForViewDataStore>();
builder.Services.AddScoped<KodPromocjiDataStore>();
builder.Services.AddScoped<ElementKoszykaDataStore>();
builder.Services.AddScoped<TowaryDataStore>();
builder.Services.AddScoped<TowarZamowieniaDataStore>();
builder.Services.AddScoped<ZamowienieDataStore>();
builder.Services.AddScoped<UzytkownikDataStore>();
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//TODO we don't have any authorization on controllers in MVC layer so if someone knows URL ex. https://localhost:7152/Sklep/Sklep, can send
//TODO a request, exception will be thrown with piece of code so that's bad. WE should've use Identity package instead of our external API
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Konto}/{action=Index}/{id?}");

app.Run();
