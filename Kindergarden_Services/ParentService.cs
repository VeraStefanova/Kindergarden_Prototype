using Azure;
using Kindergarden_Data;
using Kindergarden_Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public Parent Fetch(int id)
        {
            var pvm = new Parent();
            var parent = db.Parents.FirstOrDefault(x => x.ParentId == id);
            if (parent != null)
            {
                pvm.ParentId = parent.ParentId;
                pvm.Name = parent.FirstName + " " + parent.LastName;
                pvm.PhoneNumber = parent.PhoneNumber;
                pvm.Address = parent.Address;
                return pvm;
            }
            else return null;
        }

        public bool UpdateName(int id, string newName)
        {
            var parentEntity = db.Parents.FirstOrDefault(x => x.ParentId == id);
            string[] name = newName.Trim().Split().ToArray();
            if (parentEntity != null)
            {
                parentEntity.FirstName = name[0];
                parentEntity.LastName = name[1];
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public bool UpdatePN(string oldPN, string newPN)
        {
            var parentEntity = db.Parents.FirstOrDefault(x => x.PhoneNumber == oldPN);
            if (parentEntity != null)
            {
                parentEntity.PhoneNumber = newPN;
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
        public bool UpdateAddress(string oldAddress, string newAddress)
        {
            var parentEntity = db.Parents.FirstOrDefault(x => x.Address == oldAddress);
            if (parentEntity != null)
            {
                parentEntity.Address = newAddress;
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }

        
    }
}
