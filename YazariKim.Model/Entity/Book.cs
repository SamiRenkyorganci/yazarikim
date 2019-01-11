using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	
	public class Book :EntityBase		//Miras alarak id değişkeni direkt olarak eklenir yazılmaya ihtiyaç duymaz.
	{
		[Display(Name = "Kitap Adı")]
		public string Name { get; set; } // Türkçe adı
		[Display(Name = "Orijinal Adı")]
		public string OrgName { get; set; } // Kitabın Orijinal adı
		[Display(Name = "Dil")]
		public int LangId { get; set; } // Kitabın dilinin idsi

		public Languages Languages { get; set; }// LangId değişlkeni ile key olarak ilişkilendirme işlemi yapıyoruz.
		[Display(Name = "Basım Tarihi")]
		public DateTime  PublishDate { get; set; } // Kitabın Basım tarihi
		[Display(Name = "Sayfa Sayısı")]
		public int PageNum { get; set; } // Sayfa Sayısı
		[Display(Name = "ISBN")]
		public string Isbn { get; set; }// ISBN numaraıs
		[Display(Name = "Barkod No")]
		public string Barkod { get; set; } //Barkod Numarası

		// [UIHint("tinymce_jquery_full"),AllowHtml]
		[AllowHtml]
		[UIHint("tinymce_jquery_full")]	
		[Display(Name = "Kitap Hakkında")]
		public string Detail { get; set; } //Detay


		public virtual IEnumerable<Book_Type> book_types { get; set; } // BookType tablosunun değişkenleri buraya da ekleniyor.

		public virtual IEnumerable<Book_Pictures> book_pictures { get; set; } // Pictures tablosu

		public virtual IEnumerable<Book_Publisher> book_publishers { get; set; } // BookPublisher tablosu

		public virtual IEnumerable<Writer_Book> Writer_Books { get; set; }

		//public virtual IEnumerable<Languages> Languages { get; set; }
	}
}
