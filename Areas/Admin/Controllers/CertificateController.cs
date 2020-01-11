using BHOurProject.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Areas.Admin.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Admin/Certificate
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetCertificateList()
        {
            List<Certificate> list = Certificate.GetCertificateList();
            return JsonConvert.SerializeObject(list);
        }
        [HttpPost]
        public string UpdateCertificate(Certificate certificate)
        {
            bool result = false;
            Certificate cat = new Certificate();
            {

                result = cat.UpdateCertificate(certificate);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
        [HttpPost]
        public string DeleteCertificate(int id)
        {
            bool result = false;
            Certificate cat = new Certificate();
            {
                result = cat.DeleteCertificate(id);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }

        [HttpPost]
        public string SaveCertificate(Certificate company)
        {
            bool result = false;
            Certificate cat = new Certificate();
            {
                result = cat.AddCertificate(company);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
    }
}