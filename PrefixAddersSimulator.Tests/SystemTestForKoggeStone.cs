using NSubstitute;
using PrefixAddersSimulator.Library;
using PrefixAddersSimulator.Library.LogicOperation;
using PrefixAddersSimulator.Library.System.Builder;
using PrefixAddersSimulator.Tests._utils;
using Shouldly;
using Xunit;

namespace PrefixAddersSimulator.Tests
{
    public class SystemTestForKoggeStone
    {
        private readonly Library.System.System _system;
        private readonly IProvideSimulatorInputData _inputDataTranslator;
        private readonly IProvideOutput _outputProvider;

        private const string SystemMapFilePath = "kogge-stone.txt";//

        public SystemTestForKoggeStone()
        {
            _outputProvider = new SystemCalculator(new LogicalOperationCalculator());
            _inputDataTranslator = new InputDataTranslator();
            var mapFileContentProvider = Substitute.For<IProvideMapFileContent>();
            mapFileContentProvider.GetMapFileContent(SystemMapFilePath).Returns(EmbeddedData.AsString(SystemMapFilePath));

            var systemBuilder = new SystemBuilder(new MapFileParser(), mapFileContentProvider, new BuildSystemModulesMap());
            this._system = systemBuilder.Build(SystemMapFilePath);
        }

        [Fact]
        void system_builds_propertly()
        {
            _system.SystemMap.Count.ShouldBe(5);
            _system.SystemMap[0].Count.ShouldBe(16);
        }

        [Theory]
        [InlineData("0", "0", "0")]
        [InlineData("1111 1111 1111 1111", "1111 1111 1111 1111", "1111 1111 1111 1110")]
        [InlineData("0", "1", "1")]
        [InlineData("1", "1", "10")]
        [InlineData("100", "0", "100")]
        [InlineData("101", "1", "110")]
        [InlineData("1000", "1", "1001")]
        [InlineData("10101010", "11001100", "0101110110")]
        void correct_output_of_operation(string input1, string input2, string result)
        {
            _system.FirstNumber = _inputDataTranslator.GetBoolsArrayFromString(input1);
            _system.SecondNumber = _inputDataTranslator.GetBoolsArrayFromString(input2);
            var translatedResult = _inputDataTranslator.GetBoolsArrayFromString(result);

            _system.SetGenerationAndPropagationInModules();
            var output = _outputProvider.GetSystemOutput(_system.SystemMap);

            output.ShouldBe(translatedResult);
        }

        [Theory]
        [InlineData("0", "0", "10")]
        [InlineData("10111 1111 100111 1111", "1111 1100011 1111 1111", "1111 1111 1111 1110")]
        [InlineData("01", "1", "1")]
        [InlineData("1", "111", "10")]
        [InlineData("101", "0", "100")]
        [InlineData("111", "1", "110")]
        [InlineData("1000", "1", "101101")]
        [InlineData("10101010", "111001100", "0101110110")]
        void incorrect_output_of_operation(string input1, string input2, string result)
        {
            _system.FirstNumber = _inputDataTranslator.GetBoolsArrayFromString(input1);
            _system.SecondNumber = _inputDataTranslator.GetBoolsArrayFromString(input2);
            var translatedResult = _inputDataTranslator.GetBoolsArrayFromString(result);

            _system.SetGenerationAndPropagationInModules();
            var output = _outputProvider.GetSystemOutput(_system.SystemMap);

            output.ShouldNotBe(translatedResult);
        }
    }
}
