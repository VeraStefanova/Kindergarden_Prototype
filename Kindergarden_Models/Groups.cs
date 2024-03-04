using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Models
{
	public class Groups
	{
        public Groups()
        {
                this.KidInGroup = new Hashset<Kids>();
        }
        public int GroupId { get; set; }

        public string GroupName { get; set; }

		public ICollection<Kids> KidInGroup { get; set; }	w
    }
}
