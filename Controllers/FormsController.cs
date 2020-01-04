using BHOurProject.Models.Context;
using BHOurProject.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Controllers
{
    public class FormsController : Controller
    {
        // GET: RequestForm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RequestForm()
        {
            return View();
        }
        [HttpPost]
        public string SendMailAndSaveRequestForm(RequestForm requestList)
        {
            DataContext db = new DataContext();
            db.RequestForm.Add(requestList);
            SendMail(requestList);
            db.SaveChanges();
            return JsonConvert.SerializeObject("");
        }
        [HttpPost]
        public string SendMailAndSaveCarierForm(CarrierForm carrierForm)
        {
            DataContext db = new DataContext();
            db.CarrierForm.Add(carrierForm);
            SendMailCarrier(carrierForm);
            db.SaveChanges();
            return JsonConvert.SerializeObject("");
        }

        private void SendMailCarrier(CarrierForm carrierForm)
        {
            string contentHtml = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Files/Templates/RequestMailTemplate.html")))
            {
                contentHtml = reader.ReadToEnd();
            }
            contentHtml = contentHtml.Replace("{CompanyName}", carrierForm.Name).Replace("{CompanyRepresentative}", carrierForm.Note).Replace("{PhoneNumber}", carrierForm.MilitaryStatus.ToString())
                .Replace("{ProductOfInterest}", carrierForm.Gender).Replace("{MailAddress}", carrierForm.Address);
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add("hacer.346181@gmail.com"); //mail gönderilen adres
            mail.From = new MailAddress("hacer.346181@gmail.com"); //maili gönderen adres
            mail.Subject = "İletişim Formu";
            mail.Body = contentHtml;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //mail serverının host bilgisi
            smtp.Port = 587; //mail serverının portu
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("hacer.346181@gmail.com", "1905Sevdasi");
            smtp.Send(mail);
        }

        private void SendMail(RequestForm requestList)
        {
            string contentHtml = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Files/Templates/RequestMailTemplate.html")))
            {
                contentHtml = reader.ReadToEnd();
            }
            contentHtml = contentHtml.Replace("{CompanyName}", requestList.CompanyName).Replace("{CompanyRepresentative}", requestList.CompanyRepresentative).Replace("{PhoneNumber}", requestList.PhoneNumber).Replace("{TaxNumber}", requestList.TaxNumber)
                .Replace("{ProductOfInterest}", requestList.ProductOfInterest).Replace("{MailAddress}", requestList.MailAddress).Replace("{Quantity}", requestList.Quantity.ToString())
                .Replace("{City}",requestList.City)
                .Replace("{Explanation}", requestList.Explanation);
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add("hacer.346181@gmail.com"); //mail gönderilen adres
            mail.From = new MailAddress("hacer.346181@gmail.com"); //maili gönderen adres
            mail.Subject = "İletişim Formu";
            mail.Body = contentHtml;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //mail serverının host bilgisi
            smtp.Port = 587; //mail serverının portu
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("hacer.346181@gmail.com", "1905Sevdasi");
            smtp.Send(mail);
        }
    }
}