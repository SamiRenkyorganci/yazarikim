using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class Languages:EntityBase
	{
		[Display(Name = "Dil")]
		public string Language { get; set; } // Dilin ismi . Örn : ingilizce , türkçe vb..

		public virtual IEnumerable<Book> book { get; set; }// Book tablosunu gizli olarak ekliyoruz yani ilişkilendiriyoruz. 


	}
}
