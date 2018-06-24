using System;
using Xunit;
using Portfolio.Areas.Articles.Data;
using Newtonsoft.Json;
using Xunit.Abstractions;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Portfolio.Test
{
    public class SectionBuilderTest
    {

        private readonly ITestOutputHelper output;

        public SectionBuilderTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void TestSerialization()
        {
            // create builder and Serialize
            SectionBuilder builder = new SectionBuilder
            {
                Title = "test",
                SubSections = new List<SubSection>()
                {
                    new SubSection()
                    {
                        Title = "test.sub.0",
                    }
                },
                Content = new List<IContent>()
                {
                    new TextContent()
                    {
                        Text = "text.content"
                    },
                    new ImageContent()
                    {
                        Path = "test.image.jpg",
                        Type = ".jpg"
                    }
                }
            };
            var output = builder.Serialize();


            //create new SectionBuilder from serialized output
            var builder2 = SectionBuilder.Deserialize(output);
            var output2 = builder2.Serialize();
            Assert.Equal(output, output2);
            this.output.WriteLine(JToken.Parse(output).ToString(Formatting.Indented));
            this.output.WriteLine(JToken.Parse(output2).ToString(Formatting.Indented));
        }
    }
}
