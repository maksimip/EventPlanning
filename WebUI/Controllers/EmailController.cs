using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ActionMailer.Net.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class EmailController : MailerBase
    {
        // GET: Email
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public EmailResult SendMail(EmailModel model)
        {
            
             To.Add(model.To);
            From = "mailer@gmail.com";
            Subject = model.Subject;
            MessageEncoding = Encoding.UTF8;
            return Email("SendMail", model);
        }
    }
}