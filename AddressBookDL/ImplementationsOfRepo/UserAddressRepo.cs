﻿using AddressBookDL.ImplementationsOfRepo;
using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDL.ImplementationOfRepo
{
    public class UserAddressRepo : Repository<UserAddress, int>, IUserAddressRepo
    {
        public UserAddressRepo(MyContext context) : base (context)
        {

        }
    }
}
