using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class Writer_Season:EntityBase
	{
		[Display(Name = "Dönem Adı")]
		public int Seasonid { get; set; }//Season idsi

		public Season Season { get; set; }
		[Display(Name = "Yazar")]
		public int Writerid { get; set; }// yazar idsi

		public Writer Writer { get; set; }
	}
}
