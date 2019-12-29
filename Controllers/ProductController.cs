using BHOurProject.Models.Context;
using BHOurProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Controllers
{
    public class ProductController : Controller
    {
        DataContext db = new DataContext();
        // GET: Product
        public ActionResult Index(int ? id)
        {
            var product = db.Product.Where(i => i.IsActive).ToList().Select(i => new Product
            {
                Id = i.Id,
                Name = i.Name.Length > 20 ? i.Name.Substring(0, 20) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Description2 = i.Description2.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Image = i.Image ?? "https://thumbs.dreamstime.com/z/build-19054832.jpg",
                CategoryId = i.CategoryId

            }).AsQueryable();
            
            if (id != null)
            {
                product = product.Where(x => x.CategoryId == id);
            }
            return View(product.ToList());
        }
    }
}