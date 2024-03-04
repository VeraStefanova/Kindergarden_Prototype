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
    internal class ParentService
    {
        public ParentService(KindergardenDbContext db)
        {
            this.db = db;
        }

        private KindergardenDbContext db;

        public void CreateParent(string firstName, string lastName, string phoneNumber, string address)
        {
            
                var parentEntity = new Parent
                {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Address = address
                };

                db.Parents.Add(parentEntity);
                db.SaveChanges();

           
            
            
            
        }
    }
}
