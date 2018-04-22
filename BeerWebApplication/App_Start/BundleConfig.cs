using System.Web.Optimization;

namespace BeerWebApplication.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/scripts/jquery-1.7.1.js",
                      "~/scripts/bootstrap.min.js",
                      "~/scripts/jquery-ui-custom.min.js",
                      "~/scripts/jquery.layout.js",
                      "~/scripts/jquery.jqGrid.js",
                      "~/scripts/jqGridExportToExcel.jss",
                      "~/scripts/grid.locale-en.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/Site.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/ui.jqgrid.css"));
        }
    }
}