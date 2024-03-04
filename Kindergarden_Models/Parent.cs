using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Models
{
    public class Parent
    {
        public Parent()
        {
            Kids = new HashSet<Kid>();
        }
        
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Kid> Kids { get; set; }

        

    }
}
