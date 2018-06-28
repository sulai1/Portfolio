using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BuildTools
{
    class MainClass
    {
        static void Main(string[] args)
        {
            new Build.PreBuildTask().Execute();
        }
    }
}
