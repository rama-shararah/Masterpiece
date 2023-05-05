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

namespace MasterPieceMVC.Controllers
{
    public class ServicesController : Controller
    {
        private MyMasterPieceEntities db = new MyMasterPieceEntities();

        // GET: Services
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }
        public ActionResult HomePage()
        {
            return View(db.Services.ToList());
        }

        [Authorize]
        public ActionResult Form()
        {
            return View(db.Services.ToList());
        }


        [Authorize(Roles = "Admin")]
        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        [Authorize(Roles = "Admin")]
        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Service_Id,Service_Name,Service_Photo,Slider_Photo")] Service service, HttpPostedFileBase SliderPic, HttpPostedFileBase ServicePic)
        {

            if (ModelState.IsValid)
            {
                if (SliderPic != null)
                {
                    string pathpic = Path.GetFileName(SliderPic.FileName);
                    SliderPic.SaveAs(Path.Combine(Server.MapPath("~/pic/"), SliderPic.FileName));
                    service.Slider_Photo = pathpic;
                }

                if (ServicePic != null)
                {
                    string pathpic2 = Path.GetFileName(ServicePic.FileName);
                    ServicePic.SaveAs(Path.Combine(Server.MapPath("~/pic/"), ServicePic.FileName));
                    service.Service_Photo = pathpic2;
                }



                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: Services/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            Session["Slider_Photo"] = service.Slider_Photo;
            Session["Service_Photo"] = service.Service_Photo;
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Service_Id,Service_Name,Service_Photo,Slider_Photo")] Service service ,HttpPostedFileBase SliderPic, HttpPostedFileBase ServicePic)
        {
            if (ModelState.IsValid)
            {
                service.Slider_Photo = Session["Slider_Photo"].ToString();
                service.Service_Photo = Session["Service_Photo"].ToString();

                if (SliderPic != null)
                {
                   string pathpic = Path.GetFileName(SliderPic.FileName);
                    SliderPic.SaveAs(Path.Combine(Server.MapPath("~/pic/"), SliderPic.FileName));
                    service.Slider_Photo = pathpic;
                }

                if (ServicePic != null)
                {
                    string pathpic2 = Path.GetFileName(ServicePic.FileName);
                    ServicePic.SaveAs(Path.Combine(Server.MapPath("~/pic/"), ServicePic.FileName));
                    service.Service_Photo = pathpic2;
                }
            
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }


        [Authorize(Roles = "Admin")]
        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
        
        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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
