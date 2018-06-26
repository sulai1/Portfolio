using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Articles.Models
{
    [Serializable]
    [Area("Articles")]
    public class Article
    {
        public int ArticleId { get; set; }
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime LastModified { get; set; }

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }
        public virtual IdentityUser Owner { get; set; }
        public virtual List<Group> Group { get; set; }
        public bool IsPublic { get; set; }
    }
}
