using System.Collections.Generic;
using PrefixAddersSimulator.Library.LogicOperation;

namespace PrefixAddersSimulator.Library.System.Builder
{
    public interface IProviderSystemModulesMap
    {
        System GetSystemModulesMap(string mapPath);
    }

    class SystemModulesMapProvider : IProviderSystemModulesMap
    {
        private readonly IParseMapFile _mapFileParser;

        public SystemModulesMapProvider(IParseMapFile mapFileParser)
        {
            _mapFileParser = mapFileParser;
        }

        public System GetSystemModulesMap(string mapPath)
        {
            var map = _mapFileParser.GetModulesTypeMap(mapPath);

            var systeModulesMap = new List<List<SystemModule>>();
            systeModulesMap.ForEach(x => x = new List<SystemModule>());

            for (var i = 0; i < map.Count; i++)
            {
                for (var j = 0; j < map[i].Count; j++)
                {
                    systeModulesMap[i][j] = new SystemModule(map[i][j]);
                }
            }

            return new System(systeModulesMap, new SystemCalculator(new LogicalOperationCalculator()));
        }
    }
}