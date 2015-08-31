using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebNews.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundle/bootstrap-styles")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-theme.css")
                .Include("~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/bundle/Home/Index-styles")
                .Include("~/Content/StyleSheet1.css")
                .Include("~/Content/StyleSheet2.css")
                .Include("~/Content/StyleSheet3.css"));

            //bundles.Add(new ScriptBundle("~/bundle/bootstrap-scripts")
            //    .Include("~/Scripts/bootstrap.js")
            //    .Include("~/Scripts/jquery-{version}.js")
            //    .Include("~/Scripts/modernizr-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundle/Home/Index-scripts")
                .Include("~/Static/js/Custom/GoogleMaps.js"));

        }
    }
}