using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learnera.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual List<ApplicationUser> LikedByUsers { get; set; }
        public virtual Comment Comment { get; set; }
    }
}