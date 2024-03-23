using Kindergarden_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_Services
{
    /// <summary>
    /// Interface for managing kid-related operations such as creation, deletion, updating, and fetching.
    /// </summary>
    public interface IKidService
    {
        /// <summary>Creates the kid.</summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="age">The age.</param>
        /// <param name="parentFirstName">First name of the parent.</param>
        /// <param name="parentLastName">Last name of the parent.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="address">The address.</param>
        public void CreateKid(string firstName, string lastName, int age, string parentFirstName, string parentLastName, string phoneNumber, string address);
        /// <summary>Deletes the specified kid by name.</summary>
        /// <param name="kidName">Name of the kid.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool Delete(string kidName);
        /// <summary>Fetches the kid and parent.</summary>
        /// <param name="kidName">Name of the kid.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Kid FetchKidAndParent(string kidName);
        /// <summary>Updates the kid's name.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newName">The new name.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool UpdateName(int id, string newName);
        /// <summary>Updates the kid's age.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newAge">The new age.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool UpdateAge(int id, int newAge );



    }
}
