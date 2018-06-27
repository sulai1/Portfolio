using Portfolio.Areas.Articles.Data;
using System;
using System.IO;

using Microsoft.Build.Framework;
// good hint here how tasks work in msbuild https://stackoverflow.com/questions/676688/how-do-i-call-static-class-methods-from-msbuild
namespace Simple
{
    public class SimpleTask : ITask
    {
        public IBuildEngine BuildEngine { get; set; }
        public ITaskHost HostObject { get; set; }

        public bool Execute()
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