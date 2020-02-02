using BHOurProject.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetCustomerList()
        {
            return JsonConvert.SerializeObject(Customer.GetCustomerList());
        }
        public string UpdateCustomer(Customer customer)
        {
            bool result = false;
            Customer cat = new Customer();
            {

                result = cat.UpdateCustomer(customer);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
        [HttpPost]
        public string DeleteCustomer(int id)
        {
            bool result = false;
            Customer cat = new Customer();
            {
                result = cat.DeleteCustomer(id);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }

        [HttpPost]
        public string SaveCustomer(Customer customer)
        {
            bool result = false;
            Customer cat = new Customer();
            {
                result = cat.AddCustomer(customer);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
    }
}