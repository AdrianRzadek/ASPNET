using System.Web.Optimization;

namespace ASP
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Areas/Admin/Content/bootstrap.css"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                "~/Areas/Admin/Scripts/bootstrap.js"
            ));
        }
    }
}