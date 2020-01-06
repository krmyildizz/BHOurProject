using System.Web;
using System.Web.Optimization;

namespace BHOurProject
{
    public class BundleConfig
    {
        // Paketleme hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkId=301862 adresini ziyaret edin
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Geliştirme yapmak ve öğrenmek için Modernizr'ın geliştirme sürümünü kullanın. Daha sonra,
            // üretim için hazır. https://modernizr.com adresinde derleme aracını kullanarak yalnızca ihtiyacınız olan testleri seçin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular")
        .Include(
            //"~/Scripts/angular.js",
            "~/Scripts/pages/requestForms.js",
             "~/Scripts/Admin/category.js",
            "~/Scripts/angular.min.js",
            "~/Scripts/ui-bootstrap-modal.js",
            "~/Scripts/angular-animate.js",
            "~/Scripts/angular-mocks.js",
            "~/Scripts/angular-route.js",
            "~/Scripts/angular-resource.js",
            "~/Scripts/angular-sanitize.js"
            
            )

        );
            bundles.Add(new ScriptBundle("~/bundles/angularAdmin")
   .Include(
       //"~/Scripts/angular.js",
       
        "~/Scripts/Admin/category.js",
       "~/Scripts/angular.min.js",
       "~/Scripts/ui-bootstrap-modal.js",
       "~/Scripts/angular-animate.js",
       "~/Scripts/angular-mocks.js",
       "~/Scripts/angular-route.js",
       "~/Scripts/angular-resource.js",
       "~/Scripts/angular-sanitize.js"

       )

   );



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
