using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Models
{
    public class Parents
    {
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Kids> Kids { get; set; }

        public Parents()
        {
            Kids = new HashSet<Kids>();
        }

    }
}
