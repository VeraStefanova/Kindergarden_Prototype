﻿using Kindergarden_Models;
using Kindergarden_Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    public interface IGroupService
    {
        public Group Fetch(int id);


    }
}
