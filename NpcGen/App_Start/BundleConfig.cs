using System.Web;
using System.Web.Optimization;

namespace NpcGen
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/Vendor/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Scripts/Vendor/bootstrap.js",
                     "~/Scripts/Vendor/respond.js"));
        }
    }
}