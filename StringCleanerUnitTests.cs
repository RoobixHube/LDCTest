using LocalDataCompanyTDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LocalDataCompanyUnitTests
{
    [TestClass]
    public class StringCleanerUnitTests
    {
        private StringCleaner sut;
        private StringCleanerUnitTestHelper TestData;

        [TestInitialize]
        public void Intiialize()
        {
            sut = new StringCleaner();
            TestData = new StringCleanerUnitTestHelper();
        }

        [TestMethod]
        public void StringCleanerDoesNotSendBackNullList()
        {
            var actualResult = sut.CleanStringCollection(null);

            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void ResultCollectionMaxLengthIsFifteen()
        {
            var testData = TestData.Generate20CharacterCollection();
            var actualCollection = sut.CleanStringCollection(testData);
            var actual = actualCollection.First().Count();

            Assert.IsTrue(actual <= 15);
        }

        [TestMethod]
        public void ContiguousCharactersAreRemoved()
        {
            var testData = TestData.GenerateContiguousCharactersCollection();
            var expected = testData.First().Count(c => c == 'a');

            var actual = sut.CleanStringCollection(testData).First().Length;

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void DollarSymbolsAreRemoved()
        {
            var testData = TestData.GenerateDollarSymbolCharacterCollection();

            var actual = sut.CleanStringCollection(testData).First();

            Assert.IsFalse(actual.Contains("$"));
        }

        [TestMethod]
        public void DollarSymbolsAreReplacedByPoundSymbols()
        {
            var testData = TestData.GenerateMultipleDollarCollection();
            var expected = testData.First().Count(c => c == '$');

            var actual = sut.CleanStringCollection(testData).First().Count(c => c == '£');

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllUnderscoresAreRemoved()
        {
            var testData = TestData.GenerateUnderscoreCollection();
            var expected = testData.First().Count(c => c == '_');

            var actual = sut.CleanStringCollection(testData).First().Count(c => c == '_');

            Assert.IsTrue(expected > 0);
            Assert.IsTrue(actual == 0);
        }

        [TestMethod]
        public void AllNumberFoursAreRemoved()
        {
            var testData = TestData.GenerateNumberFourCollection();
            var expected = testData.First().Count(c => c == '4');

            var actual = sut.CleanStringCollection(testData).First().Count(c => c == '4');

            Assert.IsTrue(expected > 0);
            Assert.IsTrue(actual == 0);
        }

        [TestMethod]
        public void TestAllRules()
        {
            var testData = TestData.GenerateCollection();

            var actual = sut.CleanStringCollection(testData);

            var stringGreaterThan15Chars = actual.Any(s => s.Length > 15);
            var stringContainsDollarSymbols = actual.Any(s => s.Contains("$"));
            var stringContainsPoundSymbols = actual.Any(s => s.Contains("£"));
            var stringContainsUnderscores = actual.Any(s => s.Contains("_"));
            var stringContainsNumberFours = actual.Any(s => s.Contains("4"));

            Assert.IsNotNull(actual);
            Assert.IsFalse(stringGreaterThan15Chars);
            Assert.IsFalse(stringContainsDollarSymbols);
            Assert.AreNotEqual(stringContainsDollarSymbols, stringContainsPoundSymbols);
            Assert.IsFalse(stringContainsUnderscores);
            Assert.IsFalse(stringContainsNumberFours);
        }
    }
}
