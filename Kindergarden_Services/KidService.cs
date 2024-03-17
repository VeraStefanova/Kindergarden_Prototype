using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarden_Data;
using Kindergarden_Models;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;

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

            var parentEntity = db.Parents.FirstOrDefault(x => x.PhoneNumber.Trim()==phoneNumber.Trim());  // търсим дали вече има такъв родител в програмата
            if(parentEntity==null)
            {
                 parentEntity = new Parent
                 {
                    FirstName = parentFirstName,
                    LastName = parentLastName,
                    PhoneNumber = phoneNumber,
                    Address = address
                 };

                db.Parents.Add(parentEntity);
            }

            if (kid.Age==3) //според годините ходи в съответната група
            {
                var group = db.Groups.FirstOrDefault(x => x.GroupId == 1);
                //kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            else if(kid.Age==4)
            {
                var group = db.Groups.FirstOrDefault(x => x.GroupId == 2);
                //kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            else if(kid.Age==5)
            {
                var group = db.Groups.FirstOrDefault(x => x.GroupId == 3);
                //kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            else if(kid.Age==6)
            {
                var group = db.Groups.FirstOrDefault(x => x.GroupId == 4);
                //kid.GroupId = group.GroupId;
                kid.Group = group;
            }

            kid.Parent = parentEntity;
            //kid.ParentId = parentEntity.ParentId;
            db.Kids.Add(kid);
            db.SaveChanges();
        }

        public bool Delete(string kidName)
        {
            var kid = db.Kids.FirstOrDefault(x => x.FirstName == kidName); 
            if (kid != null)
            {
                Parent parent = kid.Parent; // Викам родителя на детето на което искам да изтрия
                db.Kids.Remove(kid); //изтривам детето, но родителя остава

                parent.Kids.Remove(kid); // nz dali trie relationa i za tva go pravq ruchno

                if (parent.Kids.Count == 0) //Sled iztrivaneto na tova dete proverqvame dali tozi roditel, na iztritoto veche dete, ima drugi relation-i
                {
                    db.Parents.Remove(parent);
                }
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Kid FetchKidAndParent(string kidName)
        {
            var kid = db.Kids.FirstOrDefault(x => x.FirstName == kidName.Trim());
            
            if (kid != null)
            {
                var parent = db.Parents.FirstOrDefault(x => x.Kids.Contains(kid));
                var group = db.Groups.FirstOrDefault(x => x.Kids.Contains(kid));
                kvm.Name = kid.FirstName + " " + kid.LastName;
                kvm.Age = kid.Age;
                kvm.ParentName = parent.FirstName +" "+parent.LastName;
                kvm.PhoneNumber = parent.PhoneNumber;
                kvm.Address = parent.Address;
                kvm.GroupName = group.GroupName;
                return kvm; 
            }
            else return null;
        }

        public bool UpdateName(int id, string newName)
        {
            var kidtEntity = db.Kids.FirstOrDefault(x => x.KidId == id);
            string[] name = newName.Trim().Split().ToArray();
            if (kidtEntity != null)
            {
                kidtEntity.FirstName = name[0];
                kidtEntity.LastName = name[1];
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public bool UpdateAge(int id, int newAge)
        {
            var kidtEntity = db.Kids.FirstOrDefault(x => x.KidId == id);
            if (kidtEntity != null)
            {
                kidtEntity.Age = newAge;
                if (kidtEntity.Age == 3)
                {
                    kidtEntity.GroupId = 1;
                }
                else if (kidtEntity.Age == 4)
                {
                    kidtEntity.GroupId = 2;
                }
                else if (kidtEntity.Age == 5)
                {
                    kidtEntity.GroupId = 3;
                }
                else if (kidtEntity.Age == 6)
                {
                    kidtEntity.GroupId = 4;
                }
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
