using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookEL.Models
{
    [Table("Districts")]
    public class District : BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")] //CityId'ye yazdığımız int değerinin City tablosunda karşıllığı olmak zorunda
        public virtual City City { get; set; } 
        // CityId propertysi Foreign Key olacağı için burada City tablosuyla ilişkisi kuruldu.
        // DİPNOT: İlişkiler byrada kurulacağı gibi MYCONTEXT classı içindeki OnModelCreating metodu ezilerek (override) kurulabilir


    }
}
