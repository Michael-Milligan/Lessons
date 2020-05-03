using System;
using Lessons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestsFile
    {
        string Expected = "KingThe";
        string Input = "TheKing";
        [TestMethod]
        public void Test_For_Find()
        {
            Assert.AreEqual(Expected, Methods.RotateString(ref Input, -4));
        }
    }
}
