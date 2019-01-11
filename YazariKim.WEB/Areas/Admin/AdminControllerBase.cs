using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace YazariKim.WEB.Areas.Admin
{
	public class AdminControllerBase:Controller
	{
		protected override void Initialize(RequestContext requestContext)
		{
			var IsLogin = false;
			if (requestContext.HttpContext.Session["AdminLogin"]== null)
			{
				//Admin girişi yapılmamış 
				requestContext.HttpContext.Response.Redirect("/Admin/AdminLogin");
			}
			else
			{
				//Admin içerde 
				//Sayfayı çalıştır
				base.Initialize(requestContext);
			}
		}

	}
}