﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Articles.Models
{
    [Area("Articles")]
    public class Section
    {
        public int SectionId { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
