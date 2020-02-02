using BHOurProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Controllers
{
    public class ReferenceController : Controller
    {
        // GET: Reference
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReferenceList(string customerName)
        {
            if (string.IsNullOrEmpty(customerName)) {
                ViewBag.customer = Customer.GetCustomerList().Where(x => x.IsActive == true);
                ViewBag.referance = Reference.GetReference().Where(x=>x.IsActive==true);
            }
           
           else{
                ViewBag.customer = Customer.GetCustomerList().Where(x => x.Name == customerName);
                ViewBag.referance = Reference.GetReference().Where(x => x.CustomerName == customerName);
            }
            return View();
        }
    }
}