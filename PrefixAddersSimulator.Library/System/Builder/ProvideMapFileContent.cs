using System;
using System.IO;

namespace PrefixAddersSimulator.Library.System.Builder
{
    public class ProvideMapFileContent : IProvideMapFileContent
    {
        public string GetMapFileContent(string filepath)
        {
            if (filepath == null) throw new ArgumentNullException("filepath");

            return File.ReadAllText(filepath);
        }
    }
}