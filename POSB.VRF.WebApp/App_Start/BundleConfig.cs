using System.Web;
using System.Web.Optimization;

namespace POSB.VRF.Webapps.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            //js
            bundles.Add(new ScriptBundle("~/bundles/jqueryjs").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendojs").Include(
                        "~/Scripts/kendo/jszip.min.js",
                        "~/Scripts/kendo/kendo.all.min.js",
                        "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                        "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                        "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            //css
            bundles.Add(new StyleBundle("~/Content/kendocss").Include(
                        "~/Content/kendo/kendo.common.min.css",
                        "~/Content/kendo/kendo.default.min.css"));
            
            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/kendo.bootstrap.min.css",
                        "~/Content/kendo.bootstrap.mobile.min"));

            bundles.Add(new StyleBundle("~/Content/toastr").Include(
                        "~/Content/toastr.css"));

            bundles.Add(new StyleBundle("~/Content/starter").Include(
                        "~/Content/starter.css"));


            bundles.IgnoreList.Clear();
        }
    }
}