using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string search)
        {
            return View(db.Requests.Include(r => r.AspNetUser).Include(r => r.Subscriper).OrderByDescending(o => o.Request_Date).Where(x => x.Subscriper.AspNetUser.Email.Contains(search) || search == null).ToList());
           
        }

        [Authorize(Roles = "ServiceProvider")]
        public ActionResult Request()
        {

            string userId = User.Identity.GetUserId();
            var requests = db.Requests.Where(r=>r.Subscriper.userId== userId).OrderByDescending(o => o.Request_Date).Include(r => r.AspNetUser).Include(r => r.Subscriper);
            return View(requests.ToList());
        }

        [Authorize(Roles = "ServiceProvider")]
        public ActionResult EditSubRequest(int? id)
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

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubRequest([Bind(Include = "Request_Id,Request_Date,Lantitude,Longtitude,userId,Subscriper_Id,Accept")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;              
                db.SaveChanges();
                var id = request.userId;
                var asp = db.AspNetUsers.FirstOrDefault(x => x.Id == id);
                var Email = asp.Email;
                MailMessage mail = new MailMessage();
                mail.To.Add(Email);
                mail.From = new MailAddress("ramashararah00@gmail.com");
                mail.Subject = "حالة الطلب";
                mail.Body = $"<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional //EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html\r\n  xmlns=\"http://www.w3.org/1999/xhtml\"\r\n  xmlns:v=\"urn:schemas-microsoft-com:vml\"\r\n  xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n>\r\n  <head>\r\n    <!--[if gte mso 9]>\r\n      <xml>\r\n        <o:OfficeDocumentSettings>\r\n          <o:AllowPNG />\r\n          <o:PixelsPerInch>96</o:PixelsPerInch>\r\n        </o:OfficeDocumentSettings>\r\n      </xml>\r\n    <![endif]-->\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <meta name=\"x-apple-disable-message-reformatting\" />\r\n    <!--[if !mso]><!-->\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />\r\n    <!--<![endif]-->\r\n    <title></title>\r\n\r\n    <style type=\"text/css\">\r\n      @media only screen and (min-width: 620px) {{\r\n        .u-row {{\r\n          width: 600px !important;\r\n        }}\r\n        .u-row .u-col {{\r\n          vertical-align: top;\r\n        }}\r\n\r\n        .u-row .u-col-100 {{\r\n          width: 600px !important;\r\n        }}\r\n      }}\r\n\r\n      @media (max-width: 620px) {{\r\n        .u-row-container {{\r\n          max-width: 100% !important;\r\n          padding-left: 0px !important;\r\n          padding-right: 0px !important;\r\n        }}\r\n        .u-row .u-col {{\r\n          min-width: 320px !important;\r\n          max-width: 100% !important;\r\n          display: block !important;\r\n        }}\r\n        .u-row {{\r\n          width: 100% !important;\r\n        }}\r\n        .u-col {{\r\n          width: 100% !important;\r\n        }}\r\n        .u-col > div {{\r\n          margin: 0 auto;\r\n        }}\r\n      }}\r\n      body {{\r\n        margin: 0;\r\n        padding: 0;\r\n      }}\r\n\r\n      table,\r\n      tr,\r\n      td {{\r\n        vertical-align: top;\r\n        border-collapse: collapse;\r\n      }}\r\n\r\n      p {{\r\n        margin: 0;\r\n      }}\r\n\r\n      .ie-container table,\r\n      .mso-container table {{\r\n        table-layout: fixed;\r\n      }}\r\n\r\n      * {{\r\n        line-height: inherit;\r\n      }}\r\n\r\n      a[x-apple-data-detectors=\"true\"] {{\r\n        color: inherit !important;\r\n        text-decoration: none !important;\r\n      }}\r\n\r\n      table,\r\n      td {{\r\n        color: #000000;\r\n      }}\r\n      @media (max-width: 480px) {{\r\n        #u_content_text_1 .v-container-padding-padding {{\r\n          padding: 40px 10px 10px !important;\r\n        }}\r\n        #u_content_text_2 .v-container-padding-padding {{\r\n          padding: 8px 10px 40px !important;\r\n        }}\r\n      }}\r\n    </style>\r\n\r\n    <!--[if !mso]><!-->\r\n    <link\r\n      href=\"https://fonts.googleapis.com/css?family=Montserrat:400,700&display=swap\"\r\n      rel=\"stylesheet\"\r\n      type=\"text/css\"\r\n    />\r\n    <link\r\n      href=\"https://fonts.googleapis.com/css?family=Pacifico&display=swap\"\r\n      rel=\"stylesheet\"\r\n      type=\"text/css\"\r\n    />\r\n    <!--<![endif]-->\r\n  </head>\r\n\r\n  <body\r\n    class=\"clean-body u_body\"\r\n    style=\"\r\n      margin: 0;\r\n      padding: 0;\r\n      -webkit-text-size-adjust: 100%;\r\n      background-color: #ffffff;\r\n      color: #000000;\r\n    \"\r\n  >\r\n    <!--[if IE]><div class=\"ie-container\"><![endif]-->\r\n    <!--[if mso]><div class=\"mso-container\"><![endif]-->\r\n    <table\r\n      style=\"\r\n        border-collapse: collapse;\r\n        table-layout: fixed;\r\n        border-spacing: 0;\r\n        mso-table-lspace: 0pt;\r\n        mso-table-rspace: 0pt;\r\n        vertical-align: top;\r\n        min-width: 320px;\r\n        margin: 0 auto;\r\n        background-color: #ffffff;\r\n        width: 100%;\r\n      \"\r\n      cellpadding=\"0\"\r\n      cellspacing=\"0\"\r\n    >\r\n      <tbody>\r\n        <tr style=\"vertical-align: top\">\r\n          <td\r\n            style=\"\r\n              word-break: break-word;\r\n              border-collapse: collapse !important;\r\n              vertical-align: top;\r\n            \"\r\n          >\r\n            <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\" style=\"background-color: #ffffff;\"><![endif]-->\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #2f3031;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: #2f3031;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div style=\"height: 100%; width: 100% !important\">\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: transparent;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: transparent;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #2f3031;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-image: url('%20');\r\n                    background-repeat: no-repeat;\r\n                    background-position: center top;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-image: url('%20');background-repeat: no-repeat;background-position: center top;background-color: #2f3031;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #fbfbfb;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: #fbfbfb;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <table\r\n                          id=\"u_content_text_1\"\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 50px 35px 10px 40px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    color: #000000;\r\n                                    line-height: 180%;\r\n                                    text-align: left;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                >\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      >عزيزنا المشترك{Email},</span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      >نود اعلامك انه قد تم انتهاء اشتراكك في موقع مصلحكم عليك الاشتراك من جديد للاستفادة من الموقع شكرا لك على الاشتراك </span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      ></span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      ></span\r\n                                    >\r\n                                  </p>\r\n                                </div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <table\r\n                          id=\"u_content_text_2\"\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 8px 35px 40px 40px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    color: #000000;\r\n                                    line-height: 180%;\r\n                                    text-align: left;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                >\r\n                                  <p style=\"line-height: 180%; font-size: 14px\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-family: Montserrat, sans-serif;\r\n                                        font-size: 16px;\r\n                                        line-height: 28.8px;\r\n                                      \"\r\n                                      ></span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"font-size: 14px; line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 16px;\r\n                                        line-height: 28.8px;\r\n                                        font-family: Montserrat, sans-serif;\r\n                                      \"\r\n                                      >/span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%; font-size: 14px\">\r\n                                    <br /><span\r\n                                      style=\"\r\n                                        font-size: 16px;\r\n                                        line-height: 28.8px;\r\n                                        font-family: Montserrat, sans-serif;\r\n                                      \"\r\n                                      ></span\r\n                                    ><br /><span\r\n                                      style=\"\r\n                                        font-size: 18px;\r\n                                        line-height: 32.4px;\r\n                                      \"\r\n                                      ><span\r\n                                        style=\"\r\n                                          line-height: 32.4px;\r\n                                          font-family: Pacifico, cursive;\r\n                                          font-size: 18px;\r\n                                        \"\r\n                                        >مصلحكم</span\r\n                                      ></span\r\n                                    >\r\n                                  </p>\r\n                                </div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <table\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 0px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <table\r\n                                  width=\"100%\"\r\n                                  cellpadding=\"0\"\r\n                                  cellspacing=\"0\"\r\n                                  border=\"0\"\r\n                                >\r\n                                  <tr>\r\n                                    <td\r\n                                      style=\"\r\n                                        padding-right: 0px;\r\n                                        padding-left: 0px;\r\n                                      \"\r\n                                      align=\"center\"\r\n                                    >\r\n                                      <img\r\n                                        align=\"center\"\r\n                                        border=\"0\"\r\n                                        src=\"https://cdn.templates.unlayer.com/assets/1638520170619-12.png\" \r\n                                        alt=\"border\"\r\n                                        title=\"border\"\r\n                                        style=\"\r\n                                          outline: none;\r\n                                          text-decoration: none;\r\n                                          -ms-interpolation-mode: bicubic;\r\n                                          clear: both;\r\n                                          display: inline-block !important;\r\n                                          border: none;\r\n                                          height: auto;\r\n                                          float: none;\r\n                                          width: 100%;\r\n                                          max-width: 600px;\r\n                                        \"\r\n                                        width=\"600\"\r\n                                      />\r\n                                    </td>\r\n                                  </tr>\r\n                                </table>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #2f2f2f;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-image: url('%20');\r\n                    background-repeat: no-repeat;\r\n                    background-position: center top;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-image: url('%20');background-repeat: no-repeat;background-position: center top;background-color: #2f2f2f;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: transparent;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: transparent;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <table\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 20px 10px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    color: #6f7a7a;\r\n                                    line-height: 140%;\r\n                                    text-align: center;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                ></div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <!--[if (mso)|(IE)]></td></tr></table><![endif]-->\r\n          </td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n    <!--[if mso]></div><![endif]-->\r\n    <!--[if IE]></div><![endif]-->\r\n  </body>\r\n</html>\r\n";

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587; // 25 465
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("ramashararah00@gmail.com", "kmepdrnobvrooyrk");
                smtp.Send(mail);
                return RedirectToAction("Request");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", request.userId);
            ViewBag.Subscriper_Id = new SelectList(db.Subscripers, "Subscriper_Id", "userId", request.Subscriper_Id);
            return View(request);
        }


        [Authorize(Roles = "ServiceProvider")]
        public ActionResult Map(int? id)
        {

            return View(db.Requests.FirstOrDefault(x => x.Request_Id == id));
        }

        [HttpPost]
        public ActionResult SaveLocation([Bind(Include = "Request_Id,Request_Date,Lantitude,Longtitude,userId,Subscriper_Id,Accept")] Request request, double lat, double lng)
        {
         
            
            try
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
                var sub = db.Subscripers.FirstOrDefault(x => x.Subscriper_Id == request.Subscriper_Id);
                sub.Status = false;
                db.Requests.Add(geo);
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Loop through the validation errors and display them
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            if (User.IsInRole("User")) { 
            return RedirectToAction("UserProfile", "AspNetUsers");
            }
            if (User.IsInRole("User"))
            {
                return RedirectToAction("SubProfile", "Subscripers");
            }
            return View();
        }



        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "")]
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
        public ActionResult Create([Bind(Include = "Request_Id,Request_Date,Lantitude,Longtitude,userId,Subscriper_Id,Accept")] Request request)
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


        [Authorize(Roles = "")]
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
        public ActionResult Edit([Bind(Include = "Request_Id,Request_Date,Lantitude,Longtitude,userId,Subscriper_Id,Accept")] Request request)
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
        [Authorize(Roles = "Admin")]
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
            try { 
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // handle the error here
                return RedirectToAction("Index", "Error");
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
