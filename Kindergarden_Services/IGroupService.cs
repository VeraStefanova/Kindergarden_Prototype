using Kindergarden_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    /// <summary>
    /// Interface for retrieving group information.
    /// </summary>
    public interface IGroupService
    {
        /// <summary>Fetches the wanted Group by it's id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Group Fetch(int id);


    }
}
