using System;
using System.Collections.Generic;

namespace LocalDataCompanyUnitTests
{
    public class StringCleanerUnitTestHelper
    {
        public IEnumerable<string> GenerateCollection()
        {
            return new List<string>()
            {
                null,
                string.Empty,
                " ",
                "abcdefghijklmnopqrstuvqxyz1234567890",
                "AAA",
                "aabcdefghijkl123",
                "abcdefghijkl12$",
                "abcdefghijkl12_",
                "abcdefghijkl124",
                "$1$2$3$3",
                "a1b2c3d4e45",
                "AAAc91%cWwWkLq$1ci3_848v3d__K"
            };
        }

        public IEnumerable<string> Generate20CharacterCollection()
        {
            return new List<string>() { "abcdefghijklmnopqrstuvqxyz1234567890" };
        }
        
        public IEnumerable<string> GenerateContiguousCharactersCollection()
        {
            return new List<string>() { "aaa" };
        }

        public IEnumerable<string> GenerateDollarSymbolCharacterCollection()
        {
            return new List<string>() { "$12:52" };
        }

        public IEnumerable<string> GenerateMultipleDollarCollection()
        {
            return new List<string>() { "$1$2$3$3" };
        }

        internal IEnumerable<string> GenerateUnderscoreCollection()
        {
            return new List<string>() { "1_2_3_" };
        }

        internal IEnumerable<string> GenerateNumberFourCollection()
        {
            return new List<string>() { "a1b2c3d4e45" };
        }
    }
}
