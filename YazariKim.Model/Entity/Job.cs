using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazariKim.Model.Entity
{
	public class Job:EntityBase
	{
		[Display(Name = "Meslek Adı")]
		public string JobName { get; set; }//Meslek ismi

		public virtual IEnumerable<Writer_Job> Writer_Jobs { get; set; }
	}
}
