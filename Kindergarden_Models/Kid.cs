using System.ComponentModel.DataAnnotations;

namespace Kindergarden_Models
{
    public class Kid
    {
        
        public int KidId { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
