using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class Writer:EntityBase
	{
		[Display(Name = "Yazar Adı")]
		public string Name { get; set; }//Yazar ismi

		[Display(Name = "Yazar Soyadı")]
		public string LastName { get; set; } // Yazar Soyadı
		[Display(Name = "Yazar Hakkında")]
		public string Detail { get; set; }//Detay
		[Display(Name = "Doğum Tarihi")]
		public DateTime BirthDate { get; set; }//Doğum Tarihi
		[Display(Name = "Ölüm Tarihi")]
		public DateTime? DeathTime { get; set; }//Ölüm tarihi ? simgesi ise girme zorunluluğu yok
		[Display(Name = "Milliyeti")]
		public int Countryid { get; set; }//Ülke idsi

		public Country Country { get; set; }

		public virtual IEnumerable<Writer_Season> writer_seasons { get; set; }

		public virtual IEnumerable<Writer_Pictures> writer_pictures { get; set; }

		public virtual IEnumerable<Writer_Job> Writer_Jobs { get; set; }

		public virtual IEnumerable<Writer_Book> Writer_Books { get; set; }

	}
}
