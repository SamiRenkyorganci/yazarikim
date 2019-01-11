using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class Writer_Pictures:EntityBase
	{
		[Display(Name = "Fotoğraf URL")]
		public string PicturesUrl { get; set; }

		[Display(Name = "Yazar")]
		public int Writerid { get; set; }

		public Writer writer { get; set; }
	}
}
