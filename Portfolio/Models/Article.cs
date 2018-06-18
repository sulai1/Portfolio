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
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
