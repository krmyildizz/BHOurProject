using BHOurProject.Areas.Admin.Models;
using BHOurProject.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public string GetSubCategory()
        {
            List<CategoryDTO> list = Category.GetSubCategory();
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
        public string DeleteCategory(int id)
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
        public string SaveSubCategory(SubCategory sub,int categoryId, string image)
        {
            string imageType = ImageUpload.GetFileType(image);
            string FileIconeName = Guid.NewGuid().ToString();

            byte[] fileBytes = ImageUpload.Parse(image);
            string Fullftp = "ftp://demoproje.site/httpdocs/Files/Image/" + FileIconeName + "." + imageType;
            string httpAdres = "http://demoproje.site/Files/Image/" + FileIconeName + "." + imageType;

            FtpWebRequest reqFtp =
                (FtpWebRequest)
                    FtpWebRequest.Create(Fullftp);


            reqFtp.Credentials = new NetworkCredential("u9172314", "OImu28B6");
            reqFtp.KeepAlive = false;
            reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
            reqFtp.UseBinary = true;
            reqFtp.UsePassive = true;

            try
            {
                using (Stream strm = reqFtp.GetRequestStream())
                {
                    strm.Write(fileBytes, 0, fileBytes.Length);
                    strm.Close();

                }


            }
            catch (Exception ex)
            {

            }
            bool result = false;
            SubCategory subCategory = new SubCategory();
            {
                subCategory.Name = sub.Name;
                subCategory.IsActive = sub.IsActive;
                subCategory.CategoryId = categoryId;
                subCategory.Image= httpAdres;
                result = subCategory.AddSubCategory(subCategory);
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