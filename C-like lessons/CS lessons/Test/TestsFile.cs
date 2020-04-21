using System;
using Lessons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestsFile
    {
        int Expected = 1;
        string[] Input = { "%", "140", "45" };
        [TestMethod]
        public void Test_For_Find()
        {
            Assert.AreEqual(Expected, Input[1].Find('4'));
        }
    }
}
