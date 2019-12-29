using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Approve(int commentId)
        {
            // bu kısımda yorum ile ilgili veya siz ne için kullanmak
            // istiyorsanız ilgili kodunuzu yazıyorsunuz.
            // Daha sonra da buna göre bir sonuc döndürebilirsiniz.

            return Json(new { result = 1, message = "Başarılı." });
        }
    }
}