using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Articles.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public virtual Article Article { get; set; }
        public virtual IdentityUser Owner { get; set; }
        public virtual List<IdentityUser> Member { get; set; }
    }
}
