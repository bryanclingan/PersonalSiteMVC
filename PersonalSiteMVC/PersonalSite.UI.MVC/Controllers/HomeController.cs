using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalSite.UI.MVC.Models;
using System.Net;
using System.Net.Mail;

namespace PersonalSite.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }
        public ActionResult Portfolio()
        {
            return View();
        }
        public ActionResult Links()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            
            if (!ModelState.IsValid)
            {                
                return View(cvm);
            }
            
            string message = $"You have received an email from {cvm.Name} with a subject of {cvm.Subject}. Please respond to {cvm.Email} with your response to the following message: <br/>{cvm.Message}";
                        
            MailMessage mm = new MailMessage("", "", cvm.Subject, message);
                        
            mm.IsBodyHtml = true;
            
            mm.Priority = MailPriority.High;
            
            mm.ReplyToList.Add(cvm.Email);
                        
            SmtpClient client = new SmtpClient("");
                        
            client.Credentials = new NetworkCredential("", "");

            client.Port = 587;
            //client.UseDefaultCredentials = false;
            //client.EnableSsl = false;
                        
            try
            {              
                client.Send(mm);
            }
            catch (Exception ex)
            {
                ViewBag.CustomerMessage = $"We're sorry your request cannot be sent at this time. Please try again later. <br/>ErrorMessage:<br/> {ex.StackTrace}";
                return View(cvm);
            }            
            return View("EmailConfirmation", cvm);
            
        }
    }
}