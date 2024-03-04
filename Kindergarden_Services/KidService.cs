﻿using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarden_Data;
using Kindergarden_Models;

namespace Kindergarden_Services
{
    public class KidService
    {
        public KidService(KindergardenDbContext db)
        {
            this.db = db;
        }

        private KindergardenDbContext db;
        public void CreateKid(string firstName, string lastName, int age, string parentFirstName, string parentLastName, string phoneNumber, string address)
        {
            Kid kid = new Kid
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,

            };
            
            var parentEntity = db.Parents.FirstOrDefault(x => x.PhoneNumber.Trim()==phoneNumber.Trim());
            if(parentEntity==null)
            {
                 parentEntity = new Parent
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Address = address
                };

                db.Parents.Add(parentEntity);
                
            }
            if(kid.Age==3)
            {
                
            }
            else if(kid.Age==4)
            {

            }
            else if(kid.Age==5)
            {

            }
            else if(kid.Age==6)
            {

            }

            kid.ParentId = parentEntity.ParentId;
            db.Kids.Add(kid);
            db.SaveChanges();
        }
        public void Add()
        {
            Kid kid = new Kid();
        }
    }
}