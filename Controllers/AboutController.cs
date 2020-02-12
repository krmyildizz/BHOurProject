using BHOurProject.Models.Context;
using BHOurProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        // GET: Admin/About
        DataContext db;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OurView()
        {
            db = new DataContext();
            ViewBag.Company = db.Company.Where(x => x.IsActive).ToList().Select(i => new Company
            {
                Id = i.Id,
                DetailInformation = i.DetailInformation,
                Department = i.Department,
                Image = i.Image
            });
            return View();
        }
    }
}