using Portfolio.Areas.Articles.Data;
using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
// good hint here how tasks work in msbuild https://stackoverflow.com/questions/676688/how-do-i-call-static-class-methods-from-msbuild
namespace Portfolio.Build
{
    public class GenerateJsonToTs : Task
    {
        public GenerateJsonToTs() { }
        public override bool Execute()
        {
            Console.WriteLine("Building Json schema from "+nameof(SectionBuilder));
            var schema = SectionBuilder.CreateSchema().Result;
            Console.WriteLine("Building Typescript file from generated Schema");
            var x = SectionBuilder.CreateTypescriptClass(schema);

            using (var writer = new StreamWriter("../Scripts/sectionbuilder.ts"))
            {
                writer.Write(schema);
            }
            using (var writer = new StreamWriter("../wwwroot/json/sectionbuilder.schema.json"))
            {
                writer.Write(schema);
            }
            return true;
        }
    }
}
