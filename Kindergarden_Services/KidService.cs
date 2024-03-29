﻿using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarden_Data;
using Kindergarden_Models;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using System.Data.Common;
using System.Threading.Channels;

namespace Kindergarden_Services
{
    /// <summary>
    /// Service for managing kid-related operations such as creation, deletion, updating, and fetching.
    /// </summary>
    public class KidService : IKidService
    {

        /// <summary>Initializes a new instance of the <see cref="KidService" /> class.</summary>
        /// <param name="db">The database.</param>
        public KidService(KindergardenDbContext db)
        {
            this.db = db;
        }
         
        private KindergardenDbContext db;
        /// <summary>Creates the kid.</summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="age">The age.</param>
        /// <param name="parentFirstName">First name of the parent.</param>
        /// <param name="parentLastName">Last name of the parent.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="address">The address.</param>
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
                kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            else if(kid.Age==4)
            {
                var group = db.Groups.FirstOrDefault(x => x.GroupId == 2);
                kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            else if(kid.Age==5)
            {
                var group = db.Groups.FirstOrDefault(x => x.GroupId == 3);
                kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            else if(kid.Age==6)
            {
                var group = db.Groups.FirstOrDefault(x => x.GroupId == 4);
                kid.GroupId = group.GroupId;
                kid.Group = group;
            }

            kid.Parent = parentEntity;

            db.Kids.Add(kid);
            db.SaveChanges();
        }


        /// <summary>Deletes the specified kid by name.</summary>
        /// <param name="kidName">Name of the kid.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool Delete(string kidName)
        {
            var kid = db.Kids.FirstOrDefault(x => x.FirstName == kidName); 
            if (kid != null)
            {
                Kid kid2;
                Parent parent = kid.Parent; // Викам родителя на детето на което искам да изтрия
                db.Kids.Remove(kid); //изтривам детето, но родителя остава
                db.SaveChanges(); //Inache ne trie deteto i ne moga da napravq tyrsenento

                kid2 = db.Kids.FirstOrDefault(x=>x.ParentId==parent.ParentId);

                if (kid2 == null) //Sled iztrivaneto na tova dete proverqvame dali tozi roditel, na iztritoto veche dete, ima drugi deca
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

        /// <summary>Fetches the kid and parent.</summary>
        /// <param name="kidName">Name of the kid.</param>
      
        public Kid FetchKidAndParent(string kidName)
        {
            var kid = db.Kids.FirstOrDefault(x => x.FirstName == kidName.Trim());
            
            if (kid != null)
            {
                return kid;
            }
            else return null;
        }

        /// <summary>Updates the kid's name.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newName">The new name.</param>
   
        public bool UpdateName(int id, string newName)// въвежда се цялото име на детето
        {
            var kidtEntity = db.Kids.FirstOrDefault(x => x.KidId == id);  // Търси дете
            string[] name = newName.Trim().Split().ToArray(); //сплитваме го
            if (kidtEntity != null) //проверка за наличие
            {
                kidtEntity.FirstName = name[0];
                kidtEntity.LastName = name[1];
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }

        /// <summary>Updates the kid's age.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newAge">The new age.</param>
        
        public bool UpdateAge(int id, int newAge)
        {
            var kid = db.Kids.FirstOrDefault(x => x.KidId == id);
            if (kid != null)
            {
                kid.Age = newAge;
                if (kid.Age == 3) //според годините ходи в съответната група
                {
                    var group = db.Groups.FirstOrDefault(x => x.GroupId == 1);
                    //kid.GroupId = group.GroupId;
                    kid.Group = group;
                }
                else if (kid.Age == 4)
                {
                    var group = db.Groups.FirstOrDefault(x => x.GroupId == 2);
                    //kid.GroupId = group.GroupId;
                    kid.Group = group;
                }
                else if (kid.Age == 5)
                {
                    var group = db.Groups.FirstOrDefault(x => x.GroupId == 3);
                    //kid.GroupId = group.GroupId;
                    kid.Group = group;
                }
                else if (kid.Age == 6)
                {
                    var group = db.Groups.FirstOrDefault(x => x.GroupId == 4);
                    //kid.GroupId = group.GroupId;
                    kid.Group = group;
                }
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
