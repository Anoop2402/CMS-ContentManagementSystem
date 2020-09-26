using System.Web;
using System.Web.Optimization;

namespace CMSViewEngine1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            BundleTable.Bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery", @"//cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js","~/Scripts/sidebar.js"));

            bundles.Add(new StyleBundle("~/Content/css", @"//cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css").Include(
                      "~/Content/bootstrap-*",
                      "~/Content/site.css","~/Content/sidebar.css"));
        }
    }
}
