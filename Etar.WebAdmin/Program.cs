using Etar.Application.Interfaces.Context;
using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins;
using Etar.Presistance.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionStr = builder.Configuration.GetConnectionString("DefualtConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionStr));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
