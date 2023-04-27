﻿using AddressBookBL.EmailSenderBusiness;
using AddressBookBL.ImplementationOfManagers;
using AddressBookBL.ImplementationsOfManager;
using AddressBookBL.ImplementationsOfManagers;
using AddressBookBL.InterfacesOfManagers;
using AddressBookDL;
using AddressBookDL.ImplementationOfRepo;
using AddressBookDL.ImplementationsOfRepo;
using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.IdentityModels;
using AddressBookEL.Mapping;
using AddressBookPL.DefaultData;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));

});



var lockoutOptions = new LockoutOptions()
{
    AllowedForNewUsers = true,
    DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1),
    MaxFailedAccessAttempts = 2
};

//identtiy ayarı 
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // ayarlar eklenecek
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false; // @ / () [] {} ? : ; karakterler
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz-_0123456789";
    options.Lockout = lockoutOptions;

}).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();





//auto mapper ayarları

builder.Services.AddAutoMapper(x =>
{
    x.AddExpressionMapping();
    x.AddProfile(typeof(Maps));
});


// Add services to the container.
builder.Services.AddControllersWithViews();

//interfacelerin DI için yaşam dngüleri (AddScoped)
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddScoped<ICityManager, CityManager>();

builder.Services.AddScoped<IDistrictRepo, DistrictRepo>();
builder.Services.AddScoped<IDistrictManager, DistrictManager>();

builder.Services.AddScoped<INeighbourhoodRepo, NeighbourhoodRepo>();
builder.Services.AddScoped<INeighbourhoodManager, NeighbourhoodManager>();

builder.Services.AddScoped<IUserAddressRepo, UserAddressRepo>();
builder.Services.AddScoped<IUserAddressManager, UserAddressManager>();

builder.Services.AddScoped<IEmailSender, EmailSender>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles(); // wwwroot

app.UseRouting();

app.UseAuthentication(); //login logout
app.UseAuthorization(); // yetki

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Proje ilk çalışacağı zaman default olarak eklenmesini istediğiniz verileri yada başka işlemleri yazdığınız classı burada çağırmalısınız


//buraya geri döneceğiz

//app.Data(); // extension metot olarka çağırmak
//DataDefault.Data(app);  // harici çağırmak

//Xihan Shen ablanın yönteminden yapalım böylece Erdener'in static olmasın isteiğini yerine getirelim.

using (var scope = app.Services.CreateScope())
{
    //Resolve ASP .NET Core Identity with DI help
    var userManager = (UserManager<AppUser>?)scope.ServiceProvider.GetService(typeof(UserManager<AppUser>));
    var roleManager = (RoleManager<AppRole>?)scope.ServiceProvider.GetService(typeof(RoleManager<AppRole>));
    // do you things here

    var cityManager = (ICityManager?)scope.ServiceProvider.GetService(typeof(ICityManager));
    var districtManager = (IDistrictManager?)scope.ServiceProvider.GetService(typeof(IDistrictManager));
    var neighbourhoodManager = (INeighbourhoodManager?)scope.ServiceProvider.GetService(typeof(INeighbourhoodManager));

    DataDefaultXihan d = new DataDefaultXihan();

    //d.CheckAndCreateRoles(roleManager);
    //d.CreateAllCities(cityManager);
    //d.CreateAllDistricts(districtManager);
    //d.CreateSomeNeighbourhood(neighbourhoodManager, cityManager, districtManager);

}


app.Run(); // uygulamayı çalıştır

