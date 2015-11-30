using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Anbar.Models
{
    [DisplayName("محصول")]
    public class Product
    {
        public int ID { get; set; }

        [DisplayName("کد شاخص رنگ")]
        public int IxCodeID { get; set; }

        [DisplayName("گروه محصول")]
        public int ProductCategoryID { get; set; }
        [DisplayName("کد محصول")]
        [StringLength(20)]
        public string ProductCode { get; set; }
        [DisplayName("نام محصول")]
        [StringLength(60,MinimumLength =1)]
        public string ProductName { get; set; }
        [DisplayName("شرح محصول")]
        [StringLength(100)]
        public string ProductDescription { get; set; }
        [DisplayName("واحد اندازه گیری")]
        public int UnitID { get; set; }
        [DisplayName("سطح سفارش")]
        public int StockLevel { get; set; }

        public virtual ICollection <TransactionDetail> TransactionDetails { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        
        public  virtual ProductCategory ProductCategory { get; set; }
        public  virtual IxCode   IxCode { get; set; }

        public  virtual Unit Unit { get; set; }
    }
}