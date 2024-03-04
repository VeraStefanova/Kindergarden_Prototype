using System.ComponentModel.DataAnnotations;

namespace Kindergarden_Models
{
    public class Kids
    {
        public int KidId { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ParentId { get; set; }
        public int GroupId { get; set; }



    }
}
