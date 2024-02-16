using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FirstProject.Data;
using FirstProject.Models;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<FirstProjectContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("FirstProjectContext") ?? throw new InvalidOperationException("Connection string 'FirstProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();


//Adding Session services configurations
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(20);//in seconds
    options.Cookie.HttpOnly = true; //internally stores the data in cookies like sessionID
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
