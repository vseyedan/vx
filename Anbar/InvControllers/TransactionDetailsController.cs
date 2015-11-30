using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Anbar.DAL;
using Anbar.Models;
using Anbar.ViewModels;

namespace Anbar.InvControllers
{
    public class TransactionDetailsController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: TransactionDetails
        public async Task<ActionResult> Index()
        {
            var transactionDetails = db.TransactionDetails.Include(t => t.Inventory).Include(t => t.Product).Include(t => t.Transaction);
            return View(await transactionDetails.ToListAsync());
        }

        // GET: TransactionDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionDetail transactionDetail = await db.TransactionDetails.FindAsync(id);
            if (transactionDetail == null)
            {
                return HttpNotFound();
            }
            return View(transactionDetail);
        }

        // GET: TransactionDetails/Create
        public ActionResult Create(int? id, bool? PlusSign, bool? chkboxEnbl)
        {
var prod = db.Products
//.Where(s => s.ID  == null)
.ToList()
.Select(s => new
{
ID = s.ID,
ProductDescription = s.ProductCode + " -- " + s.ProductName
});
            if (id == null)
            {
                ViewBag.TransactionID = new SelectList(db.Transactions, "ID", "TransactionNo");
            }
            else
            {
                Transaction Tr = db.Transactions.Find(id);
                ViewBag.TrID = Tr.ID;   
                ViewBag.TransactionID = new SelectList(db.Transactions.Where(x=>x.ID==Tr.ID), "ID", "TransactionNo", Tr.ID);
            }
           
            ViewBag.PlusMinusSign = PlusSign;

            if (chkboxEnbl != null)
            {
                ViewBag.ChkDisabled = !chkboxEnbl;
            }
            else
            {
                ViewBag.ChkDisabled = true;
            }
            
            ViewBag.InventoryID = new SelectList(db.Inventories, "ID", "InventoryName");
            //db.Products to prod , productCode to ProductDescription

            ViewBag.ProductID = new SelectList(prod, "ID", "ProductDescription");
            
            return View();
        }

        // POST: TransactionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TransactionID,ProductID,InventoryID,PlusMinusSign,Quantity,UnitPrice,ComputedTotalPrice,TotalPrice,ComputedUnitPrice")] TransactionDetail transactionDetail)
        {
            if (ModelState.IsValid)
            {
                db.TransactionDetails.Add(transactionDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryID = new SelectList(db.Inventories, "ID", "InventoryName", transactionDetail.InventoryID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductCode", transactionDetail.ProductID);
            ViewBag.TransactionID = new SelectList(db.Transactions, "ID", "TransactionNo", transactionDetail.TransactionID);
            return View(transactionDetail);
        }

        // GET: TransactionDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionDetail transactionDetail = await db.TransactionDetails.FindAsync(id);
            if (transactionDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryID = new SelectList(db.Inventories, "ID", "InventoryName", transactionDetail.InventoryID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductCode", transactionDetail.ProductID);
            ViewBag.TransactionID = new SelectList(db.Transactions, "ID", "TransactionNo", transactionDetail.TransactionID);
            return View(transactionDetail);
        }

        // POST: TransactionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TransactionID,ProductID,InventoryID,PlusMinusSign,Quantity,UnitPrice,ComputedTotalPrice,TotalPrice,ComputedUnitPrice")] TransactionDetail transactionDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InventoryID = new SelectList(db.Inventories, "ID", "InventoryName", transactionDetail.InventoryID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductCode", transactionDetail.ProductID);
            ViewBag.TransactionID = new SelectList(db.Transactions, "ID", "TransactionNo", transactionDetail.TransactionID);
            return View(transactionDetail);
        }

        // GET: TransactionDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionDetail transactionDetail = await db.TransactionDetails.FindAsync(id);
            if (transactionDetail == null)
            {
                return HttpNotFound();
            }
            return View(transactionDetail);
        }

        // POST: TransactionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TransactionDetail transactionDetail = await db.TransactionDetails.FindAsync(id);
            db.TransactionDetails.Remove(transactionDetail);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }





        //Added Code
        public ActionResult CreateCas()
        {
            //  var vm = new TransactioDetialCasViewModels();
            // vm.ProductCategory = ;
            var prod =    db.Products
     //.Where(s => s.ID  == null)
     .ToList()
     .Select(s => new
     {
         ID = s.ID,
         ProductDescription = s.ProductCode + " -- "+ s.ProductName
     });

            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "CategoryName");
            ViewBag.IxCodeID = new SelectList(db.IxCodes, "ID", "IxCodeName");

//Code Above has been added


            ViewBag.InventoryID = new SelectList(db.Inventories, "ID", "InventoryName");
            ViewBag.ProductID = new SelectList(prod, "ID", "ProductDescription");
            ViewBag.TransactionID = new SelectList(db.Transactions, "ID", "TransactionNo");
            return View();
        }

        // POST: TransactionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCas([Bind(Include = "ID,TransactionID,ProductID,InventoryID,PlusMinusSign,Quantity,UnitPrice,ComputedTotalPrice,TotalPrice,ComputedUnitPrice")] TransactionDetail transactionDetail)
        {
            if (ModelState.IsValid)
            {
                db.TransactionDetails.Add(transactionDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryID = new SelectList(db.Inventories, "ID", "InventoryName", transactionDetail.InventoryID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductCode", transactionDetail.ProductID);
            ViewBag.TransactionID = new SelectList(db.Transactions, "ID", "TransactionNo", transactionDetail.TransactionID);
            return View(transactionDetail);
        }
    }
}
