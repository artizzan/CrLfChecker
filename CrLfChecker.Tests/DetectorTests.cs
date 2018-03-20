using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CrLfChecker.Tests
{
    public class DetectorTests
    {
        DetectionLogic system;

        [SetUp]
        public void SetUp()
        {
            system = new DetectionLogic();
        }

        [TestCase("abc\r\nabc\r\nabc", 2, 0)]
        [TestCase("abc\r\nabc\n", 1, 1)]
        public void CheckCounts(string text, int expectedCrlfCount, int expectedLfCount)
        {
            var crlfCount = system.CountCrLf(text);
            var lfCount = system.CountLf(text);

            Assert.AreEqual(expectedCrlfCount, crlfCount);
            Assert.AreEqual(expectedLfCount, lfCount);
        }
    }
}
