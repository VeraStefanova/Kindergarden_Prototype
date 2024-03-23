using Kindergarden_Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    /// <summary>
    /// Interface for managing parent-related operations such as fetching and updating parent information.
    /// </summary>
    public interface IParentService
    {
        /// <summary>Fetches the specified Parent by kid's Id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Parent Fetch(int id);
        /// <summary>Updates the name.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newName">The new name.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool UpdateName(int id,string newName);
        /// <summary>Updates the address.</summary>
        /// <param name="oldAddress">The old address.</param>
        /// <param name="newAddress">The new address.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool UpdateAddress(string oldAddress,  string newAddress);
        /// <summary>Updates the phone number.</summary>
        /// <param name="pn1">The PN1.</param>
        /// <param name="pn">The pn.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool UpdatePN(string pn1, string pn);
    }
}
