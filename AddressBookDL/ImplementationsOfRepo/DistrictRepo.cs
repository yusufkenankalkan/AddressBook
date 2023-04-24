using AddressBookDL.ImplementationsOfRepo;
using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDL.ImplementationOfRepo
{
    public class DistrictRepo : Repository<District, int>, IDistrictRepo
    {
        public DistrictRepo(MyContext context) : base(context)
        {

        }
    }
}
