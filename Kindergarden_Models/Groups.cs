﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Models
{
	public class Groups
	{
		public Groups()
		{
			this.KidInGroup = new HashSet<Kids>();
		}
		
		[Key]
		public int GroupId { get; set; }

		[Required]
		public string GroupName { get; set; }

		public virtual ICollection<Kids> KidInGroup { get; set; }	
	}
}
