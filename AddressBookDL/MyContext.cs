using AddressBookEL.IdentityModels;
using AddressBookEL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDL
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, string>
    {

        //Bir önceki projede DbContexten kalıtım aldık. Bu projede ise Idenetity'e ait tabloları kullanabilmek için IdentityDbContexten kalıtım aldık.
        //IdentityDbContextin generic yapısını kullandık çümkü AppUser aracılığıyla microsoftun AspNetUsers tablosuna kendi istediğimiz kolonları ekledik
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        } //ctor
        public DbSet<City> CityTable { get; set; }
        public DbSet<District> DistrictTable { get; set; }
        public DbSet<Neighbourhood> NeighbourhoodTable { get; set; }
        public DbSet<UserAddress> UserAddressTable { get; set; }

    }
}
