using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MasterPieceMVC.Models;
using Microsoft.AspNet.Identity;

namespace MasterPieceMVC.Controllers
{
    public class SubscripersController : Controller
    {
        private MyMasterPieceEntities db = new MyMasterPieceEntities();

        // GET: Subscripers
        public ActionResult Index()
        {
            var subscripers = db.Subscripers.Include(s => s.AspNetUser).Include(s => s.Service);
            return View(subscripers.ToList());
        }

        public ActionResult IndexUser()
        {
            var subscripers = db.Subscripers.Include(s => s.AspNetUser).Include(s => s.Service);
            return View(subscripers.ToList());
        }

        public ActionResult SubProfile()
        {
            var user = User.Identity.GetUserId();
            Subscriper subscriper = db.Subscripers.Find(user);
            if (subscriper == null)
            {
                return HttpNotFound();
            }
            return View(subscriper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewSub([Bind(Include = "Subscriper_Id,userId,First_Name,Last_Name,Subscriper_Photo,Service_Id,Location,Service_Description,Beg_Time,End_Time,Status,Shown")] Subscriper subscriper, HttpPostedFileBase pic)
        {
            try { 
            var user = User.Identity.GetUserId();


            if (ModelState.IsValid)
            {
                if (pic != null)
                {
                    string pathpic = Path.GetFileName(pic.FileName);
                    pic.SaveAs(Path.Combine(Server.MapPath("~/pic/"), pic.FileName));
              
                }

                Subscriper sub = new Subscriper
                {
                     
                    First_Name = subscriper.First_Name,
                    Last_Name = subscriper.Last_Name,
                    userId = user,
                    Subscriper_Photo= Path.GetFileName(pic.FileName),
                    Service_Id= subscriper.Service_Id,
                    Service_Description = subscriper.Service_Description,
                    Beg_Time = subscriper.Beg_Time,
                    End_Time = subscriper.End_Time,
                    Shown= true,
                };

                db.Subscripers.Add(sub);
                db.SaveChanges();
              
            }
          
            }
            catch(Exception e)
            {
                Response.Write(e.Message);
            }
            return RedirectToAction("HomePage", "Services");
        }
           
          
        

        public ActionResult Services(int id)
        {
            var subscripers = db.Subscripers.Where(s => s.Service_Id==id).Include(s => s.AspNetUser).Include(s => s.Service);
            return View(subscripers.ToList());
        }

        // GET: Subscripers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriper subscriper = db.Subscripers.Find(id);
            if (subscriper == null)
            {
                return HttpNotFound();
            }
            return View(subscriper);
        }

        // GET: Subscripers/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Service_Id = new SelectList(db.Services, "Service_Id", "Service_Name");
            return View();
        }

        // POST: Subscripers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subscriper_Id,userId,First_Name,Last_Name,Subscriper_Photo,Service_Id,Location,Service_Description,Beg_Time,End_Time,Status,Shown")] Subscriper subscriper)
        {
            if (ModelState.IsValid)
            {
                db.Subscripers.Add(subscriper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", subscriper.userId);
            ViewBag.Service_Id = new SelectList(db.Services, "Service_Id", "Service_Name", subscriper.Service_Id);
            return View(subscriper);
        }

        // GET: Subscripers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriper subscriper = db.Subscripers.Find(id);
            if (subscriper == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", subscriper.userId);
            ViewBag.Service_Id = new SelectList(db.Services, "Service_Id", "Service_Name", subscriper.Service_Id);
            return View(subscriper);
        }

        // POST: Subscripers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Subscriper_Id,userId,First_Name,Last_Name,Subscriper_Photo,Service_Id,Location,Service_Description,Beg_Time,End_Time,Status,Shown")] Subscriper subscriper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", subscriper.userId);
            ViewBag.Service_Id = new SelectList(db.Services, "Service_Id", "Service_Name", subscriper.Service_Id);
            return View(subscriper);
        }

        // GET: Subscripers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriper subscriper = db.Subscripers.Find(id);
            if (subscriper == null)
            {
                return HttpNotFound();
            }
            return View(subscriper);
        }

        // POST: Subscripers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscriper subscriper = db.Subscripers.Find(id);
            db.Subscripers.Remove(subscriper);
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
