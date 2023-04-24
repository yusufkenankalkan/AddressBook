using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookEL.Models
{
    [Table("Neighbourhoods")]
    public class Neighbourhood : BaseNumeric
    {
        //Eğer bu tablonun PK'sı string olsaydı BaseNumericten kalıtım alamazdı. Böyle bir senaryoda;
        // 1) BaseNonNumeric classı oluşturulabilir
        // 2) Kalıtım almadan bu classın içine direkt olarak prop tanımlanabilir. --->> public string Id {get; set;}
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string PostCode { get; set; }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
    }
}
