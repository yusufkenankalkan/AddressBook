using AddressBookDL;
using AddressBookEL.IdentityModels;
using AddressBookEL.Mapping;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

//identity ayarý
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // ayarlar eklenecek
    options.Password.RequiredLength = 4;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz-_0123456789";
}).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();



//auto mapper ayarlarý

builder.Services.AddAutoMapper(x =>
{
    x.AddExpressionMapping();
    x.AddProfile(typeof(Maps));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

//Ýnterfacelerin DI için yaþam döngüleri (AddScoped)
//geri döneceðiz

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//login logout
app.UseAuthorization(); // yetki

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
