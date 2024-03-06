using Kindergarden_Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    public interface IParentService
    {
        public void CreateParent(string firstName, string lastName, int age, string parentFirstName, string parentLastName, string phoneNumber, string address);
        public void Delete(int id);
        public ParentViewModel Fetch(int id);
    }
}
