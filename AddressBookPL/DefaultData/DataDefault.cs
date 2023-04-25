using AddressBookEL.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace AddressBookPL.DefaultData
{
    public static class DataDefault
    {
        public static IApplicationBuilder Data(this IApplicationBuilder app) //extension metot
        {
            //Manager'ları kullanabilmek için EXTENTION metot oluşturduk

            //Bir metod EXTENTION metot ise parametresinde THIS kelimesi vardır

            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;

            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            CheckAndCreateRoles(roleManager); //rolemanager oluştu ve şimdi rolleri oluşturan methodu çağırabiliriz.


            return app;
        }


        public static void CheckAndCreateRoles(RoleManager<AppRole> roleManager)
        {
            try
            {
                //admin //customer //misafir vb...
                string[] roles = new string[] { "admin", "customer", "guest" };

                //rolleri tek tek dönüp sistemde olup olmadığına bakacağız. Yoksa ekleyeceğiz

                foreach (var item in roles)
                {
                    //ROLDEN YOK MU?
                    if (!roleManager.RoleExistsAsync(item.ToLower()).Result)
                    {
                        //rolden yokmuş ekleyelim
                        AppRole role = new AppRole()
                        {
                            Name = item
                        };

                        var result = roleManager.CreateAsync(role).Result;
                    }
                }
            }
            catch (Exception ex)
            {
                // ex loglanabilir
                // yazılımcıya acil başlıklı mail gönderilebilir
            }
        }


    }
}
