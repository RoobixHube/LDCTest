using LocalDataCompanyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalDataCompanyTDD
{
    public class StringCleaner : StringCleanerInterface
    {
        private const int MaxStringLength = 15;

        public IEnumerable<string> CleanStringCollection(IEnumerable<string> stringCollection)
        {
            var newCollection = new List<string>();

            if (stringCollection == null || !stringCollection.Any()) { return newCollection; }

            foreach (var inString in stringCollection)
            {
                string cleanedString = CleanString(inString);

                if (!string.IsNullOrWhiteSpace(cleanedString))
                {
                    newCollection.Add(cleanedString);
                }
            }

            return newCollection;
        }

        private string CleanString(string inString)
        {
            if (string.IsNullOrWhiteSpace(inString)) return null;

            var newString = new StringBuilder();

            for (int charIndex = 0; charIndex < inString.Length; charIndex++)
            {
                var currentChar = inString[charIndex].ToString();

                if (TestForMaxLength(newString.Length))
                {
                    break;
                }

                if (charIndex != 0 && TestForContiguousDuplciates(inString[charIndex], inString[charIndex-1]))
                {
                    continue;
                }

                if (TestCharacterIsDollar(currentChar))
                {
                    newString.Append("£");
                    continue;
                }

                if (TestCharacterIsUnderscoreOrNumberFour(currentChar))
                {
                    continue;
                }

                newString.Append(currentChar);
            }

            return newString.ToString();
        }

        private bool TestCharacterIsUnderscoreOrNumberFour(string currentChar)
        {
            if (currentChar == "_" || currentChar == "4")
            {
                return true;
            }

            return false;
        }

        private bool TestCharacterIsDollar(string currentChar)
        {
            return currentChar == "$";
        }

        private bool TestForContiguousDuplciates(char currentChar, char previousChar)
        {
            return currentChar.ToString().Equals(previousChar.ToString(), StringComparison.InvariantCulture);
        }

        private bool TestForMaxLength(int stringLength)
        {
            return stringLength >= MaxStringLength;
        }
    }
}
