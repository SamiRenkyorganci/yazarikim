using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class Writer_Job:EntityBase
	{
		[Display(Name = "Yazar")]
		public int Writerid { get; set; }

		public Writer writer { get; set; }

		[Display(Name = "Meslek")]
		public int Jobid { get; set; }

		public Job job { get; set; }
	}
}
