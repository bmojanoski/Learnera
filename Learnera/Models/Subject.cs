using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learnera.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Presentation> Presentation { get; set; }
        public virtual List<ApplicationUser> Student { get; set; }
        public string Professor { get; set; }
    }
}