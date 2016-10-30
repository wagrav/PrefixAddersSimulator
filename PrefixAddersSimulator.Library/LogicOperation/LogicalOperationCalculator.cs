namespace PrefixAddersSimulator.Library.LogicOperation
{
    public class LogicalOperationCalculator : ICalculateLogicalOperation
    {
        public bool Xor(bool a, bool b)
        {
            return a ^ b;
        }

        public bool And(bool a, bool b)
        {
            return a && b;
        }

        public bool Or(bool a, bool b)
        {
            return a || b;
        }
    }
}