using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCCWebApps.Models;

namespace MCCWebApps.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transactions
        public async Task<ActionResult> Index()
        {
            var transactions = db.Transactions.Include(t => t.Product).Include(t => t.Supplier);
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
        public ActionResult Create()
        {
            ViewBag.id_product = new SelectList(db.Products, "Id", "nm_product");
            ViewBag.id_supplier = new SelectList(db.Suppliers, "Id", "Name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nota,qty,total,created_at,id_product,id_supplier")] Transaction transaction)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Transactions.Add(transaction);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewBag.id_product = new SelectList(db.Products, "Id", "nm_product", transaction.id_product);
                ViewBag.id_supplier = new SelectList(db.Suppliers, "Id", "Name", transaction.id_supplier);
                return View(transaction);
            } catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Transaction", "Create"));
            }
            
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
            ViewBag.id_product = new SelectList(db.Products, "Id", "nm_product", transaction.id_product);
            ViewBag.id_supplier = new SelectList(db.Suppliers, "Id", "Name", transaction.id_supplier);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Nota,qty,total,created_at,id_product,id_supplier")] Transaction transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(transaction).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.id_product = new SelectList(db.Products, "Id", "nm_product", transaction.id_product);
                ViewBag.id_supplier = new SelectList(db.Suppliers, "Id", "Name", transaction.id_supplier);
                return View(transaction);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Transaction", "Edit"));
            }            
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
            try
            {
                Transaction transaction = await db.Transactions.FindAsync(id);
                db.Transactions.Remove(transaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Transaction", "DeleteConfirmed"));
            }
            
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
