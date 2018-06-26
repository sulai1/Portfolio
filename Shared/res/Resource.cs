using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Shared.res
{
    public class Resource : Dictionary<string, string>
    {

        private Resource()
        {

            var s = Path.GetFullPath(".");
            while(Path.GetDirectoryName(s).Contains("Portfolio"))
            {
                s = s.Substring(0,s.LastIndexOf(Path.DirectorySeparatorChar));
            }
            s+=Path.DirectorySeparatorChar+@"Shared\res\";
            
            

            Add("json", Path.GetFullPath($"{s}json"));
            Add("ts", Path.GetFullPath($"{s}ts"));

        }

        public static Resource instance = new Resource();

    }
}
