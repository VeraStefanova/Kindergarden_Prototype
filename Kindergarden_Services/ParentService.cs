using Azure;
using Kindergarden_Data;
using Kindergarden_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    public class ParentService : IParentService
    {
        public ParentService(KindergardenDbContext db)
        {
            this.db = db;
        }

        private KindergardenDbContext db;

        public void CreateParent(string firstName, string lastName, int age, string parentFirstName, string parentLastName, string phoneNumber, string address)
        {
            //TODO: find a way to call CreateKid from KidService
            //KidService.CreateKid(firstName, lastName, age, parentFirstName, parentLastName, phoneNumber, address); NOT RIGHT
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Fetch(int id)
        {
            throw new NotImplementedException();
        }
    }
}
