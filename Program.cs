using KAR_Robotics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Localization resources
builder.Services.AddLocalization();

// MVC + Localization
builder.Services
    .AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

builder.Services.AddAuthorization();

// Supported cultures
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("tr"),
    new CultureInfo("de")
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("tr");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    var provider = new RouteDataRequestCultureProvider
    {
        RouteDataStringKey = "culture",
        UIRouteDataStringKey = "culture"
    };

    options.RequestCultureProviders = new[] { provider };
});

var app = builder.Build();

// Hata yönetimi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Localization
var locOptions = app.Services
    .GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(locOptions);

// Auth middleware
app.UseAuthentication();
app.UseAuthorization();

// Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{culture=tr}/{controller=Home}/{action=Index}/{id?}");

app.Run();
