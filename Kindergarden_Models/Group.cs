using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Models
{
	public class Group
	{
		public Group()
		{
			this.Kids = new HashSet<Kid>();
		}
		
		
		public int GroupId { get; set; }

		[Required]
		public string GroupName { get; set; }

		public virtual ICollection<Kid> Kids { get; set; }	
	}
}
