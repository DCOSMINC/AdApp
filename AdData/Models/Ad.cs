using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdData.Models
{
    public class Ad
    {
        public Ad()
        {
            Comments = new HashSet<Comment>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public int UserIdVal { get; set; }
        public int CategoryIdVal { get; set; }

        public byte[] Image { get; set; }
        

        public  User User { get; set; }
        
        public  Category Category { get; set; }

        public string CommentValue { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}
