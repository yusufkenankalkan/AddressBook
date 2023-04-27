using AddressBookBL.InterfacesOfManagers;
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
                //admin // customer  // misafir vb...
                string[] roles = new string[] { "Admin", "Customer", "Guest" };

                // rolleri tek tek dönüp sisteme olup olmadığına bakacağız. Yoksa ekleyeceğiz.
                foreach (var item in roles)
                {
                    // ROLDEN YOK MU? 
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
                // ex loglanabilşr
                // yazılımcıya acil başlıklı email gönderilebilir
            }
        }


        public void CreateAllCities(ICityManager cityManager)
        {
            try
            {
                //1) Veritabanındaki illeri listeye alalım
                //2) Excele açıp satır satır okuyup 
                //3) Olmayan ili veritabanına ekleyelim

                var cityList = cityManager.GetAll(x => !x.IsRemoved).Data;  //1)

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Excels");

                string fileName = Path.GetFileName("Cities.xlsx"); // ???

                string filePath = Path.Combine(path, fileName);





            }
            catch (Exception ex)
            {
                //loglanacak

            }



        }





    }
}
