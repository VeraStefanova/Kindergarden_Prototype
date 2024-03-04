using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Models
{
    internal class Groups
    {
		private int groupId;

		public int GroupId
		{
			get { return groupId; }
			set { groupId = value; }
		}

		private string groupName;

		public string GroupName
		{
			get { return  groupName; }
			set {  groupName = value; }
		}

	}
}
