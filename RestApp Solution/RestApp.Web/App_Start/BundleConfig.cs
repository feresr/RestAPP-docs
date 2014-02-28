using System.Web;
using System.Web.Optimization;

namespace RestApp
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //new
            #region Styles
            bundles.Add(new StyleBundle("~/Content/basic").Include(
                         "~/Content/css/bootstrap.css",
                         "~/Content/css/sb-admin.css"));

            bundles.Add(new StyleBundle("~/Content/font").Include(
                         "~/Content/font-awesome/css/font-awesome.css")); 
            #endregion

            #region Scripts
            bundles.Add(new ScriptBundle("~/bundles/basic").Include(
                "~/Content/js/jquery-1.10.2.js",            
                "~/Content/js/bootstrap.js",
                "~/Content/js/sb-admin.js"));

            bundles.Add(new ScriptBundle("~/bundles/basicExtras").Include(
               "~/Content/js/plugins/metisMenu/jquery.metisMenu.js")); 
            #endregion

            //old
            bundles.Add(new ScriptBundle("~/bundles/controlsToolKit").Include(
                           "~/Scripts/MVCControlToolkit.Controls-2.2.5.js"));

            bundles.Add(new ScriptBundle("~/bundles/extensions").Include(
                        "~/Scripts/jquery.blockUI.js"));

            bundles.Add(new ScriptBundle("~/bundles/listeditor").Include(
                        "~/Scripts/listEditor.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                         "~/Scripts/jquery.dataTables.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernui").Include(
                        //"~/Scripts/jquery.unobtrusive-ajax.min.js",
                        //"~/Scripts/jquery.unobtrusive-ajax.min.js",
                        //"~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/public.common.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
        }

    }
}