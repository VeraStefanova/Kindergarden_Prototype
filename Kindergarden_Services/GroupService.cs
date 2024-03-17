using Kindergarden_Data;
using Kindergarden_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    public class GroupService : IGroupService
    {
        public GroupService(KindergardenDbContext db)
        {
            this.db = db;
        }
        private KindergardenDbContext db;

        public Group Fetch(int id)
        {
            var group = db.Groups.FirstOrDefault(x => x.GroupId == id);
            if (group != null)
            {
                group.GroupName = group.GroupName;
                foreach(var kid in group.Kids)
                {
                    group.Kids.Add(kid);
                }
                return group;
            }
            else return null;
            
        }
    }
}
