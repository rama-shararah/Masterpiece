using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MasterPieceMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact()
        {

            string name = Request.Form["name"];
            string emailAddress = Request.Form["emailAddress"];
            string message = Request.Form["message"];

            MailMessage mail = new MailMessage();
            mail.To.Add("ramashararah00@gmail.com");
            mail.From = new MailAddress(emailAddress);
            mail.Subject = "Contact";

            mail.Body = message;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("ramashararah00@gmail.com", "kmepdrnobvrooyrk");
            smtp.Send(mail);

            return RedirectToAction("Index", "Contact");



        }
    }
}