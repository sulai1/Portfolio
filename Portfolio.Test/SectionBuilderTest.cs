using Xunit;
using Portfolio.Areas.Articles.Data;
using Xunit.Abstractions;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Portfolio.Areas.Articles.Models;
using System.IO;
using NJsonSchema;
using NJsonSchema.Generation;

namespace Portfolio.Test
{
    public class SectionBuilderTest
    {
        private const string SchemaPath = @"..\..\..\res\schema.json";
        private const string JsonPath = @"..\..\..\res\object.json";
        private const string TsPath = @"..\..\..\res\object.ts";
        private readonly ITestOutputHelper output;
        private readonly SectionBuilder builder;

        public SectionBuilderTest(ITestOutputHelper output)
        {
            this.output = output;
            // create builder and Serialize
            this.builder = new SectionBuilder
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
                        Path = "test.image.jpg"
                    }
                }
            };
        }
        [Fact]
        public void SerializationTest()
        {
            var output = builder.Serialize();


            //create new SectionBuilder from serialized output
            var builder2 = SectionBuilder.Deserialize(output);
            var output2 = builder2.Serialize();
            Assert.Equal(output, output2);
            this.output.WriteLine(JToken.Parse(output).ToString(Newtonsoft.Json.Formatting.Indented));
            this.output.WriteLine(JToken.Parse(output2).ToString(Newtonsoft.Json.Formatting.Indented));
        }

        [Fact]
        public async void SchemaCreationTest()
        {
            // initialize schema and json
            var schema = await SectionBuilder.CreateSchema();
            var schemaString = schema.ToJson();
            string json = builder.Serialize();

            // write files to disk for later examination
            using (var writer = new StreamWriter(SchemaPath))
            {
                writer.Write(schemaString);
            }
            using (var writer = new StreamWriter(JsonPath))
            {
                writer.Write(json);
            }

            await SectionBuilder.CreateTypescriptClass(TsPath, await SectionBuilder.CreateSchema());
            Assert.True(SectionBuilder.Validate(json,schema));
        }

    }
}
