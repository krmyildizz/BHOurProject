using BHOurProject.Models.Context;
using BHOurProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Controllers
{
    public class CategoryController : Controller
    {
        DataContext db = new DataContext();
        // GET: Category
        public ActionResult Index(int? Id)
        {
            var subCategory = db.SubCategory.Where(i => i.IsActive==true).ToList().Select(i => new SubCategory
            {
                Id = i.Id,
                Name = i.Name,
                Image = i.Image ?? "https://thumbs.dreamstime.com/z/build-19054832.jpg",
                CategoryId = i.CategoryId

            }).AsQueryable();
            if (Id != null)
            {
                subCategory = subCategory.Where(x => x.CategoryId == Id);
                ViewBag.Id = Id;

            }


            return View(subCategory.ToList());
        }
        public PartialViewResult Category()
        {
            List<Category> category = db.Category.ToList();
            ViewBag.Data = category;
            return PartialView();
        }
        public ActionResult SubCategories(int? Id)
        {
            return View();
        }
    }
}