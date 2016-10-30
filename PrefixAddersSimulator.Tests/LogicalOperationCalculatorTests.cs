using PrefixAddersSimulator.Library;
using PrefixAddersSimulator.Library.LogicOperation;
using Shouldly;
using Xunit;

namespace PrefixAddersSimulator.Tests
{
    public class LogicalAndOperationTests
    {
        private readonly ICalculateLogicalOperation _logicalOperationCalculator;

        public LogicalAndOperationTests()
        {
            _logicalOperationCalculator = new LogicalOperationCalculator();
        }

        [Fact]
        public void and_operation_with_two_true_parameters()
        {
            bool a = true;
            bool b = true;

            var result = _logicalOperationCalculator.And(a, b);

            result.ShouldBe(true);
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void and_operation_with_at_least_one_false_parameters(bool a, bool b)
        {
            var result = _logicalOperationCalculator.And(a, b);

            result.ShouldBe(false);
        }

        [Fact]
        public void Or_operation_with_two_false_parameters()
        {
            bool a = false;
            bool b = false;

            var result = _logicalOperationCalculator.Or(a, b);

            result.ShouldBe(false);
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void Or_operation_with_at_least_one_true_parameter(bool a, bool b)
        {
            var result = _logicalOperationCalculator.Or(a, b);

            result.ShouldBe(true);
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void Xor_operation_with_one_false_one_true_parameter(bool a, bool b)
        {
            var result = _logicalOperationCalculator.Xor(a, b);

            result.ShouldBe(true);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void Xor_operation_with_two_the_same_parameters(bool a, bool b)
        {
            var result = _logicalOperationCalculator.Xor(a, b);

            result.ShouldBe(false);
        }
    }
}
