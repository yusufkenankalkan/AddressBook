using AddressBookEL.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace AddressBookPL.DefaultData
{
    public class DataDefaultXihan
    {
        public void CheckAndCreateRoles(RoleManager<AppRole> roleManager)
        {
            try
            {
                string[] roles = new string[] { "Admin", "Customer", "Guest" };

                foreach (string item in roles)
                {
                    if (!roleManager.RoleExistsAsync(item.ToLower()).Result)
                    {
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
                //ex loglanabilir.
            }
        }
    }
}
