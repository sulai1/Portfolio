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
            if (args.Length < 2)
            {
                Console.WriteLine("Missing Arguments! Required AssemblyPath, class to load and OutputPath");
                return;
            }
            Console.WriteLine($"Searching assembly for PreBuildTasks : {args[0]}");
        }
    }
}
