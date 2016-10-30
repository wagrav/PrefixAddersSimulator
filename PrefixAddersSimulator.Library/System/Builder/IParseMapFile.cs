using System;
using System.Collections.Generic;

namespace PrefixAddersSimulator.Library.System.Builder
{
    public interface IParseMapFile
    {
        List<List<int>> GetModulesTypeMap(string fileInput);
    }

    public class MapFileParser : IParseMapFile
    {
        public List<List<int>> GetModulesTypeMap(string fileInput)
        {
            if (string.IsNullOrWhiteSpace(fileInput)) throw new ArgumentNullException("mapPath");

            var lines = fileInput.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            
            var integersMap = new List<List<int>>();

            foreach (var line in lines)
            {
                var valueOnPosition = line.Split(' ');
                var row = new List<int>();
                foreach (var value in valueOnPosition)
                {
                    row.Insert(0,Convert.ToInt32(value));
                }
                integersMap.Add(row);
            }

            return integersMap;
        }
    }
}