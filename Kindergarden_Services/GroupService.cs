using Kindergarden_Data;
using Kindergarden_Services.ViewModels;
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

        public GroupViewModel Fetch(int id)
        {
            var gvm = new GroupViewModel();
            var group = db.Groups.FirstOrDefault(x => x.GroupId == id);
            if (group != null)
            {
                gvm.Name = group.GroupName;
                foreach(var kid in group.Kids)
                {
                    gvm.Kids.Add(kid);
                }
                return gvm;
            }
            else return null;
            
        }
    }
}
