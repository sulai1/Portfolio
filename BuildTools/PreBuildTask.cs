
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

        readonly string path = "../../../../Portfolio";
        override public bool Execute()
        {
            var schema = SectionBuilder.CreateSchema().Result;
            var tsClass = SectionBuilder.CreateTypescriptClass(schema);

            using (var writer = new StreamWriter(path + "/Scripts/sectionbuilder.ts"))
            {
                writer.Write(tsClass);
            }
            using (var writer = new StreamWriter(path + "/wwwroot/json/sectionbuilder.schema.json"))
            {
                writer.Write(schema.ToJson());
            }
            return true;
        }
    }

}