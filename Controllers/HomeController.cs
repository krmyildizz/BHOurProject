using BHOurProject.Models.Context;
using BHOurProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Controllers
{
    public class HomeController : Controller
    {
        DataContext db;
        public ActionResult Index()
        {
            db = new DataContext();

            ViewBag.Company = db.Company.Where(x => x.IsActive).ToList().Select(i => new Company
            {
                Id = i.Id,
                DetailInformation = i.DetailInformation,
                Department = i.Department,
                Image = i.Image
            });
            ViewBag.News = db.News.Take(3).ToList();
            ViewBag.product = db.Product.ToList(); ;
            return View();
        }


        public ActionResult ProductDetail(int id)
        {
            db = new DataContext();
            return View(db.Product.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult Contact()
        {
           
            return View();
        }
        public PartialViewResult About()
        {
            @ViewBag.Message = "Hakkımızda";
            return PartialView();
        }
        public ActionResult ColorPicker()
        {
            DataContext db = new DataContext();
            ViewBag.Data = db.ColorPicker.ToList();
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}