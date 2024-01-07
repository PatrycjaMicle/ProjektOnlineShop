using SklepInternetowy.WWW.Models.Services.DataStore;
using SklepInternetowy.WWW.Services;
using SklepInternetowy.WWW.Services.DataStore;
using SklepInternetowy.WWWW.Services.DataStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<CartService>();
builder.Services.AddTransient<ElementKoszykaForViewDataStore>();
builder.Services.AddTransient<KodPromocjiDataStore>();
builder.Services.AddTransient<ElementKoszykaDataStore>();
builder.Services.AddTransient<TowaryDataStore>();
builder.Services.AddTransient<TowarZamowieniaDataStore>();
builder.Services.AddTransient<ZamowienieDataStore>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Konto}/{action=Index}/{id?}");

app.Run();
