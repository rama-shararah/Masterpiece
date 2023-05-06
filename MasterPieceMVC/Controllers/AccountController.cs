using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MasterPieceMVC.Models;
using System.Web.Helpers;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Security;
using System.Net.Mail;

namespace MasterPieceMVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        MyMasterPieceEntities db = new MyMasterPieceEntities();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            DateTime currentDate = DateTime.Now.Date;
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            var roleId = db.AspNetUserRoles.FirstOrDefault(x=>x.AspNetUser.Email == model.Email);
            var id = db.AspNetUsers.FirstOrDefault(x => x.Email == model.Email).Id;
            if (roleId.RoleId == "2") {
            var subscriptionEnd = db.Subscriptions.FirstOrDefault(x => x.userId == id).Subscription_End;
                if (currentDate >= subscriptionEnd && roleId.RoleId == "2")
                {
                    var shown = db.Subscripers.SingleOrDefault(x => x.userId == id);
                    shown.Shown = false;
                    db.SaveChanges();
                    //var userRole = db.AspNetUserRoles.SingleOrDefault(x => x.UserId == id);
                    //if (userRole != null)
                    //{
                    //    db.AspNetUserRoles.Remove(userRole);
                    //    db.SaveChanges();
                    //    db.AspNetUserRoles.Add(new AspNetUserRole { UserId = id, RoleId = "3" });
                    //    db.SaveChanges();
                    //}
                    string Email = model.Email;

                    MailMessage mail = new MailMessage();
                    mail.To.Add(Email);
                    mail.From = new MailAddress("ramashararah00@gmail.com");
                    mail.Subject = "انتهاء الاشتراك";
                    mail.Body = $"<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional //EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html\r\n  xmlns=\"http://www.w3.org/1999/xhtml\"\r\n  xmlns:v=\"urn:schemas-microsoft-com:vml\"\r\n  xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n>\r\n  <head>\r\n    <!--[if gte mso 9]>\r\n      <xml>\r\n        <o:OfficeDocumentSettings>\r\n          <o:AllowPNG />\r\n          <o:PixelsPerInch>96</o:PixelsPerInch>\r\n        </o:OfficeDocumentSettings>\r\n      </xml>\r\n    <![endif]-->\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <meta name=\"x-apple-disable-message-reformatting\" />\r\n    <!--[if !mso]><!-->\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />\r\n    <!--<![endif]-->\r\n    <title></title>\r\n\r\n    <style type=\"text/css\">\r\n      @media only screen and (min-width: 620px) {{\r\n        .u-row {{\r\n          width: 600px !important;\r\n        }}\r\n        .u-row .u-col {{\r\n          vertical-align: top;\r\n        }}\r\n\r\n        .u-row .u-col-100 {{\r\n          width: 600px !important;\r\n        }}\r\n      }}\r\n\r\n      @media (max-width: 620px) {{\r\n        .u-row-container {{\r\n          max-width: 100% !important;\r\n          padding-left: 0px !important;\r\n          padding-right: 0px !important;\r\n        }}\r\n        .u-row .u-col {{\r\n          min-width: 320px !important;\r\n          max-width: 100% !important;\r\n          display: block !important;\r\n        }}\r\n        .u-row {{\r\n          width: 100% !important;\r\n        }}\r\n        .u-col {{\r\n          width: 100% !important;\r\n        }}\r\n        .u-col > div {{\r\n          margin: 0 auto;\r\n        }}\r\n      }}\r\n      body {{\r\n        margin: 0;\r\n        padding: 0;\r\n      }}\r\n\r\n      table,\r\n      tr,\r\n      td {{\r\n        vertical-align: top;\r\n        border-collapse: collapse;\r\n      }}\r\n\r\n      p {{\r\n        margin: 0;\r\n      }}\r\n\r\n      .ie-container table,\r\n      .mso-container table {{\r\n        table-layout: fixed;\r\n      }}\r\n\r\n      * {{\r\n        line-height: inherit;\r\n      }}\r\n\r\n      a[x-apple-data-detectors=\"true\"] {{\r\n        color: inherit !important;\r\n        text-decoration: none !important;\r\n      }}\r\n\r\n      table,\r\n      td {{\r\n        color: #000000;\r\n      }}\r\n      @media (max-width: 480px) {{\r\n        #u_content_text_1 .v-container-padding-padding {{\r\n          padding: 40px 10px 10px !important;\r\n        }}\r\n        #u_content_text_2 .v-container-padding-padding {{\r\n          padding: 8px 10px 40px !important;\r\n        }}\r\n      }}\r\n    </style>\r\n\r\n    <!--[if !mso]><!-->\r\n    <link\r\n      href=\"https://fonts.googleapis.com/css?family=Montserrat:400,700&display=swap\"\r\n      rel=\"stylesheet\"\r\n      type=\"text/css\"\r\n    />\r\n    <link\r\n      href=\"https://fonts.googleapis.com/css?family=Pacifico&display=swap\"\r\n      rel=\"stylesheet\"\r\n      type=\"text/css\"\r\n    />\r\n    <!--<![endif]-->\r\n  </head>\r\n\r\n  <body\r\n    class=\"clean-body u_body\"\r\n    style=\"\r\n      margin: 0;\r\n      padding: 0;\r\n      -webkit-text-size-adjust: 100%;\r\n      background-color: #ffffff;\r\n      color: #000000;\r\n    \"\r\n  >\r\n    <!--[if IE]><div class=\"ie-container\"><![endif]-->\r\n    <!--[if mso]><div class=\"mso-container\"><![endif]-->\r\n    <table\r\n      style=\"\r\n        border-collapse: collapse;\r\n        table-layout: fixed;\r\n        border-spacing: 0;\r\n        mso-table-lspace: 0pt;\r\n        mso-table-rspace: 0pt;\r\n        vertical-align: top;\r\n        min-width: 320px;\r\n        margin: 0 auto;\r\n        background-color: #ffffff;\r\n        width: 100%;\r\n      \"\r\n      cellpadding=\"0\"\r\n      cellspacing=\"0\"\r\n    >\r\n      <tbody>\r\n        <tr style=\"vertical-align: top\">\r\n          <td\r\n            style=\"\r\n              word-break: break-word;\r\n              border-collapse: collapse !important;\r\n              vertical-align: top;\r\n            \"\r\n          >\r\n            <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\" style=\"background-color: #ffffff;\"><![endif]-->\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #2f3031;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: #2f3031;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div style=\"height: 100%; width: 100% !important\">\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: transparent;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: transparent;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #2f3031;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-image: url('%20');\r\n                    background-repeat: no-repeat;\r\n                    background-position: center top;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-image: url('%20');background-repeat: no-repeat;background-position: center top;background-color: #2f3031;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #fbfbfb;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: #fbfbfb;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <table\r\n                          id=\"u_content_text_1\"\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 50px 35px 10px 40px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    color: #000000;\r\n                                    line-height: 180%;\r\n                                    text-align: left;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                >\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      >عزيزنا المشترك{Email},</span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      >نود اعلامك انه قد تم انتهاء اشتراكك في موقع مصلحكم عليك الاشتراك من جديد للاستفادة من الموقع شكرا لك على الاشتراك </span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      ></span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 12px;\r\n                                        line-height: 21.6px;\r\n                                      \"\r\n                                      ></span\r\n                                    >\r\n                                  </p>\r\n                                </div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <table\r\n                          id=\"u_content_text_2\"\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 8px 35px 40px 40px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    color: #000000;\r\n                                    line-height: 180%;\r\n                                    text-align: left;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                >\r\n                                  <p style=\"line-height: 180%; font-size: 14px\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-family: Montserrat, sans-serif;\r\n                                        font-size: 16px;\r\n                                        line-height: 28.8px;\r\n                                      \"\r\n                                      ></span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"font-size: 14px; line-height: 180%\">\r\n                                    <span\r\n                                      style=\"\r\n                                        font-size: 16px;\r\n                                        line-height: 28.8px;\r\n                                        font-family: Montserrat, sans-serif;\r\n                                      \"\r\n                                      >/span\r\n                                    >\r\n                                  </p>\r\n                                  <p style=\"line-height: 180%; font-size: 14px\">\r\n                                    <br /><span\r\n                                      style=\"\r\n                                        font-size: 16px;\r\n                                        line-height: 28.8px;\r\n                                        font-family: Montserrat, sans-serif;\r\n                                      \"\r\n                                      ></span\r\n                                    ><br /><span\r\n                                      style=\"\r\n                                        font-size: 18px;\r\n                                        line-height: 32.4px;\r\n                                      \"\r\n                                      ><span\r\n                                        style=\"\r\n                                          line-height: 32.4px;\r\n                                          font-family: Pacifico, cursive;\r\n                                          font-size: 18px;\r\n                                        \"\r\n                                        >مصلحكم</span\r\n                                      ></span\r\n                                    >\r\n                                  </p>\r\n                                </div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <table\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 0px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <table\r\n                                  width=\"100%\"\r\n                                  cellpadding=\"0\"\r\n                                  cellspacing=\"0\"\r\n                                  border=\"0\"\r\n                                >\r\n                                  <tr>\r\n                                    <td\r\n                                      style=\"\r\n                                        padding-right: 0px;\r\n                                        padding-left: 0px;\r\n                                      \"\r\n                                      align=\"center\"\r\n                                    >\r\n                                      <img\r\n                                        align=\"center\"\r\n                                        border=\"0\"\r\n                                        src=\"https://cdn.templates.unlayer.com/assets/1638520170619-12.png\" \r\n                                        alt=\"border\"\r\n                                        title=\"border\"\r\n                                        style=\"\r\n                                          outline: none;\r\n                                          text-decoration: none;\r\n                                          -ms-interpolation-mode: bicubic;\r\n                                          clear: both;\r\n                                          display: inline-block !important;\r\n                                          border: none;\r\n                                          height: auto;\r\n                                          float: none;\r\n                                          width: 100%;\r\n                                          max-width: 600px;\r\n                                        \"\r\n                                        width=\"600\"\r\n                                      />\r\n                                    </td>\r\n                                  </tr>\r\n                                </table>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: #2f2f2f;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-image: url('%20');\r\n                    background-repeat: no-repeat;\r\n                    background-position: center top;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-image: url('%20');background-repeat: no-repeat;background-position: center top;background-color: #2f2f2f;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 600px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: transparent;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: transparent;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 600px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div\r\n                      style=\"\r\n                        height: 100%;\r\n                        width: 100% !important;\r\n                        border-radius: 0px;\r\n                        -webkit-border-radius: 0px;\r\n                        -moz-border-radius: 0px;\r\n                      \"\r\n                    >\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                          border-radius: 0px;\r\n                          -webkit-border-radius: 0px;\r\n                          -moz-border-radius: 0px;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <table\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                class=\"v-container-padding-padding\"\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 20px 10px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    color: #6f7a7a;\r\n                                    line-height: 140%;\r\n                                    text-align: center;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                ></div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <!--[if (mso)|(IE)]></td></tr></table><![endif]-->\r\n          </td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n    <!--[if mso]></div><![endif]-->\r\n    <!--[if IE]></div><![endif]-->\r\n  </body>\r\n</html>\r\n";

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
         

         
            switch (result)
            {
                case SignInStatus.Success:
                    if (roleId.RoleId == "3" && Session["return"]!= null)
                    {
                        return RedirectToAction("IndexUser", "Prices");
                    }
                    else if(roleId.RoleId == "2" && Session["profile"] != null)
                    {
                        return RedirectToAction("SubProfile", "Subscripers");
                    }
                    else if ((roleId.RoleId == "3" || roleId.RoleId == "2") && Session["id"] != null)
                    {

                        int idd = Convert.ToInt32(Session["id"]);
                        return RedirectToAction("SingleSub", "Subscripers", new { id = idd });

                    }
                    else if (roleId.RoleId=="3")
                    {
                        return RedirectToAction("HomePage", "Services");
                    }
                    else if (roleId.RoleId == "2")
                    {
                        return RedirectToAction("HomePage", "Services");
                    }
                    else if (roleId.RoleId == "1")
                    {
                        return RedirectToAction("Dashboard", "Subscriptions");
                    }
                    return Redirect("~/Services/HomePage");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "محاولة تسجيل الدخول غير صحيحة");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, [Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Photo,Location")] AspNetUser aspNetUser)
        {
             MyMasterPieceEntities db = new MyMasterPieceEntities();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber=aspNetUser.PhoneNumber };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    string email = model.Email;
                 
                    var userId = db.AspNetUsers.Where(m => m.Email == email).Select(m => m.Id).SingleOrDefault();
                    UserManager.AddToRole(userId, "User");
                    var newUser = db.AspNetUsers.Find(userId);
                    newUser.Location = aspNetUser.Location;
                    newUser.Photo = "nn.jpg";                  
                    db.SaveChanges();

                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Login", "Account");
                }
                AddErrors(result);
         
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("HomePage", "Services");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}