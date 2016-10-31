using System.Linq;
using PrefixAddersSimulator.Library.LogicOperation;
using PrefixAddersSimulator.Library.System.Builder;

namespace PrefixAddersSimulator.Library
{
    public class PrefixAdderSimulator
    {

        private readonly System.System _system;
        private readonly IProvideSimulatorInputData _inputDataTranslator;
        private readonly IProvideOutput _outputProvider;

        public PrefixAdderSimulator(string systemMapFilePath)
        {
            _outputProvider = new SystemCalculator(new LogicalOperationCalculator());
            _inputDataTranslator = new InputDataTranslator();

            var systemBuilder = new SystemBuilder(
                new MapFileParser(),
                new ProvideMapFileContent(),
                new BuildSystemModulesMap()
                );

            _system = systemBuilder.Build(systemMapFilePath);
        }

        public string Calculate(string firstNumber, string secondNumber)
        {
            _system.FirstNumber = _inputDataTranslator.GetBoolsArrayFromString(firstNumber);
            _system.SecondNumber = _inputDataTranslator.GetBoolsArrayFromString(secondNumber);

            _system.SetGenerationAndPropagationInModules();
            var output = _outputProvider.GetSystemOutput(_system.SystemMap);

            return new string(output.Select(e => e ? '1' : '0').Reverse().ToArray());
        }
    }
}
