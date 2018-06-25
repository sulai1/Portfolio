using Newtonsoft.Json;
using NJsonSchema;
using NJsonSchema.Converters;
using NJsonSchema.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Portfolio.Areas.Articles.Models
{
    [JsonConverter(typeof(JsonInheritanceConverter))]
    [KnownType(typeof(TextContent))]
    [KnownType(typeof(CodeContent))]
    [KnownType(typeof(ExampleContent))]
    [KnownType(typeof(ImageContent))]
    public abstract class IContent
    {
        public abstract string Display();
    }
}
