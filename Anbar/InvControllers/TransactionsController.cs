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

namespace Anbar.InvControllers
{
    public class TransactionsController : Controller
    {
  

        private InventoryContext db = new InventoryContext();

        // GET: Transactions
        public async Task<ActionResult> Index()
        {
            var transactions = db.Transactions.Include(t => t.Entry_Supplier).Include(t => t.Exit_Department);
            return View(await transactions.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create(int? tTypeID)
        {
            //var x = Enum.GetValues(typeof(TransactionType))
            //       .Cast<TransactionType>()
            //       .Where(e => e == TransactionType.خروج);
            //var SelList = Enum.GetValues(typeof(TransactionType))
            //       .Cast<TransactionType>()
            //       .Where(e => e == TransactionType.خروج)
            //       .Select(e => new SelectListItem
            //       {
            //           Value = ((int)e).ToString(),
            //           Text = e.ToString()
            //       });
            //ViewBag.TransctionType = new SelectList(SelList, "ID", "Name");

            

            ViewBag.TransactionType = tTypeID;
            ViewBag.TranType = tTypeID.ToString();

            ViewBag.Entry_SupplierID = new SelectList(db.Suppliers, "ID", "SupplierName");
            ViewBag.Exit_DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TransactionType,TransactionNo,TransactionDate,Entry_SupplierID,Exit_DepartmentID")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Entry_SupplierID = new SelectList(db.Suppliers, "ID", "SupplierName", transaction.Entry_SupplierID);
            ViewBag.Exit_DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName", transaction.Exit_DepartmentID);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.Entry_SupplierID = new SelectList(db.Suppliers, "ID", "SupplierName", transaction.Entry_SupplierID);
            ViewBag.Exit_DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName", transaction.Exit_DepartmentID);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TransactionType,TransactionNo,TransactionDate,Entry_SupplierID,Exit_DepartmentID")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Entry_SupplierID = new SelectList(db.Suppliers, "ID", "SupplierName", transaction.Entry_SupplierID);
            ViewBag.Exit_DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName", transaction.Exit_DepartmentID);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transaction transaction = await db.Transactions.FindAsync(id);
            db.Transactions.Remove(transaction);
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
    }
}
