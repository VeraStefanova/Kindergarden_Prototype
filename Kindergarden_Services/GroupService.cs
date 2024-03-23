using Kindergarden_Data;
using Kindergarden_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    /// <summary>
    /// Service class for managing groups within a kindergarten.
    /// </summary>
    public class GroupService : IGroupService
    {
        /// <summary>Initializes a new instance of the <see cref="GroupService" /> class.</summary>
        /// <param name="db">The database.</param>
        public GroupService(KindergardenDbContext db)
        {
            this.db = db;
        }
        private KindergardenDbContext db;

        /// <summary>Fetches the wanted Group by it's id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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
