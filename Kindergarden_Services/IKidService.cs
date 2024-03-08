﻿using Kindergarden_Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    public interface IKidService
    {
        public void CreateKid(string firstName, string lastName, int age, string parentFirstName, string parentLastName, string phoneNumber, string address);
        public bool Delete(int id);
        KidViewModel Fetch(int id);
        //public void Update(int id);
        


    }
}
