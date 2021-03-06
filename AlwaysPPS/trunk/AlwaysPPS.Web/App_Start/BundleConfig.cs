﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AlwaysPPS.Web
{
     public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));



            /******************** START CUSTOMIZE *************************/

            // JAVASCRIPT
            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                "~/Scripts/toastr.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/kendo/2014.1.318/kendo.web.min.js",
                "~/Scripts/kendo/2014.1.318/kendo.aspnetmvc.min.js",
                "~/Scripts/kendo.modernizr.custom.js",
                "~/Scripts/base64.js",
                "~/Scripts/app.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                "~/Scripts/toastr.js",
                "~/Scripts/bootstrap.js",
                
                //"~/Scripts/kendo/2014.1.318/kendo.web.min.js",
                //"~/Scripts/kendo/2014.1.318/kendo.dataviz.min.js",
                "~/Scripts/kendo/2014.1.318/kendo.all.min.js",
                "~/Scripts/kendo/2014.1.318/cultures/kendo.culture.zh-CN.min.js",
                "~/Scripts/kendo/2014.1.318/kendo.aspnetmvc.min.js",
                "~/Scripts/kendo.modernizr.custom.js",
                "~/Scripts/fullcalendar.min.js",
                //"~/Scripts/sidebar.js",
                "~/Scripts/highcharts.js",
                "~/Scripts/superTables/superTables.js",
                "~/Scripts/exporting.js",
                "~/Scripts/base64.js",
                "~/Scripts/app.js"
                
                ));

            // CSS
            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-select.css"
               ));
            bundles.Add(new StyleBundle("~/Content/main/login").Include(
                 "~/Content/less/reset.css",
                 "~/Content/bootstrap.css",
                 "~/Content/kendo/kendo.common.min.css",
                 "~/Content/kendo/kendo.common-bootstrap.min.css",
                 "~/Content/kendo/kendo.bootstrap.min.css",
                 "~/Content/toastr.css",
                 "~/Content/less/Login.css"
                ));
            bundles.Add(new StyleBundle("~/Content/main/main").Include(
                "~/Content/less/reset.css",
                 "~/Content/bootstrap.css",
                 "~/Content/kendo/kendo.common.min.css",
                 "~/Content/kendo/kendo.common-bootstrap.min.css",
                 "~/Content/kendo/kendo.bootstrap.min.css",
                "~/Content/kendo/kendo.silver.min.css",
                 "~/Content/toastr.css",
                 "~/Content/ fullcalendar.print.css",
                 "~/Content/fullcalendar.css",
                //"~/Content/sidebar.css",
                 "~/Content/superTables/superTables.css",
                 "~/Content/less/admin.css",
                 "~/Content/kendo/kendo.dataviz.min.css",
                 "~/Content/kendo/kendo.dataviz.default.min.css"
                ));
        }
    }
}
