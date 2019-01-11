using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class Book_Publisher:EntityBase
	{
		[Display(Name = "Yayınevi")]
		public int publisherid { get; set; }//publisher idsi
		
		public Publisher Publisher { get; set; }
		[Display(Name = "Kitap Adı")]
		public int Bookid { get; set; }//book idsi

		public Book book { get; set; }
	}
}
