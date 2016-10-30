using System;
using System.Collections.Generic;
using System.Linq;
using PrefixAddersSimulator.Library.System;

namespace PrefixAddersSimulator.Library.LogicOperation
{
    public class SystemCalculator : ICalculateGeneration, ICalculatePropagation, ICalculateModule, IProvideOutput
    {
        private readonly ICalculateLogicalOperation _logicalOperationCalculator;

        public SystemCalculator(ICalculateLogicalOperation logicalOperationCalculator)
        {
            _logicalOperationCalculator = logicalOperationCalculator;
        }

        public void SetGenerationInModule(System.System system, int x, int y)
        {
            if (system == null) throw new ArgumentNullException("system");

            switch (system.SystemMap[x][y].SystemModuleType)
            {
                case SystemModuleType.CalculatingChip:
                    system.SystemMap[x][y].Generation = GetGenerationForCalculatingChip(system, x, y);
                    break;
                case SystemModuleType.NeutralChip:
                    system.SystemMap[x][y].Generation = GetGenerationForNeutralChipChip(system, x, y);
                    break;
                case SystemModuleType.EntryChip:
                    system.SystemMap[x][y].Generation = GetGenerationForEntryChip(system, y);
                    break;
                case SystemModuleType.EndPointChip:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool GetGenerationForEntryChip(System.System system, int x)
        {
            return _logicalOperationCalculator.And(system.FirstNumber[x],
                system.SecondNumber[x]);
        }

        private bool GetGenerationForNeutralChipChip(System.System system, int x, int y)
        {
            return system.SystemMap[x - 1][y].Generation;
        }

        private bool GetGenerationForCalculatingChip(System.System system, int x, int y)
        {
            return _logicalOperationCalculator.Or(_logicalOperationCalculator.And(system.SystemMap[x - 1][y].Propagation, system.SystemMap[x - 1][y - system.SystemMap[x][y].DistansToBranch].Generation), system.SystemMap[x - 1][y].Generation);
        }

        public void SetPropagationInModule(System.System system, int x, int y)
        {
            if (system == null) throw new ArgumentNullException("system");

            switch (system.SystemMap[x][y].SystemModuleType)
            {
                case SystemModuleType.CalculatingChip:
                    system.SystemMap[x][y].Propagation = GetPropagationForCalculatingChip(system, x, y);
                    break;
                case SystemModuleType.NeutralChip:
                    system.SystemMap[x][y].Propagation = GetPropagationForNeutralChipChip(system, x, y);
                    break;
                case SystemModuleType.EntryChip:
                    system.SystemMap[x][y].Propagation = GetPropagationForEntryChip(system, y);
                    break;
                case SystemModuleType.EndPointChip:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool GetPropagationForEntryChip(System.System system, int x)
        {
            return _logicalOperationCalculator.Xor(system.FirstNumber[x],
                system.SecondNumber[x]);
        }

        private bool GetPropagationForNeutralChipChip(System.System system, int x, int y)
        {
            return system.SystemMap[x - 1][y].Propagation;
        }

        private bool GetPropagationForCalculatingChip(System.System system, int x, int y)
        {
            return _logicalOperationCalculator.And(system.SystemMap[x - 1][y].Propagation,
                system.SystemMap[x-1][y - system.SystemMap[x][y].DistansToBranch].Propagation);
        }

        public void CalculateModule(System.System system, int x, int y)
        {
            SetGenerationInModule(system, x, y);
            SetPropagationInModule(system, x, y);
        }

        public bool[] GetSystemOutput(List<List<SystemModule>> modulesMap)
        {
            var output = new List<bool>();
            var lastRowIndex = modulesMap.Count - 1;
            for (int i = 0; i < modulesMap[lastRowIndex].Count; i++)
            {
                output.Add(i == 0
                    ? CalculateSi(modulesMap[0][i].Propagation, false)
                    : CalculateSi(modulesMap[0][i].Propagation, modulesMap[lastRowIndex][i - 1].Generation));
            }
            return output.ToArray();
        }

        private bool CalculateSi(bool propagation, bool previousCi)
        {
            return _logicalOperationCalculator.Xor(propagation, previousCi);
        }
    }

    public interface IProvideOutput
    {
        bool[] GetSystemOutput(List<List<SystemModule>> system);
    }
}