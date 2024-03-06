using Azure;
using Kindergarden_Data;
using Kindergarden_Models;
using Kindergarden_Services.ViewModels;
using Microsoft.EntityFrameworkCore;
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
            
            var parent = db.Parents.FirstOrDefault(x => x.ParentId == id);
            if (parent != null)
            {
                if(parent.Kids==null)
                {
                    db.Parents.Remove(parent);
                }
            }
            db.SaveChanges();


        }

        public ParentViewModel Fetch(int id)
        {
            var pvm = new ParentViewModel();
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
    }
}
