using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Models
{
    /// <summary>Represents a group entity with a unique identifier,
    /// required name, and collection of associated kids.</summary>
    public class Group
	{
        /// <summary>Gets or sets the group identifier.</summary>
        /// <value>The group identifier.</value>
        public int GroupId { get; set; }

        /// <summary>Gets or sets the name of the group.</summary>
        /// <value>The name of the group.</value>
        [Required]
		public string GroupName { get; set; }

        /// <summary>Gets or sets the kids.</summary>
        /// <value>The kids.</value>
        public virtual ICollection<Kid> Kids { get; set; }	= new HashSet<Kid>();
	}
}
