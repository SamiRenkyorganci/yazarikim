using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazariKim.Model;

namespace YazariKim.WEB.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
		YazariKimDB db = new YazariKimDB();
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(string UserName,string Password)
		{
			var data = db.Users.Where(x => x.UserName == UserName && x.Password == Password && x.AdminControl == true).ToList();
			if (data.Count==1)
			{
				//Doğru Giriş
				Session["AdminLogin"] = data.FirstOrDefault();
				return Redirect("/admin");
			}
			else
			{
				//Hatalı giriş
				return View();
			}
			
		}
	}
}