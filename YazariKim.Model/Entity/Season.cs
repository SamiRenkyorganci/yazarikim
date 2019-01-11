using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	 public class Season:EntityBase
	{
		[Display(Name = "Dönem Adı")]
		public string SeasonName { get; set; }//Dönem Adı
	}
}
