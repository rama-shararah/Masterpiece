using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterPieceMVC.Models;
using Microsoft.AspNet.Identity;

namespace MasterPieceMVC.Controllers
{
    public class AspNetUsersController : Controller
    {
        private MyMasterPieceEntities db = new MyMasterPieceEntities();

        // GET: AspNetUsers
        public ActionResult Index()
        {
            return View(db.AspNetUsers.Where(u => u.AspNetUserRoles.Any(ur => ur.RoleId == "3")).ToList());
        }
        public ActionResult UserProfile()
        {
            var user = User.Identity.GetUserId();
            var users = db.AspNetUsers.FirstOrDefault(x => x.Id == user);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        public ActionResult EditUserProfile()
        {
            var user = User.Identity.GetUserId();
            var users = db.AspNetUsers.FirstOrDefault(x => x.Id == user);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserProfile([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Photo,Location")] AspNetUser aspNetUser, HttpPostedFileBase pic)
        {

            var user = User.Identity.GetUserId();
            var updateUser = db.AspNetUsers.FirstOrDefault(x => x.Id == user);


            if (ModelState.IsValid)
            {
                if (pic != null)
                {
                    string pathpic = Path.GetFileName(pic.FileName);
                    pic.SaveAs(Path.Combine(Server.MapPath("~/pic/"), pic.FileName));

                }

                if (pic != null)
                {
                    updateUser.Photo = Path.GetFileName(pic.FileName);
                }
                updateUser.Location = aspNetUser.Location;
                updateUser.PhoneNumber = aspNetUser.PhoneNumber;



                db.SaveChanges();

            }



            return RedirectToAction("UserProfile", "AspNetUsers");//impoort
        }


        // GET: AspNetUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // GET: AspNetUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Photo,Location")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUsers.Add(aspNetUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspNetUser);
        }

        // GET: AspNetUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Photo,Location")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetUser);
        }

        // GET: AspNetUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUser);
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
