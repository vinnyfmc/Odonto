using System.Web;
using System.Web.Optimization;

namespace Odonto.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                "~/Content/vendor/metisMenu/metisMenu.min.js",
                "~/Content/dist/js/sb-admin-2.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/vendor/bootstrap/css/bootstrap.min.css", 
                "~/Content/vendor/metisMenu/metisMenu.min.css",
                "~/Content/dist/css/sb-admin-2.min.css",
                "~/Content/vendor/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/swal").Include(
                "~/Content/sweetalert/sweetalert.min.js"));

            bundles.Add(new StyleBundle("~/swal/css").Include(
                "~/Content/sweetalert/sweetalert.css"));

            bundles.Add(new ScriptBundle("~/bundles/DataTablejs").Include(
               "~/Content/datatable/js/datatables.min.js"));

            bundles.Add(new StyleBundle("~/DataTablejs/css").Include(
                "~/Content/datatable/css/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Morrisjs/css").Include(
                "~/Content/vendor/morrisjs/morris.css"));

            bundles.Add(new ScriptBundle("~/bundles/Morrisjs").Include(
                "~/Content/vendor/raphael/raphael.min.js",
                "~/Content/vendor/morrisjs/morris.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/FuncionarioLista").Include(
                "~/Scripts/_Odonto/FuncionarioLista.js"));
        }
    }
}
