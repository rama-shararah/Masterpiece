using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterPieceMVC.Models;
using Microsoft.AspNet.Identity;

namespace MasterPieceMVC.Controllers
{
    public class RequestsController : Controller
    {
        private MyMasterPieceEntities db = new MyMasterPieceEntities();

        // GET: Requests
        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.AspNetUser).Include(r => r.Subscriper);
            return View(requests.ToList());
        }

        public ActionResult Request()
        {

            string userId = User.Identity.GetUserId();
            var requests = db.Requests.Where(r=>r.Subscriper.userId== userId).Include(r => r.AspNetUser).Include(r => r.Subscriper);
            return View(requests.ToList());
        }

  

        public ActionResult Map(int? id)
        {

            return View(db.Requests.FirstOrDefault(x => x.Request_Id == id));
        }

        [HttpPost]
        public ActionResult SaveLocation([Bind(Include = "Request_Id,Request_Date,Lantitude,Longtitude,userId,Subscriper_Id")] Request request, double lat, double lng)
        {
            DateTime currentDate = DateTime.Now;
            string userId = User.Identity.GetUserId();

            decimal latt = Convert.ToDecimal(lat);
            decimal lngg = Convert.ToDecimal(lng);
            // TODO: Save location to database or perform other processing
            Request geo = new Request
            {
                Lantitude = latt,
                Longtitude = lngg,
                Request_Date = currentDate,
                userId = userId,
                Subscriper_Id = request.Subscriper_Id,

            };
            db.Requests.Add(geo);
            db.SaveChanges();
            return RedirectToAction("HomePage", "Services"); 
        }




        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Subscriper_Id = new SelectList(db.Subscripers, "Subscriper_Id", "userId");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Request_Id,Request_Date,Lantitude,Longtitude,userId,Subscriper_Id")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", request.userId);
            ViewBag.Subscriper_Id = new SelectList(db.Subscripers, "Subscriper_Id", "userId", request.Subscriper_Id);
            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", request.userId);
            ViewBag.Subscriper_Id = new SelectList(db.Subscripers, "Subscriper_Id", "userId", request.Subscriper_Id);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Request_Id,Request_Date,Lantitude,Longtitude,userId,Subscriper_Id")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", request.userId);
            ViewBag.Subscriper_Id = new SelectList(db.Subscripers, "Subscriper_Id", "userId", request.Subscriper_Id);
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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
