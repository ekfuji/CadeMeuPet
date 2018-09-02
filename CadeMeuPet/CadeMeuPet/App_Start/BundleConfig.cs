using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CadeMeuPet
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/js-global").Include(
                "~/scripts/jquery-3.3.1.min.js",
                "~/scripts/bootstrap.min.js"
            ));

        }
    }
}