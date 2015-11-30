using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anbar.Models
{
    public class TransactionDetail
    {
        public int ID { get; set; }
        [DisplayName("شماره برگه")]
        public int TransactionID { get; set; }
        [DisplayName("نام محصول")]
        public int ProductID { get; set; }

        [DisplayName("نام انبار")]
        public int InventoryID { get; set; }

        [DisplayName("علامت مثبت یا منفی")]
        public bool PlusMinusSign { get; set; }
        [DisplayName("مقدار")]
        public int Quantity { get; set; }

        [DisplayName("بهای واحد")]
        public int UnitPrice { get; set; }

        [DisplayName("بهای کل (محاسبه شده)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public long ComputedTotalPrice { get; set; }

        [DisplayName("بهای کل")]
        public long TotalPrice { get; set; }

        [DisplayName("بهای واحد (محاسبه شده)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int ComputedUnitPrice { get; set; }



        public virtual Transaction Transaction { get; set; }
        public virtual Product Product { get; set; }
        public virtual Inventory Inventory { get; set; }

    }
}