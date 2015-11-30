using Anbar.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Anbar.DAL
{
    public class InventoryContext:DbContext
    {
        public InventoryContext() : base("InventoryContext")
        {
        }

        public DbSet <ProductCategory> ProductCategories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<IxCode> IxCodes { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

       // public System.Data.Entity.DbSet<Anbar.ViewModels.EntryTransaction> EntryTransactions { get; set; }

        public System.Data.Entity.DbSet<Anbar.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<Anbar.Models.Department> Departments { get; set; }
    }
}