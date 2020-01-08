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
        [HttpPost]
        public string UpdateCategory(Category category)
        {
            bool result = false;
            Category cat = new Category();
            {
                cat.Id = category.Id;
                cat.Name = category.Name;
                cat.IsActive = category.IsActive;
                result = cat.UpdateCategory(category);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
        [HttpPost]
        public string DeteteCategory(int id)
        {
            bool result = false;
            Category cat = new Category();
            {
                result = cat.DeleteCategory(id);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }

        [HttpPost]
        public string SaveCategory(Category category)
        {
            bool result = false;
            Category cat = new Category();
            {
                result = cat.AddCategory(category);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
    }
}