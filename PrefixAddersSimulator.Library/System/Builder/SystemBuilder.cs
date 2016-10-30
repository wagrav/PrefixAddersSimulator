using System.Collections.Generic;
using PrefixAddersSimulator.Library.LogicOperation;

namespace PrefixAddersSimulator.Library.System.Builder
{
    public class SystemBuilder
    {
        private readonly IParseMapFile _mapFileParser;
        private readonly IProvideMapFileContent _mapFileContentProvider;
        private readonly IBuildSystemModulesMap _systemModulesMapBuilder;

        public SystemBuilder(IParseMapFile mapFileParser, IProvideMapFileContent mapFileContentProvider, IBuildSystemModulesMap systemModulesMapBuilder)
        {
            _mapFileParser = mapFileParser;
            _systemModulesMapBuilder = systemModulesMapBuilder;
            _mapFileContentProvider = mapFileContentProvider;
        }

        public SystemBuilder()
        {
            throw new global::System.NotImplementedException();
        }

        public System Build(string systemMapFilePath)
        {
            var systemModulesMap = SystemModulesMapBuilder(systemMapFilePath);

            return new System(systemModulesMap, new SystemCalculator(new LogicalOperationCalculator()));
        }

        public System Build(string systemMapFilePath, bool[] firstNumber, bool[] secondNumer)
        {
            var systemModulesMap = SystemModulesMapBuilder(systemMapFilePath);

            return
                new System(systemModulesMap, new SystemCalculator(new LogicalOperationCalculator()))
                {
                    FirstNumber = firstNumber,
                    SecondNumber = secondNumer
                };
        }



        private List<List<SystemModule>> SystemModulesMapBuilder(string systemMapFilePath)
        {
            var mapFileContent = _mapFileContentProvider.GetMapFileContent(systemMapFilePath);
            var intModulesTypeMap = _mapFileParser.GetModulesTypeMap(mapFileContent);
            var systemModulesMap = _systemModulesMapBuilder.GetSystemModulesMap(intModulesTypeMap);
            return systemModulesMap;
        }
    }
}
