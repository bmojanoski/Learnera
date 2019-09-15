using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnera.Models
{
    public class CommentReply
    {
        [Key, Column(Order = 1)]
        public int CommentId { get; set; }
        [Key, Column(Order = 2)]
        public int ReplyId { get; set; }

        public Comment comment { get; set; }
        public Reply reply { get; set; }
    }
}