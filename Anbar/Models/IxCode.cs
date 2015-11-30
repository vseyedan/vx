using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anbar.Models
{
    public class IxCode
    {
        
            public int ID { get; set; }

            [Required]
            [StringLength(70, MinimumLength = 1)]
            [DisplayName("کد شاخص رنگ")]
            public string IxCodeName { get; set; }


            public virtual ICollection<Product> Products { get; set; }
        }
}