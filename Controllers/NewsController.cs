using BHOurProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.News.Where(x => x.IsActive).ToList());
        }
        public ActionResult NewsDetail()
        {
            return View();
        }
    }
}