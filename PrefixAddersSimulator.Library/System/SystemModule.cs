namespace PrefixAddersSimulator.Library.System
{
    public class SystemModule
    {
        public bool Propagation { get; set; }
        public bool Generation { get; set; }

        public SystemModuleType SystemModuleType { get; private set; }
        public int DistansToBranch { get; private set; }

        public SystemModule(int distansToBranch)
        {
            DistansToBranch = distansToBranch;
            SystemModuleType = DetectChipType(DistansToBranch);
        }

        public SystemModule(bool propagation, bool generation, SystemModuleType systemModuleType, int distansToBranch)
        {
            Propagation = propagation;
            Generation = generation;
            SystemModuleType = systemModuleType;
            DistansToBranch = distansToBranch;
        }

        private SystemModuleType DetectChipType(int distansToBranch)
        {
            switch (distansToBranch)
            {
                case 99:
                    return SystemModuleType.EntryChip;
                    break;
                case 0:
                    return SystemModuleType.NeutralChip;
                    break;
                default:
                    return SystemModuleType.CalculatingChip;
                    break;
            }
        }
    }

    public enum SystemModuleType
    {
        EntryChip, NeutralChip, CalculatingChip, EndPointChip
    }
}
