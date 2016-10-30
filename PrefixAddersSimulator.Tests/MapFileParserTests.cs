using System.Collections.Generic;
using PrefixAddersSimulator.Library;
using PrefixAddersSimulator.Library.System.Builder;
using PrefixAddersSimulator.Tests._utils;
using Shouldly;
using Xunit;

namespace PrefixAddersSimulator.Tests
{
    public class MapFileParserTests
    {
        private readonly IParseMapFile _mapFileParser;

        public MapFileParserTests()
        {
            _mapFileParser = new MapFileParser();
        }

        [Fact]
        public void create_expected_matrix()
        {
            var inputString = EmbeddedData.AsString("han_carlson.txt");

            var intMap = _mapFileParser.GetModulesTypeMap(inputString);

            IsMappedStructureCorrected(intMap).ShouldBe(true);
        }

        private static bool IsMappedStructureCorrected(IReadOnlyList<List<int>> intMap)
        {
            bool anyError = false;

            foreach (var i in intMap[0])
            {
                if (i != 99) anyError = true;
            }

            for (int i = 0; i < intMap[1].Count; i++)
            {
                if (i%2 == 0)
                {
                    if (intMap[1][i] != 0)
                        anyError = true;
                }
                else
                {
                    if (intMap[1][i] != 1) anyError = true;
                }
            }

            for (int i = 0; i < intMap[2].Count; i++)
            {
                if (i < 3)
                {
                    if (intMap[2][i] != 0)
                        anyError = true;
                }
                else
                {
                    if (i%2 == 0)
                    {
                        if (intMap[2][i] != 0)
                            anyError = true;
                    }
                    else
                    {
                        if (intMap[2][i] != 2) anyError = true;
                    }
                }
            }

            for (int i = 0; i < intMap[3].Count; i++)
            {
                if (i < 5)
                {
                    if (intMap[3][i] != 0)
                        anyError = true;
                }
                else
                {
                    if (i%2 == 0)
                    {
                        if (intMap[3][i] != 0)
                            anyError = true;
                    }
                    else
                    {
                        if (intMap[3][i] != 4) anyError = true;
                    }
                }
            }

            for (int i = 0; i < intMap[4].Count; i++)
            {
                if (i < 9)
                {
                    if (intMap[4][i] != 0)
                        anyError = true;
                }
                else
                {
                    if (i%2 == 0)
                    {
                        if (intMap[4][i] != 0)
                            anyError = true;
                    }
                    else
                    {
                        if (intMap[4][i] != 8) anyError = true;
                    }
                }
            }

            for (int i = 0; i < intMap[5].Count; i++)
            {
                if (i < 2)
                {
                    if (intMap[5][i] != 0)
                        anyError = true;
                }
                else
                {
                    if (i%2 == 0)
                    {
                        if (intMap[5][i] != 1)
                            anyError = true;
                    }
                    else
                    {
                        if (intMap[5][i] != 0) anyError = true;
                    }
                }
            }

            return !anyError;
        }
    }
}
