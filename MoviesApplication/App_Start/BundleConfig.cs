using System.Web;
using System.Web.Optimization;

namespace MoviesApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
                bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/Vendors/modernizr.js"));

                bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                    "~/Scripts/Vendors/jquery.js",
                    "~/Scripts/Vendors/bootstrap.js",
                    "~/Scripts/Vendors/toastr.js",
                    "~/Scripts/Vendors/jquery.raty.js",
                    "~/Scripts/Vendors/respond.src.js",
                    "~/Scripts/Vendors/angular.js",
                    "~/Scripts/Vendors/angular-route.js",
                    "~/Scripts/Vendors/angular-cookies.js",
                    "~/Scripts/Vendors/angular-validator.js",
                    "~/Scripts/Vendors/angular-base64.js",
                    "~/Scripts/Vendors/angular-file-upload.js",
                    "~/Scripts/Vendors/angucomplete-alt.min.js",
                    "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",
                    "~/Scripts/Vendors/underscore.js",
                    "~/Scripts/Vendors/raphael.js",
                    "~/Scripts/Vendors/morris.js",
                    "~/Scripts/Vendors/jquery.fancybox.js",
                    "~/Scripts/Vendors/jquery.fancybox-media.js",
                    "~/Scripts/Vendors/loading-bar.js"));

                bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                    "~/Scripts/SPA/modules/common.core.js",
                    "~/Scripts/SPA/modules/common.ui.js",
                    "~/Scripts/SPA/app.js",
                    "~/Scripts/SPA/services/apiService.js",
                    "~/Scripts/SPA/services/notificationService.js",
                    "~/Scripts/SPA/services/membershipService.js",
                    "~/Scripts/SPA/services/fileUploadService.js",
                    "~/Scripts/SPA/layout/topBar.directive.js",
                    "~/Scripts/SPA/layout/sideBar.directive.js",
                    "~/Scripts/SPA/layout/customPager.directive.js",
                    "~/Scripts/SPA/directives/rating.directive.js",
                    "~/Scripts/SPA/layout/availableProduct.directive.js",
                    "~/Scripts/SPA/account/loginCtrl.js",
                    "~/Scripts/SPA/account/registerCtrl.js",
                    "~/Scripts/SPA/home/rootCtrl.js",
                    "~/Scripts/SPA/home/indexCtrl.js",
                    "~/Scripts/SPA/customers/customersCtrl.js",
                    "~/Scripts/SPA/customers/customerRegCtrl.js",
                    "~/Scripts/SPA/customers/customerEditCtrl.js",
                    "~/Scripts/SPA/movies/moviesCtrl.js",
                    "~/Scripts/SPA/movies/movieAddCtrl.js",
                    "~/Scripts/SPA/movies/movieDetailsCtrl.js",
                    "~/Scripts/SPA/movies/movieEditCtrl.js",
                    "~/Scripts/SPA/controllers/rentalCtrl.js",
                    "~/Scripts/SPA/rental/rentMovieCtrl.js",
                    "~/Scripts/SPA/rental/rentStatsCtrl.js",
                    "~/Scripts/SPA/validators/dateValidator.js"));

                bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/css/site.css",
                    "~/Content/css/bootstrap.css",
                    "~/Content/css/bootstrap-theme.css",
                     "~/Content/css/font-awesome.css",
                    "~/Content/css/morris.css",
                    "~/Content/css/toastr.css",
                    "~/Content/css/jquery.fancybox.css",
                    "~/Content/css/loading-bar.css"));
            #if DEBUG
                BundleTable.EnableOptimizations = false;
            #else
                BundleTable.EnableOptimizations = true;
            #endif
        }
    }
}
