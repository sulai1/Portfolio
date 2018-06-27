using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildTools
{
    public interface IPreBuildTask
    {
        Task Build(string assemblyPath, string outputPath);
    }
}
