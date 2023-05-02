using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MasterPieceMVC.Models;
using Microsoft.AspNet.Identity;

namespace MasterPieceMVC.Controllers
{
    public class PricesController : Controller
    {
        private MyMasterPieceEntities db = new MyMasterPieceEntities();

        // GET: Prices
        public ActionResult Index()
        {
            return View(db.Prices.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay([Bind(Include = "Price_Id,Duration,Price1")] Price price, decimal payment)
        {
            string userId = User.Identity.GetUserId();
            var roleId = db.AspNetUserRoles.FirstOrDefault(x => x.UserId == userId);
            

            DateTime currentDate = DateTime.Now.Date;
            DateTime end = currentDate.AddDays((double)price.Duration);
            if (roleId.RoleId == "2")
            {
                var shown = db.Subscripers.SingleOrDefault(x => x.userId == userId);
                var update = db.Subscriptions.SingleOrDefault(x => x.userId == userId);
                shown.Shown = true;
                update.Subscription_Amount = payment;
                update.Subscription_Duration = price.Duration;
                update.Subscription_Beg = currentDate;
                update.Subscription_End = end;
                db.SaveChanges();
                return RedirectToAction("SubProfile", "Subscripers");

            }
            else { 
            Subscription subscription = new Subscription
            {
                Subscription_Amount= payment,
                Subscription_Duration= price.Duration,
                Subscription_Beg= currentDate,
                Subscription_End = end,
                userId = userId,


            };

            if (ModelState.IsValid)
            {

                db.Subscriptions.Add(subscription);

                db.SaveChanges();
            }
           

            //var role = db.AspNetUserRoles.Where(s => s.UserId.Equals(userId)).Single();
            //role.RoleId = "2";
            var userRole = db.AspNetUserRoles.SingleOrDefault(x => x.UserId == userId);
            if (userRole != null && userRole.RoleId=="3")
            {
                db.AspNetUserRoles.Remove(userRole);
                db.SaveChanges();
                db.AspNetUserRoles.Add(new AspNetUserRole { UserId = userId, RoleId = "2" });
                db.SaveChanges();
            }



           
           
            return RedirectToAction("Form", "Services");
            }

        }

        public ActionResult IndexUser()
        {
            Session.Remove("return");
            return View(db.Prices.ToList());
        }

        // GET: Prices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // GET: Prices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Price_Id,Duration,Price1")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(price);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(price);
        }

        // GET: Prices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Price_Id,Duration,Price1")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(price);
        }

        // GET: Prices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Price price = db.Prices.Find(id);
            db.Prices.Remove(price);
            db.SaveChanges();
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
