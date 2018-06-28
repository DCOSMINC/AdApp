using System;


namespace AdData.Models
{
    public class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
