using System.Collections.Generic;

namespace PrefixAddersSimulator.Library.System.Builder
{
    public interface IBuildSystemModulesMap
    {
        List<List<SystemModule>> GetSystemModulesMap(List<List<int>> systemParams);
    }
}