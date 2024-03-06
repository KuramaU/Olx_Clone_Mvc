using Microsoft.EntityFrameworkCore;
using Data;
using System.Reflection;
using Shop.Services;
using Microsoft.AspNetCore.Identity;
using Shop.Helpers;
using Data.Entities;
using MVC_BagShop.Helpers;
var builder = WebApplication.CreateBuilder(args);
string connStr = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();


//configurations
builder.Services.AddDbContext<ShopDbContextcs>(x => x.UseSqlServer(connStr));

builder.Services.AddIdentity<User,IdentityRole>()
  .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ShopDbContextcs>();


builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;


});


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    
    Seeder.SeedRoles(serviceProvider).Wait();

    Seeder.SeedAdmins(serviceProvider).Wait();



}




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
app.UseAuthentication();;

app.UseAuthorization();

app.UseSession();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CategoriesMenu}/{action=Index}/{id?}");

app.Run();
