
using Portfolio.Areas.Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Portfolio.Areas.Articles.Data
{
    public class SectionBuilder
    {
        public int Index { get; set; }
        public string Title { get; set; }

        public virtual List<SubSection> SubSections { get; set; }


        public void Deserialize(string JSon)
        {
            throw new NotImplementedException();
        }

        public string Serialize()
        {
            throw new NotImplementedException();
        }
    }

    public class SubSection
    {
        public string Title { get; set; }
        public virtual Content Content { get; set; }
        public string Example { get; set; }
    }

    public class Content
    {
        public string Text { get; set; }
        public List<Blob> Image { get; set; }
    }
}
