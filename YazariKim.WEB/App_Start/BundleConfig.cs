using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace YazariKim.WEB.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //< script src = "" ></ script >
 
            //    < script src = "" ></ script >
  
            //    < script src = "" ></ script >
   
            //    < script src = "" ></ script >
    
            //    < script src = "" ></ script >
     
            //    < script src = "" ></ script >
      
            //    < script src = "" ></ script >
       
            //    < script src = "" ></ script >
        
            //    < script src = "" ></ script >

                     BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/js").Include("~/Assets/js/lib/jquery/jquery.min.js",
            "~/Assets/js/lib/bootstrap/js/popper.min.js",
            "~/Assets/js/lib/bootstrap/js/bootstrap.min.js",
            "~/Assets/js/lib/bootstrap/js/popper.min.js",
            "~/Assets/js/jquery.slimscroll.js",
            "~/Assets/js/sidebarmenu.js",
            "~/Assets/js/lib/sticky-kit-master/dist/sticky-kit.min.js",
            "~/Assets/js/custom.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jstable").Include("~/Assets/js/lib/datatables/datatables.min.js",
                "~/Assets/js/lib/datatables/cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js",
                "~/Assets/js/lib/datatables/cdn.datatables.net/buttons/1.2.2/js/buttons.flash.min.js",
                "~/Assets/js/lib/datatables/cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js",
                "~/Assets/js/lib/datatables/cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js",
                "~/Assets/js/lib/datatables/cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js",
                "~/Assets/js/lib/sticky-kit-master/dist/sticky-kit.min.js",
                "~/Assets/js/lib/datatables/cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js",
                "~/Assets/js/lib/datatables/cdn.datatables.net/buttons/1.2.2/js/buttons.print.min.js",
                "~/Assets/js/lib/datatables/datatables-init.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include("~/Assets/css/lib/bootstrap/bootstrap.min.css",
           "~/Assets/css/helper.css",
           "~/Assets/css/style.css",
		  "~/Assets/icons/font-awesome/css/font-awesome.min.css"));
        }
    }
}