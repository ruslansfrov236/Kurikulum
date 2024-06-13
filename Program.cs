using kurikulum.Areas.Data.Helper;
using kurikulum.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFormFileService , FormFileService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"));
});
var app = builder.Build();
app.UseStaticFiles();
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin",
    defaults: new { Controller = "Dashboard", Action = "Index" });
app.MapDefaultControllerRoute();

app.Run();
