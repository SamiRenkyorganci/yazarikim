using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	 public class Book_Pictures:EntityBase
	{
		[Display(Name = "Fotoğraf Url")]
		public string PictureUrl { get; set; }// fotoğrafın urlsi
		[Display(Name = "Kitap Adı")]
		public int bookid { get; set; } // kitap idsi
		[Display(Name = "Kitap Adı")]
		public Book Books { get; set; }// book id ile ilişkilendiriyoruz
	}
}
