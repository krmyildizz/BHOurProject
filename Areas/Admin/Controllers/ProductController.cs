using BHOurProject.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetProductList()
        {
            return JsonConvert.SerializeObject(Product.GetProductList());
        }
        [HttpPost]
        public string SaveProduct(Product product)
        {
            bool result = false;
            Product pro = new Product();
            {
                result = pro.AddProduct(product);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
        [HttpPost]
        public string UpdateCategory(Product product)
        {
            bool result = false;
            Product pro = new Product();
            {
                pro.Id = product.Id;
                pro.Name = product.Name;
                pro.CategoryId = product.CategoryId;
                pro.Description = product.Description;
                pro.Description2 = product.Description2;
                pro.AplicationAreas = product.AplicationAreas;
                pro.ManufacturingPlace = product.ManufacturingPlace;
                pro.Image = product.ManufacturingPlace;
                pro.SubName = product.SubName;
                pro.Pdf = product.Pdf;
                pro.IsActive = product.IsActive;
                result = pro.UpdateProduct(product);

            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
        [HttpPost]
        public string DeleteProduct(int id)
        {
            bool result = false;
            Product pro = new Product();
            {
                result = pro.DeleteProduct(id);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }

    }
}