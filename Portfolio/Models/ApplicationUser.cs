using Microsoft.AspNetCore.Identity;
using Portfolio.Areas.Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Article> Articles { get; set; }
    }
}
