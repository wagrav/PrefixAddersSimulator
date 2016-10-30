using System;
using System.Linq;
using NSubstitute.ExceptionExtensions;
using PrefixAddersSimulator.Library;
using Shouldly;
using Xunit;
using Xunit.Sdk;

namespace PrefixAddersSimulator.Tests
{
    public class InputDataTranslatorTests
    {
        private readonly IProvideSimulatorInputData _inputDataTranslator;

        public InputDataTranslatorTests()
        {
            _inputDataTranslator = new InputDataTranslator();
        }

        [Fact]
        public void throws_exception_when_input_string_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => 
                _inputDataTranslator.GetBoolsArrayFromString(null)
                );
        }

        [Fact]
        public void throws_exception_when_input_string_contains_other_char_than_1_or_0()
        {
            var input = "124";

            Assert.Throws<ArgumentException>(() =>
                _inputDataTranslator.GetBoolsArrayFromString(input)
                );
        }

        [Fact]
        public void gives_bool_Array_with_length_equal_to_16()
        {
            var inputString = "";

            var result = _inputDataTranslator.GetBoolsArrayFromString(inputString);

            result.Length.ShouldBe(16);
        }

        [Theory]
        [InlineData("11 11","1111")]
        [InlineData("11 11 11 1 1 1", "111111111")]
        public void ignore_spaces_in_input_string(string input1, string input2)
        {
            var result1 = _inputDataTranslator.GetBoolsArrayFromString(input1);
            var result2 = _inputDataTranslator.GetBoolsArrayFromString(input2);

            result1.ShouldBe(result2);
        }

        [Fact]
        public void fills_same_true_values_when_given_sixteen_1()
        {
            var input = "1111 1111 1111 1111";

            var result = _inputDataTranslator.GetBoolsArrayFromString(input);

            bool allAreTrue = !result.Any(bit => bit == false);

            allAreTrue.ShouldBe(true);
        }

        [Fact]
        public void does_not_fills_same_true_values_when_given_less_than_sixteen_1()
        {
            var input = "1111 1001 1111 1111";

            var result = _inputDataTranslator.GetBoolsArrayFromString(input);

            var allAreTrue = !result.Any(bit => bit == false);

            allAreTrue.ShouldBe(false);
        }

        
    }
}
