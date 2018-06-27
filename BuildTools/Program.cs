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


            var path = Path.GetDirectoryName(args[0]);
            //var path = Path.GetDirectoryName(args[0]);
            //foreach (string dll in Directory.GetFiles(path, "*.dll"))
            //    Assembly.LoadFile(dll);
            var assambly = Assembly.LoadFile(args[0]);
            foreach (var a in assambly.GetReferencedAssemblies())
                try
                {
                    Assembly.Load(a);
                    Console.WriteLine("Loaded"+a.Name);
                }catch(Exception e)
                {
                    Console.WriteLine("Failed" + a.Name);
                }
            var types = assambly.GetExportedTypes();

            var o = new Object();
            var t = o.GetType();

            if (o is IPreBuildTask)
            {
                Console.WriteLine($"Loading Type:{t.AssemblyQualifiedName}");

                // get the constructor and the method that implements the interface
                var constructor = t.GetConstructor(new Type[0]);
                var interfaceImpl = t.GetMethod("Build");

                // check if they realy exist and nothing is broken
                if (constructor != null && interfaceImpl != null)
                {
                    Console.WriteLine(constructor);
                    object task = interfaceImpl.Invoke(o, new object[] { args[0], args[1] });
                    if (task is Task)
                    {
                        var taskd = task as Task;
                        taskd.RunSynchronously();

                    }
                }
                else
                {
                    throw new ReflectionTypeLoadException(new Type[] { t, typeof(IPreBuildTask) }, new Exception[] { }, $"Cannot load {t}. The loaded interface does not follow the Contract of its interface {nameof(IPreBuildTask)}!");
                }
            }

        }
    }
}
