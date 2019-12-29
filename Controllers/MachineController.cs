using BHOurProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Models
{
    public class MachineController : Controller
    {
        DataContext db = new DataContext();
        // GET: Machine
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MachineDetail(int id)
        {
            var machine = db.Machine.Where(x => x.CompanyId == id).ToList();
            return View();
        }
    }
}