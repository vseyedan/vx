using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anbar.Models
{
    public class Unit
    {
        public int ID { get; set; }

        [Required]
        [StringLength(15,MinimumLength =1)]
        [DisplayName("واحد اندازه گیری")]
        public string UnitName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}