using System;


namespace AdData.Models
{
    public class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
