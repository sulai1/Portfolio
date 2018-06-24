using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Articles.Models
{
    public class TextContent : IContent
    {
        public string Text { get; set; }

        public string Display()
        {
            return Text;
        }
    }

    public class CodeContent : IContent
    {
        public string Text { get; set; }
        public string Type { get; set; }

        public string Display()
        {
            string output = String.Format("<pre><code>{1}</code></pre>", Type, Text);
            return output;
        }
    }

    public class ExampleContent : IContent
    {
        public string Type { get; set; }
        public string Text { get; set; }

        public string Display()
        {
            return Text;
        }
    }

    public class ImageContent : IContent
    {
        public string Path { get; set; }
        public string Alt { get; set; }
        public string Display()
        {
            return String.Format("<img src=\"{0}\" alt=\"{1}\"></img>", Path, Alt);
        }
    }
}
