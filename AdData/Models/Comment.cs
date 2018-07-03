using System;
using System.Collections.Generic;
using System.Text;

namespace AdData.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AddedComment { get; set; }
        public virtual Ad Ad { get; set; }
        public virtual User User { get; set; }

    }
}
