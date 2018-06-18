using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

public class Article
{
    public int Id { get; set; }
    public string Category { get; set; }

    public virtual List<Section> Sections { get; set; }
}

public class Section
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}