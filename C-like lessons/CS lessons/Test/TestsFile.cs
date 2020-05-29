using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestsFile
    {
        int Expected = 720;
        int Input = 6;
        [TestMethod]
        public void Test_For_Function()
        {
            Assert.AreEqual(Expected, Factorial(Input));
        }

        public static int Factorial(int Number)
        {
            int Result = 1;
            for (int i = 1; i <= Number; ++i)
            {
                Result *= i;
            }
            return Result;
        }
    }
}
