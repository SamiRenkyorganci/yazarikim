using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
 public	class Book_Type:EntityBase
	{
		[Display(Name = "Tür Adı")]
		public int Typeid { get; set; } // türün idsi

		public Types types { get; set; }// type id ilişkilendiriyoruz.
		[Display(Name = "Kitap Adı")]
		public int Bookid { get; set; }// kitabın idsi

		public Book book { get; set; }// book id ile ilişkilendiriyoruz
	}
}
