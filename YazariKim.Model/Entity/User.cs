using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class User:EntityBase
	{
	    [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
	    [Display(Name = "Şifre")]
        public string Password { get; set; }
	    [Display(Name = "Admin")]
        public bool AdminControl { get; set; }

	}
}
