using System.Collections.Generic;
using System.Linq;

namespace PrefixAddersSimulator.Library.System.Builder
{
    public class BuildSystemModulesMap : IBuildSystemModulesMap
    {
        public List<List<SystemModule>> GetSystemModulesMap(List<List<int>> systemParams)
        {
            var map = systemParams.Select(row => new List<SystemModule>()).ToList();

            for (var i = 0; i < systemParams.Count; i++)
            {
                for (var j = 0; j < systemParams[i].Count; j++)
                {
                    map[i].Add(new SystemModule(systemParams[i][j]));
                }
            }

            return map;
        }
    }
}