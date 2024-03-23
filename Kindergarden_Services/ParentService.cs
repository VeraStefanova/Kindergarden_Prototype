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
    /// <summary>
    /// Service for managing parent-related operations such as fetching and updating parent information.
    /// </summary>
    public class ParentService : IParentService
    {
        /// <summary>Initializes a new instance of the <see cref="ParentService" /> class.</summary>
        /// <param name="db">The database.</param>
        public ParentService(KindergardenDbContext db)
        {
            this.db = db;
        }

        private KindergardenDbContext db;

        /// <summary>Fetches the specified Parent by kid's Id.</summary>
        /// <param name="id">The identifier.</param>
  
        public Parent Fetch(int id)
        {
            
            var parent = db.Parents.FirstOrDefault(x => x.ParentId == id);
            if (parent != null)
            {
                
               return parent;
            }
            else return null;
        }

        /// <summary>Updates the parent's name.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newName">The new name.</param>

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

        /// <summary>Updates the phone number.</summary>
        /// <param name="oldPN"></param>
        /// <param name="newPN"></param>
         
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
        /// <summary>Updates the address.</summary>
        /// <param name="oldAddress">The old address.</param>
        /// <param name="newAddress">The new address.</param>
       
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
