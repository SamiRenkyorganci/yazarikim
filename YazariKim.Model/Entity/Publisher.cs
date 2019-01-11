using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class Publisher:EntityBase
	{
		[Display(Name = "Yayınevi Adı")]
		public string publisherName { get; set; }// Yayınevi adı
	}
}
