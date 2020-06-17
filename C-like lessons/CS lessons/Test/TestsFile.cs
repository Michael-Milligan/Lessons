using System;
using Lessons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestsFile
    {
        bool Expected = true;
        int[] Input = {368, 276, 460};
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(Expected, Methods.IsRightTriangle(Input));
        }
    }
}
