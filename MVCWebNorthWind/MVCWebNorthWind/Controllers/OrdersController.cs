using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebNorthWind.Models;

namespace MVCWebNorthWind.Controllers
{
    /// <summary>
    /// Class OrdersController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class OrdersController : Controller
    {
        /// <summary>
        /// The database
        /// </summary>
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Orders
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customers).Include(o => o.Employees).Include(o => o.Shippers);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName");
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName");
            return View();
        }

        // POST: Orders/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        /// <summary>
        /// Creates the specified orders.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", orders.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", orders.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", orders.ShipVia);
            return View(orders);
        }

        // GET: Orders/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", orders.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", orders.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", orders.ShipVia);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        /// <summary>
        /// Edits the specified orders.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", orders.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", orders.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", orders.ShipVia);
            return View(orders);
        }

        // GET: Orders/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 釋放 Unmanaged 資源並選擇性釋放 Managed 資源。
        /// </summary>
        /// <param name="disposing">true 表示釋放 Managed 和 Unmanaged 資源；false 則表示只釋放 Unmanaged 資源。</param>
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
