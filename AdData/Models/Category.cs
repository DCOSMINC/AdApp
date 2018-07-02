
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdData.Models
{
    public class Category
    {
        public Category()
        {
            Ads = new HashSet<Ad>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public virtual IEnumerable<Ad> Ads { get; set; }
    }
}
