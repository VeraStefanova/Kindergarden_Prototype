﻿using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarden_Data;
using Kindergarden_Models;
using Kindergarden_Services.ViewModels;

namespace Kindergarden_Services
{
    public class KidService : IKidService
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
                kid.GroupId = 1;
            }
            else if(kid.Age==4)
            {
                kid.GroupId = 2;
            }
            else if(kid.Age==5)
            {
                kid.GroupId = 3;
            }
            else if(kid.Age==6)
            {
                kid.GroupId = 4;
            }

            kid.ParentId = parentEntity.ParentId;
            db.Kids.Add(kid);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var kid = db.Kids.FirstOrDefault(x => x.KidId == id);
            if (kid != null)
            {
                db.Kids.Remove(kid);
            }
            else
            {
                Console.WriteLine($"Did not find kid with id: {id}.");
            }
            db.SaveChanges();
        }

        public KidViewModel Fetch(int id)
        {
            var kvm = new KidViewModel();
            var kid = db.Kids.FirstOrDefault(x => x.KidId == id);
            if (kid != null)
            {
                kvm.KidId = kid.KidId;
                kvm.Name = kid.FirstName + " " + kid.LastName;
                kvm.Age = kid.Age;
                kvm.ParentName = kid.Parent.FirstName + " " + kid.Parent.LastName;
                kvm.GroupName = kid.Group.GroupName;
                return kvm;
            }
            else return null;
        }
    }
}
