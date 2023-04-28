﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookEL.ViewModels
{
    public class ApiVM
    {
        //https://api.ubilisim.com/postakodu/il/34
        //Yukarıda ki apiden dönen json içindeki "postakodu" arrayi bu class ile karşılayabiliriz

        //"success": true,
        //"status": "ok",
        //"dataupdatedate": "2023-04-28",
        //"description": "PTT tarafından günlük olarak çekilerek güncellenen posta kodlarıdır.",
        //"pagecreatedate": "2023-04-28 00:00:00",

        public bool success { get; set; }
        public string status { get; set; }
        public string dataupdatedate { get; set; }
        public string description { get; set; }
        public string pagecreatedate { get; set; }

        //"postakodu": [] array olarak geliyor. Ona ait bilgileri diğer class yardımıyla aktaracağız.
        public List<PostalCodeApiVM> postakodu { get; set; }


    }
}
