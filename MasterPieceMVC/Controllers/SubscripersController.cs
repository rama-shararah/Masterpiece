using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            var subscriper = db.Subscripers.FirstOrDefault(x => x.userId == user);
            if (subscriper == null)
            {
                return HttpNotFound();
            }
            return View(subscriper);
        }

        public ActionResult EditSubProfile()
        {
            var user = User.Identity.GetUserId();
            var subscriper = db.Subscripers.FirstOrDefault(x => x.userId == user);
            if (subscriper == null)
            {
                return HttpNotFound();
            }
            return View(subscriper);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubProfile([Bind(Include = "Subscriper_Id,userId,First_Name,Last_Name,Subscriper_Photo,Service_Id,Location,Service_Description,Beg_Time,End_Time,Status,Shown,AverageHourlyRate")] Subscriper subscriper, HttpPostedFileBase pic, string PhoneNumber, string Location)
        {
            
                var user = User.Identity.GetUserId();
                var sub = db.Subscripers.FirstOrDefault(x => x.userId == user);
            var updateUser = db.AspNetUsers.FirstOrDefault(x => x.Id == user);

             
            if (ModelState.IsValid)
                {
                    if (pic != null)
                    {
                        string pathpic = Path.GetFileName(pic.FileName);
                        pic.SaveAs(Path.Combine(Server.MapPath("~/pic/"), pic.FileName));

                    }





                    sub.First_Name = subscriper.First_Name;
                    sub.Last_Name = subscriper.Last_Name;
                    sub.userId = user;
                if(pic != null) {
                    sub.Subscriper_Photo = Path.GetFileName(pic.FileName);
                }
                sub.Service_Id = subscriper.Service_Id;
                    sub.Service_Description = subscriper.Service_Description;
                    sub.Beg_Time = subscriper.Beg_Time;
                    sub.End_Time = subscriper.End_Time;
                    sub.AverageHourlyRate = subscriper.AverageHourlyRate;
                    updateUser.Location = Location;
                    updateUser.PhoneNumber = PhoneNumber;



                    db.SaveChanges();

                }

            
   
            return RedirectToAction("SubProfile", "Subscripers");
        }

        [HttpPost]
        public ActionResult UpdateValue(string selectedValue)
        {
            // Update the database value here
            var user = User.Identity.GetUserId();
            var subscriper = db.Subscripers.FirstOrDefault(x => x.userId == user);
           bool value =  Convert.ToBoolean(selectedValue);
            subscriper.Status = value;
            db.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewSub([Bind(Include = "Subscriper_Id,userId,First_Name,Last_Name,Subscriper_Photo,Service_Id,Location,Service_Description,Beg_Time,End_Time,Status,Shown,AverageHourlyRate")] Subscriper subscriper, HttpPostedFileBase pic)
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
                    AverageHourlyRate= subscriper.AverageHourlyRate,
                };

                db.Subscripers.Add(sub);
                db.SaveChanges();
                    string Email = User.Identity.GetUserName();

                    MailMessage mail = new MailMessage();
                    mail.To.Add(Email);
                    mail.From = new MailAddress("ramashararah00@gmail.com");
                    mail.Subject = "becoming subscriber";
                    mail.Body = $"<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional //EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html\r\n  xmlns=\"http://www.w3.org/1999/xhtml\"\r\n  xmlns:v=\"urn:schemas-microsoft-com:vml\"\r\n  xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n>\r\n  <head>\r\n    <!--[if gte mso 9]>\r\n      <xml>\r\n        <o:OfficeDocumentSettings>\r\n          <o:AllowPNG />\r\n          <o:PixelsPerInch>96</o:PixelsPerInch>\r\n        </o:OfficeDocumentSettings>\r\n      </xml>\r\n    <![endif]-->\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <meta name=\"x-apple-disable-message-reformatting\" />\r\n    <!--[if !mso]><!-->\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />\r\n    <!--<![endif]-->\r\n    <title></title>\r\n\r\n    <style type=\"text/css\">\r\n      @media only screen and (min-width: 620px) {{\r\n        .u-row {{\r\n          width: 600px !important;\r\n        }}\r\n        .u-row .u-col {{\r\n          vertical-align: top;\r\n        }}\r\n\r\n        .u-row .u-col-100 {{\r\n          width: 600px !important;\r\n        }}\r\n      }}\r\n\r\n      @media (max-width: 620px) {{\r\n        .u-row-container {{\r\n          max-width: 100% !important;\r\n          padding-left: 0px !important;\r\n          padding-right: 0px !important;\r\n        }}\r\n        .u-row .u-col {{\r\n          min-width: 320px !important;\r\n          max-width: 100% !important;\r\n          display: block !important;\r\n        }}\r\n        .u-row {{\r\n          width: 100% !important;\r\n        }}\r\n        .u-col {{\r\n          width: 100% !important;\r\n        }}\r\n        .u-col > div {{\r\n          margin: 0 auto;\r\n        }}\r\n      }}\r\n      body {{\r\n        margin: 0;\r\n        padding: 0;\r\n      }}\r\n\r\n      table,\r\n      tr,\r\n      td {{\r\n        vertical-align: top;\r\n        border-collapse: collapse;\r\n      }}\r\n\r\n      p {{\r\n        margin: 0;\r\n      }}\r\n\r\n      .ie-container table,\r\n      .mso-container table {{\r\n        table-layout: fixed;\r\n      }}\r\n\r\n      * {{\r\n        line-height: inherit;\r\n      }}\r\n\r\n      a[x-apple-data-detectors=\"true\"] {{\r\n        color: inherit !important;\r\n        text-decoration: none !important;\r\n      }}\r\n\r\n      table,\r\n      td {{\r\n        color: #000000;\r\n      }}\r\n      @media (max-width: 480px) {{\r\n        #u_content_text_1 .v-container-padding-padding {{\r\n          padding: 40px 10px 10px !important;\r\n        }}\r\n        #u_content_text_2 .v-container-padding-padding {{\r\n          padding: 8px 10px 40px !important;\r\n        }}\r\n      }}\r\n    </style>\r\n\r\n    <!--[if !mso]><!-->\r\n    <link\r\n      href=\"https://fonts.googleapis.com/css?family=Montserrat:400,700&display=swap\"\r\n      rel=\"stylesheet\"\r\n      type=\"text/css\"\r\n    />\r\n    <link\r\n      href=\"https://fonts.googleapis.com/css?family=Pacifico&display=swap\"\r\n      rel=\"stylesheet\"\r\n      type=\"text/css\"\r\n    />\r\n    <!--<![endif]-->\r\n  </head>\r\n\r\n  <body\r\n    class=\"clean-body u_body\"\r\n    style=\"\r\n      margin: 0;\r\n      padding: 0;\r\n      -webkit-text-size-adjust: 100%;\r\n      background-color: #ffffff;\r\n      color: #000000;\r\n    \"\r\n  >\r\n    <!--[if IE]><div class=\"ie-container\"><![endif]-->\r\n    <!--[if mso]><div class=\"mso-container\"><![endif]-->\r\n    <table\r\n      style=\"\r\n        border-collapse: collapse;\r\n        table-layout: fixed;\r\n        border-spacing: 0;\r\n        mso-table-lspace: 0pt;\r\n        mso-table-rspace: 0pt;\r\n        vertical-align: top;\r\n        min-width: 320px;\r\n        margin: 0 auto;\r\n        background-color: #ffffff;\r\n        width: 100%;\r\n      \"\r\n      cellpadding=\"0\"\r\n      cellspacing=\"0\"\r\n    >\r\n      <tbody>\r\n        <tr style=\"vertical-align: top\">\r\n          <td\r\n            style=\"\r\n              word-break: break-word;\r\n              border-collapse: collapse !important;\r\n              vertical-align: top;\r\n            \"\r\n          >\r\n            <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\" style=\"background-color: #ffffff;\"><![endif]-->\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #2f3031;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: #2f3031;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div style=\"height: 100%; width: 100% !important\">\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: transparent;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: transparent;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #2f3031;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-image: url('%20');\r\n                    background-repeat: no-repeat;\r\n                    background-position: center top;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-image: url('%20');background-repeat: no-repeat;background-position: center top;background-color: #2f3031;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #fbfbfb;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: #fbfbfb;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <table\r\n                          id=\"u_content_text_1\"\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 50px 35px 10px 40px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    color: #000000;\r\n                                    line-height: 180%;\r\n                                    text-align: left;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                >\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      >Dear {Email},</span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      >We are pleased to inform you that you\r\n                                      have been accepted into [University Name]\r\n                                      for the upcoming academic year.\r\n                                      Congratulations on this outstanding\r\n                                      achievement! Your application stood out\r\n                                      among many others due to your exceptional\r\n                                      academic record, your strong\r\n                                      extracurricular activities, and your\r\n                                      commitment to excellence. Our admissions\r\n                                      committee was impressed by your\r\n                                      intellectual curiosity, your dedication to\r\n                                      your chosen field of study, and your\r\n                                      potential to make a significant impact in\r\n                                      your future career. As a student at\r\n                                      [University Name], you will have the\r\n                                      opportunity to learn from some of the most\r\n                                      distinguished faculty in the country,\r\n                                      engage in cutting-edge research, and\r\n                                      collaborate with a diverse community of\r\n                                      scholars from around the world. We are\r\n                                      confident that you will thrive in our\r\n                                      challenging academic environment and make\r\n                                      the most of the many resources and\r\n                                      opportunities that our university has to\r\n                                      offer. We encourage you to review the\r\n                                      information included in your acceptance\r\n                                      package carefully, as it contains\r\n                                      important information about your next\r\n                                      steps. Please submit your acceptance of\r\n                                      our offer as soon as possible to secure\r\n                                      your place in our incoming class. If you\r\n                                      have any questions or concerns, please do\r\n                                      not hesitate to contact us at [contact\r\n                                      information]. Once again, congratulations\r\n                                      on your acceptance to [University Name].\r\n                                      We look forward to welcoming you to our\r\n                                      community and watching you achieve your\r\n                                      academic and professional goals.</span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      >Sincerely,</span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      >UniCat Admissions Committee</span\r\n                                    >\r\n                                  </p>\r\n                                </div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <table\r\n                          id=\"u_content_text_2\"\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 8px 35px 40px 40px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    color: #000000;\r\n                                    line-height: 180%;\r\n                                    text-align: left;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                >\r\n                                  <p style=\"line-height: 180%; font-size: 14px\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-family: Montserrat, sans-serif;\r\n                                        font-size: 16px;\r\n                                        line-height: 28.8px;\r\n                                      \"\r\n                                      >If you have any questions, please feel\r\n                                      free to contact me directly.</span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"font-size: 14px; line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 16px;\r\n                                        line-height: 28.8px;\r\n                                        font-family: Montserrat, sans-serif;\r\n                                      \"\r\n                                      >Looking forward to your reply,</span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%; font-size: 14px\">\r\n                                    <br /><span\r\n                                      style=\"\r\n                                        font-size: 16px;\r\n                                        line-height: 28.8px;\r\n                                        font-family: Montserrat, sans-serif;\r\n                                      \"\r\n                                      >Yours sincerely,</span\r\n                                    ><br /><span\r\n                                      style=\"\r\n                                        font-size: 18px;\r\n                                        line-height: 32.4px;\r\n                                      \"\r\n                                      ><span\r\n                                        style=\"\r\n                                          line-height: 32.4px;\r\n                                          font-family: Pacifico, cursive;\r\n                                          font-size: 18px;\r\n                                        \"\r\n                                        >UniCat</span\r\n                                      ></span\r\n                                    >\r\n                                  </p>\r\n                                </div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <table\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 0px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <table\r\n                                  width=\"100%\"\r\n                                  cellpadding=\"0\"\r\n                                  cellspacing=\"0\"\r\n                                  border=\"0\"\r\n                                >\r\n                                  <tr>\r\n                                    <td\r\n                                      style=\"\r\n                                        padding-right: 0px;\r\n                                        padding-left: 0px;\r\n                                      \"\r\n                                      align=\"center\"\r\n                                    >\r\n                                      <img\r\n                                        align=\"center\"\r\n                                        border=\"0\"\r\n                                        src=\"https://cdn.templates.unlayer.com/assets/1638520170619-12.png\" \r\n                                        alt=\"border\"\r\n                                        title=\"border\"\r\n                                        style=\"\r\n                                          outline: none;\r\n                                          text-decoration: none;\r\n                                          -ms-interpolation-mode: bicubic;\r\n                                          clear: both;\r\n                                          display: inline-block !important;\r\n                                          border: none;\r\n                                          height: auto;\r\n                                          float: none;\r\n                                          width: 100%;\r\n                                          max-width: 600px;\r\n                                        \"\r\n                                        width=\"600\"\r\n                                      />\r\n                                    </td>\r\n                                  </tr>\r\n                                </table>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #2f2f2f;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-image: url('%20');\r\n                    background-repeat: no-repeat;\r\n                    background-position: center top;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-image: url('%20');background-repeat: no-repeat;background-position: center top;background-color: #2f2f2f;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: transparent;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: transparent;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <table\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 20px 10px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    color: #6f7a7a;\r\n                                    line-height: 140%;\r\n                                    text-align: center;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                ></div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <!--[if (mso)|(IE)]></td></tr></table><![endif]-->\r\n          </td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n    <!--[if mso]></div><![endif]-->\r\n    <!--[if IE]></div><![endif]-->\r\n  </body>\r\n</html>\r\n";

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 587; // 25 465
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Credentials = new System.Net.NetworkCredential("ramashararah00@gmail.com", "kmepdrnobvrooyrk");
                    smtp.Send(mail);
                }
          
            }
            catch(Exception e)
            {
                Response.Write(e.Message);
            }
            return RedirectToAction("SubProfile", "Subscripers");
        }
           



        public ActionResult AllSub(int id)
        {
            var subscripers = db.Subscripers.Where(s => s.Service_Id==id).Where(s=>s.Shown==true).Where(s=>s.Status==true).Include(s => s.AspNetUser).Include(s => s.Service);
            return View(subscripers.ToList());
        }

        public ActionResult SingleSub(int? id)
        {
            Session.Remove("id");
            var subscripers = db.Subscripers.Find(id);
            return View(subscripers);
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
