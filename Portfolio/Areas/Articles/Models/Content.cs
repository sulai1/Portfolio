using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Articles.Models
{
    public class TextContent : IContent
    {
        [Newtonsoft.Json.JsonProperty("Text")]
        public string Text { get; set; }

        override
        public string Display()
        {
            return Text;
        }
    }

    public class CodeContent : TextContent
    {
        [Newtonsoft.Json.JsonProperty("Type")]
        public string Type { get; set; }

        override
        public string Display()
        {
            string output = String.Format("<pre><code>{1}</code></pre>", Type, Text);
            return output;
        }
    }

    public class ExampleContent : CodeContent
    {

        override
        public string Display()
        {
            return Text;
        }
    }

    public class ImageContent : IContent
    {
        [Newtonsoft.Json.JsonProperty("Path")]
        public string Path { get; set; }
        [Newtonsoft.Json.JsonProperty("Alt")]
        public string Alt { get; set; }

        override
        public string Display()
        {
            return String.Format("<img src=\"{0}\" alt=\"{1}\"></img>", Path, Alt);
        }
    }
}
