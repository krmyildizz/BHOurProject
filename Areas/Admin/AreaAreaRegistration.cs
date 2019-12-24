using System.Web.Mvc;

namespace BHOurProject.Areas.Area
{
    public class AreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
        "Admin_default",
        "Admin/{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        new string[] { "BHOurProject.Areas.Admin.Controllers" });
        }
    }
}