using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Controllers
{
    public class FormsController : Controller
    {
        // GET: RequestForm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RequestForm()
        {
            return View();
        }
    }
}