using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NJsonSchema;
using NJsonSchema.CodeGeneration.TypeScript;
using NJsonSchema.Generation;

using Portfolio.Areas.Articles.Models;

namespace Portfolio.Areas.Articles.Data
{

    //TODO:Document Jsonschema4 usage
    public class SectionBuilder
    {

        enum ContentType { TEXT, CODE, EXAMPLE, IMAGE };
        public string Title { get; set; }
        public List<SubSection> SubSections { get; set; } = new List<SubSection>();
        public List<IContent> Content { get; set; } = new List<IContent>();

        public static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
            CheckAdditionalContent = true

        };

        #region JSON
        public static SectionBuilder Deserialize(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SectionBuilder>(json, settings);
        }

        public string Serialize()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, settings);
        }

        #region Create Schema
        public static async Task<JsonSchema4> CreateSchema()
        {

            JsonSchemaGeneratorSettings settings = new JsonSchemaGeneratorSettings()
            {
                GenerateAbstractProperties = true,
                AllowReferencesWithProperties = true
            };
            var gen = new SimpleSchemaGenerator(settings);

            return await gen.GenerateAsync(typeof(SectionBuilder));
        }

        public static async Task CreateSchema(TextWriter writer)
        {
            var schemaString = await CreateSchema();
            writer.Write(schemaString);
        }

        public static async Task CreateSchema(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                await CreateSchema(writer);
            }
        }
        #endregion Create Schema

        #region Create Typescript class
        public static string CreateTypescriptClass(JsonSchema4 schema)
        {
            var settings = new TypeScriptGeneratorSettings { TypeStyle = TypeScriptTypeStyle.Class, TypeScriptVersion = 2.8m };
            string ts = new TypeScriptGenerator(schema, settings).GenerateFile();
            //disable warnings because the generator generates code that is not compatible with the version of eslint
            string ignore = "/*eslint eqeqeq: [\"error\", \"smart\"]*/\n";
            return ignore + ts;
        }

        public static async Task CreateTypescriptClass(JsonSchema4 schema, TextWriter writer)
        {
            await writer.WriteAsync(CreateTypescriptClass(schema));
        }

        public static async Task CreateTypescriptClass(JsonSchema4 schema, string TsPath)
        {
            using (var writer = new StreamWriter(TsPath))
            {
                await CreateTypescriptClass(schema, writer);
            }
        }
        #endregion Create Typescript class

        #region Validate
        public static bool Validate(string json, JsonSchema4 schema)
        {
            var errors = schema.Validate(json);
            return errors.Count == 0;
        }

        #endregion Validate

        public class SimpleSchemaGenerator : JsonSchemaGenerator
        {
            public SimpleSchemaGenerator(JsonSchemaGeneratorSettings settings)
                : base(settings)
            {
            }

            public override Task GenerateAsync<TSchemaType>(Type type, IEnumerable<Attribute> parentAttributes, TSchemaType schema, JsonSchemaResolver schemaResolver)
            {
                var v = base.GenerateAsync(type, parentAttributes, schema, schemaResolver);
                schema.AllowAdditionalProperties = true;
                return v;
            }
        }

        #endregion JSON
    }

    public class SubSection
    {
        public string Title { get; set; }
    }


}

