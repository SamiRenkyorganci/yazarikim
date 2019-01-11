using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
   public class Country : EntityBase
	{
		[Display(Name = "Ülke Adı")]
		public string CountryName { get; set; }//Ülke ismi

		public virtual IEnumerable<Writer> writers { get; set; }
	}
}
