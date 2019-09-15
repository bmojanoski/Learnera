using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnera.Models
{
    public class Reply
    {
        public int ReplyId { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }

      
        public virtual ApplicationUser Author { get; set; }
  
        public virtual List<ApplicationUser> ReplyApplicationUser { get; set; }
        
        public virtual Comment CommentReplies { get; set; }
    }
}