using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Models
{
    /// <summary>Represents a parent entity with a unique identifier, first name,
    /// last name, phone number, address, and collection of associated kids.</summary>
    public class Parent
    {
        /// <summary>Gets or sets the parent identifier.</summary>
        /// <value>The parent identifier.</value>
        public int ParentId { get; set; }
        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }
        /// <summary>Gets or sets the phone number.</summary>
        /// <value>The phone number.</value>
        public string PhoneNumber { get; set; }
        /// <summary>Gets or sets the address.</summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>Gets or sets the kids of one parent.</summary>
        /// <value>The kids of one parent.</value>
        public virtual ICollection<Kid> Kids { get; set; } = new HashSet<Kid>();



    }
}
