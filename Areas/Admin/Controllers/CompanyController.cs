using BHOurProject.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Areas.Admin.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Admin/Company
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetCategoryList()
        {
            List<Company> list = Company.GetCompanyList();
            return JsonConvert.SerializeObject(list);
        }
        [HttpPost]
        public string UpdateCategory(Company company)
        {
            bool result = false;
            Company cat = new Company();
            {
               
                result = cat.UpdateCompany(company);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
        [HttpPost]
        public string DeleteCompany(int id)
        {
            bool result = false;
            Company cat = new Company();
            {
                result = cat.DeleteCompany(id);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }

        [HttpPost]
        public string SaveCategory(Company company)
        {
            bool result = false;
            Company cat = new Company();
            {
                result = cat.AddCompany(company);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
    }
}