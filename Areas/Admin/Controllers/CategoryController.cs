using BHOurProject.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetCategoryList()
        {
            List<Category> list = Category.GetCategoryList();
            return JsonConvert.SerializeObject(list);
        }
    }
}