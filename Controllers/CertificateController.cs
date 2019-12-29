using BHOurProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        public ActionResult Index()
        {
            DataContext db = new DataContext();
            var certificate = db.Certificate.Where(x => x.IsActive).ToList();
            return View(certificate);
        }
    }
}