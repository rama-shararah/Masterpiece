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
    public class CommentsController : Controller
    {
        private MyMasterPieceEntities db = new MyMasterPieceEntities();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.AspNetUser).Include(c => c.Subscriper);
            return View(comments.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment([Bind(Include = "Comment_Id,userId,Subscriper_Id,Comment1,Comment_Date,Accept,Rate")] Comment comment, int rating)
        {
            DateTime currentDate = DateTime.Now;
            string userId = User.Identity.GetUserId();


            Comment NewComm = new Comment
            {
                userId = userId,
                Subscriper_Id = comment.Subscriper_Id,
                Comment1 = comment.Comment1,
                Comment_Date = currentDate,
                Rate= rating,

            };
            int subId = (int)comment.Subscriper_Id;
            db.Comments.Add(NewComm);
            db.SaveChanges();
            return RedirectToAction("SingleSub", "Subscripers", new { id = subId });
        }

      


        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Subscriper_Id = new SelectList(db.Subscripers, "Subscriper_Id", "userId");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Comment_Id,userId,Subscriper_Id,Comment1,Comment_Date,Accept,Rate")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", comment.userId);
            ViewBag.Subscriper_Id = new SelectList(db.Subscripers, "Subscriper_Id", "userId", comment.Subscriper_Id);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", comment.userId);
            ViewBag.Subscriper_Id = new SelectList(db.Subscripers, "Subscriper_Id", "userId", comment.Subscriper_Id);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Comment_Id,userId,Subscriper_Id,Comment1,Comment_Date,Accept,Rate")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", comment.userId);
            ViewBag.Subscriper_Id = new SelectList(db.Subscripers, "Subscriper_Id", "userId", comment.Subscriper_Id);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
