﻿using Kindergarden_Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    public interface IGroupService
    {
        public GroupViewModel Fetch(int id);


    }
}
