using System;
using System.Linq;

namespace PrefixAddersSimulator.Library
{
    public class InputDataTranslator : IProvideSimulatorInputData
    {
        private readonly int _acceptableBitCount = 16;

        public bool[] GetBoolsArrayFromString(string input)
        {
            var validatedInput = PrepareAndValidateInputString(input);

            return validatedInput.Select(x => x == '1').Reverse().ToArray();
        }

        private string PrepareAndValidateInputString(string input)
        {
            if (input == null) throw new ArgumentNullException("input", "Null cannot be translated!");

            input = input.Replace(" ", "");

            if (input.Any(x => x != '1' && x != '0')) throw new ArgumentException("To translate string to byte[], input has to contain  only '1' or '0' char");

            if (input.Length > _acceptableBitCount)
                input = input.Substring(0, _acceptableBitCount - 1);

            while (input.Length < _acceptableBitCount)
            {
                input = input.Insert(0, "0");
            }

            return input;
        }
    }
}