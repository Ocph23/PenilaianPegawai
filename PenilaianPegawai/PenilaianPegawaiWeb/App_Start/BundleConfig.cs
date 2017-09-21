using System.Web;
using System.Web.Optimization;

namespace PenilaianPegawaiWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/tether.min.js", "~/js/bootstrap.js",
                        "~/js/jquery.cookie.js",
                              "~/js/front.js",
                          "~/js/grasp_mobile_progress_circle-1.0.0.min.js",
                            "~/js/jquery.nicescroll.min.js",

                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/angular.js",
                    "~/Scripts/angular-route.js","~/Apps/App.js","~/Apps/Service.js", "~/Apps/Controller.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                        "~/Content/style.default.css",
                          "~/Content/grasp_mobile_progress_circle-1.0.0.min.css",
                            "~/Content/custom.css",
                             
                              "~/CSS/font-awesome.css"));
        }
    }
}
