using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model
{
	public class EntityBase //Base classı tekrarlayan tablo değişkenleri miras yoluyla tekrarı engeller.
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }// Her tabloda olacak id 

		public DateTime CreateDate { get; set; }//Kayıt edilme tarihi

		public int CreateUserID { get; set; }

		public DateTime? UpdateDate { get; set; } // Güncelleme tarihi

		public int? UpdateUserID { get; set; }

		

	}
	

}
