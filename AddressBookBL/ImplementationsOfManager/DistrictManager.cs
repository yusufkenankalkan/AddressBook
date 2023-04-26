using AddressBookBL.ImplementationsOfManagers;
using AddressBookBL.InterfacesOfManagers;
using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;
using AddressBookEL.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.ImplementationsOfManager
{
    public class DistrictManager : Manager<DistrictVM, District, int>, IDistrictManager
    {

        public DistrictManager(IDistrictRepo repo, IMapper mapper) : base(repo, mapper, "City")
        {

        }
    }
}
