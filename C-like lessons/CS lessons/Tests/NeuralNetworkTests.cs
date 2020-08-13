using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NeuralNetworkTests
    {
        [TestMethod]
        public void SigmoidTest()
        {
            var Expected = 0.5;
            var Input = 0;
            Assert.AreEqual(Expected, Neural_Network_and_AI.Neuron.SigmoidFunction(Input));
        }
    }
}
