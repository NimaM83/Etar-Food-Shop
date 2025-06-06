using Etar.Application.Interfaces.Context;
using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Interfaces.Services.Owner;
using Etar.Application.Services.Admins;
using Etar.Application.Services.Owners;
using Etar.Presistance.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionStr = builder.Configuration.GetConnectionString("DefualtConnection");

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllersWithViews(optins => optins.EnableEndpointRouting = false);
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddScoped<IOwnerServices, OwnerServices>();
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionStr));

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Home/Index");
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
});




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
app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(name: "AspAreaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}");

    routes.MapRoute(name: "DefualtRouting",
                    template: "{controller=Home}/{action=SignIn}");
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=SignIn}/{id?}");
//app.MapControllerRoute(
//        name: "areas",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
