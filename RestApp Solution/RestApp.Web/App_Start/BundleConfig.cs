using System.Web;
using System.Web.Optimization;

namespace RestApp
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/controlsToolKit").Include(
                           "~/Scripts/MVCControlToolkit.Controls-2.2.5.js"));

            bundles.Add(new ScriptBundle("~/bundles/lightbox").Include(
                       "~/Scripts/jquery.smooth-scroll.min.js",
                       "~/Scripts/lightbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/extensions").Include(
                        "~/Scripts/jquery.blockUI.js"));

            bundles.Add(new ScriptBundle("~/bundles/listeditor").Include(
                        "~/Scripts/listEditor.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                         "~/Scripts/jquery.dataTables.js"));           

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrapmin").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                        "~/Scripts/chosen.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernui").Include(
                        //"~/Scripts/jquery.unobtrusive-ajax.min.js",
                        //"~/Scripts/jquery.unobtrusive-ajax.min.js",
                        //"~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/public.common.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/css/bootstrap.css",
                        "~/Content/css/bootstrap-responsive.css",
                        "~/Content/css/bootstrap.extra.css", 
                        "~/Content/css/normalize.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap.min").Include(
                        "~/Content/css/bootstrap.min.css",
                        "~/Content/css/bootstrap-responsive.min.css"));

            bundles.Add(new StyleBundle("~/Content/chosen").Include(
                        "~/Content/css/chosen.css"));

            bundles.Add(new StyleBundle("~/Content/lightbox").Include(
                       "~/Content/css/lightbox.css"));

            bundles.Add(new StyleBundle("~/Content/jquery").Include(
                       "~/Content/css/jquery-ui-1.9.2.css"));

            //MainMenuUI
            bundles.Add(new StyleBundle("~/Content/MainMenuUI").Include(
                       "~/Content/css/MainMenuUI.css",
                       "~/Content/css/MainMenuUI-responsive.css"));
        }

    }
}