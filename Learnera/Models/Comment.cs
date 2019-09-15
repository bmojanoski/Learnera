using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnera.Models
{
    public class Comment
    {

        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        
        public virtual Slide Slide { get; set; }
       
        public virtual List<Reply> CommentReplies { get; set; }
      
        public virtual List<ApplicationUser> CommentApplicationUser { get; set; }
       
        public virtual ApplicationUser Author { get; set; }
    }
}