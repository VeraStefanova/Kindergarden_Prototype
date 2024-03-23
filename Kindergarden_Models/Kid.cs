using System.ComponentModel.DataAnnotations;

namespace Kindergarden_Models
{
    /// <summary>Represents a child entity with a unique identifier, required first name,
    /// last name, and optional age, associated parent, and group.</summary>
    public class Kid
    {

        /// <summary>Gets or sets the kid identifier.</summary>
        /// <value>The kid identifier.</value>
        public int KidId { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        [Required]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        [Required]
        public string LastName { get; set; }
        /// <summary>Gets or sets the age.</summary>
        /// <value>The age.</value>
        public int Age { get; set; }
        /// <summary>Gets or sets the parent identifier.</summary>
        /// <value>The parent identifier.</value>
        public int ParentId { get; set; }
        /// <summary>Gets or sets the parent.</summary>
        /// <value>The parent.</value>
        public virtual Parent Parent { get; set; }
        public int GroupId { get; set; }
        /// <summary>Gets or sets the group.</summary>
        /// <value>The group.</value>
        public virtual Group Group { get; set; }
    }
}
