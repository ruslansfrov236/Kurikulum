using kurikulum.Helper;
using kurikulum.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFormFileService , FormFileService>();
builder.Services.AddScoped<IVideoFileService , VideoFileService>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = false;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);



    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".Kurikulum.Security.Cookie",
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.Always,


    };
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"));
});
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin",
    defaults: new { Controller = "Dashboard", Action = "Index" });
app.MapDefaultControllerRoute();

app.Run();
