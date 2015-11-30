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
        //Added Enum
        public enum TransactionType
        {
            ورود, خروج, انتقال
        }



        private InventoryContext db = new InventoryContext();

        // GET: Transactions
        public async Task<ActionResult> Index()
        {
            return View(await db.Transactions.ToListAsync());
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
            ViewBag.TransactionType = tTypeID;
            ViewBag.TranType = tTypeID.ToString();
            //Create(TransactionType tType)
            //if (tType != null)
            //{
            //Transaction tran = new Transaction();
            //tran.TransactionType = tType;
            //    ViewBag.TransactionType = tType;
            //}
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




        //Added Tansaction Creation Actions
        //Added Tansaction Creation Actions
        //Added Tansaction Creation Actions




        public ActionResult CreateEntryTran()
        {
            ViewBag.TransactionType = TransactionType.ورود;

            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateEntryTran([Bind(Include = "ID,TransactionType,TransactionNo,TransactionDate,Entry_SupplierID")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }



        public ActionResult CreateExitTran()
        {
           // var enumValues = from TransactionType t in Enum.GetValues(typeof(TransactionType))
                 //            select new { Name=t.ToString()}  ;
            
           // var enumValues = Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>()
            //                                             .Select(e => new KeyValuePair<byte, string>((byte)e, e.ToString()));
            //var sList = new SelectList(enumValues, "Name", "Name");
            //object sl = new SelectList()
         //   string sl = (from TransactionType s in Enum.GetValues(typeof(TransactionType))
         //                select Enum.GetName(typeof(TransactionType),) ;

          //  ViewBag.TransactionType = new SelectList(enumValues,"Key","Value",new SelectListItem {Text="انتقال" }.Selected );

           // var TransactionType = new SelectList(Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>().Select(v => new SelectListItem;

            //var values = from TransactionType t in Enum.GetValues(typeof(TransactionType))
            //             select new { Id = t, Name = t.ToString() };
            //var EnumValues = Enum.GetValues(typeof(TransactionType)).Cast<Object>();

            //ViewBag.TransactionType = new SelectList( values, "Id", "Name",EnumValues.Last());
            //TransactionType.خروج;

            return View("Create");
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateExitTran([Bind(Include = "ID,TransactionType,TransactionNo,TransactionDate,Entry_SupplierID,Exit_DepartmentID")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }





        public ActionResult CreateTransferTran()
        {
            ViewBag.TransactionType = TransactionType.انتقال;

            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTransferTran([Bind(Include = "ID,TransactionType,TransactionNo,TransactionDate,Entry_SupplierID,Exit_DepartmentID")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }
    }
}
