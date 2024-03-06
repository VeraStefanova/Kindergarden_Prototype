using Kindergarden_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services.ViewModels
{
    public class GroupViewModel
    {
        public GroupViewModel()
        {
            Kids = new List<Kid>();
        }
        public string Name { get; set; }
        public List<Kid> Kids { get; set; }


    }
}
