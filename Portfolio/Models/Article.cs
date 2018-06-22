using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    [Serializable]
    public class Article
    {
        public int ArticleId { get; set; }
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        [Required]
        public virtual IdentityUser Owner { get; set; }
        public virtual List<Group> Group { get; set; }
        public bool IsPublic { get; set; }
    }
}
