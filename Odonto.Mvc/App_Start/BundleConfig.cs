using System.Web;
using System.Web.Optimization;

namespace Odonto.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region "Bundles do sistema"
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Includes/sbadmin/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Includes/sbadmin/vendor/metisMenu/metisMenu.min.js",
                      "~/Includes/sbadmin/dist/js/sb-admin-2.min.js"));
        
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Includes/sbadmin/vendor/bootstrap/css/bootstrap.min.css",
                "~/Includes/sbadmin/vendor/metisMenu/metisMenu.min.css",
                "~/Includes/sbadmin/dist/css/sb-admin-2.min.css",
                "~/Includes/sbadmin/vendor/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/dataTable").Include(
                "~/Includes/datatable/datatables.min.js"));

            bundles.Add(new StyleBundle("~/dataTable/css").Include(
                "~/Includes/datatable/DataTables-1.10.16/css/dataTables.bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/sweetAlert").Include(
               "~/Includes/sweetalert/sweetalert2.all.js"));

            #endregion

            #region "Bundles Empresa"
            bundles.Add(new ScriptBundle("~/bundles/EmpresaLista").Include(
                        "~/Scripts/_Odonto/Empresa/Lista.js"));
            #endregion
        }
    }
}
