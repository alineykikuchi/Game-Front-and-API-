using System.Web;
using System.Web.Optimization;

namespace Games
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            ///////////////////////////////////////////////////////////////////
            bundles.Add(new StyleBundle("~/Content/css/boostrap-4.4").Include(
                      "~/Content/bootstrap-4.4.1-dist/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-4.4").Include(
                      "~/Scripts/bootstrap-4.4.1-dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/knokout").Include(
                        "~/Scripts/knockout-3.4.2.min.js",
                        "~/Scripts/knockout.mapping-2.4.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rockPaperScissors").Include(
                        "~/Scripts/especific/rockPaperScissors.js"));
        }
    }
}
