using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdData.Models
{
    public class User
    {

        public User()
        {
            Ads = new HashSet<Ad>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }

        public virtual IEnumerable<Ad> Ads { get; set; }
    }
}
