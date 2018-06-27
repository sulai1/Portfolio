
using System;
using System.IO;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Portfolio.Areas.Articles.Data;

// good hint here how tasks work in msbuild https://stackoverflow.com/questions/676688/how-do-i-call-static-class-methods-from-msbuild
namespace Build
{
    public class PreBuildTask : Task
    {

        override public bool Execute()
        {
            var schema = SectionBuilder.CreateSchema().Result;
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