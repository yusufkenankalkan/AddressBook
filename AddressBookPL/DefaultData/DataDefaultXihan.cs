using AddressBookEL.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace AddressBookPL.DefaultData
{
    public class DataDefaultXihan
    {
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
                            Name = $"{DateTime.Now} {item}"
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
