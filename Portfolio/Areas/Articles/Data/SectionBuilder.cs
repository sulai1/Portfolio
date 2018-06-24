
using Newtonsoft.Json;
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

        public string Title { get; set; }
        public virtual List<SubSection> SubSections { get; set; }
        public virtual List<IContent> Content { get; set; }

        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };


        public SectionBuilder()
        {
            this.SubSections = new List<SubSection>();
        }

        public static SectionBuilder Deserialize(string JSon)
        {
            return JsonConvert.DeserializeObject<SectionBuilder>(JSon, settings);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, settings);
        }
    }

    public class SubSection
    {
        public string Title { get; set; }
    }

    public interface IContent
    {
        string Text { get; set; }
    }

    public class TextContent : IContent
    {
        public string Text { get; set; }
    }

    public class CodeContent : TextContent
    {
        public string Type { get; set; }
    }

    public class ExampleContent : TextContent
    {
        public string Type { get; set; }
    }

    public class ImageContent : TextContent
    {
        public string Type { get; set; }
    }
}
