using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learnera.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Slide Slide { get; set; }
        public virtual List<Reply> Replies { get; set; }
        public virtual List<ApplicationUser> LikedByUsers { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}