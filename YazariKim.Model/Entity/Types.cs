using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class Types : EntityBase
	{
		[Display(Name = "Tür Adı")]
		public string Type { get; set; } // Tür ismi . Örn : bilimkurgu, aksiyon vb..

		public virtual IEnumerable<Book_Type> book_types { get; set; }



	}
}
