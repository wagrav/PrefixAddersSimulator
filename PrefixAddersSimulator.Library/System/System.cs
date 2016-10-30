using System.Collections.Generic;
using PrefixAddersSimulator.Library.LogicOperation;

namespace PrefixAddersSimulator.Library.System
{
    public class System 
    {
        private readonly ICalculateModule _modulCalculator;
        public List<List<SystemModule>> SystemMap { get; private set; }
        public bool[] FirstNumber { get; set; }
        public bool[] SecondNumber { get; set; }

        public void SetGenerationAndPropagationInModules()
        {
            for (var i = 0; i < SystemMap.Count; i++)
            {
                for (var j = 0; j < SystemMap[i].Count; j++)
                {
                    _modulCalculator.CalculateModule(this,i,j);
                }
            }
        }

        public System(List<List<SystemModule>> systemMap, ICalculateModule modulCalculator)
        {
            SystemMap = systemMap;
            _modulCalculator = modulCalculator;
        }
    }
}
