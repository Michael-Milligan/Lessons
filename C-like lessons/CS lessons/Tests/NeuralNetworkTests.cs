using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Neural_Network_and_AI;

namespace Tests
{
    [TestClass]
    public class NeuralNetworkTests
    {
        [TestMethod]
        public void FirstLaunchTest()
        {
            var Network = new NeuralNetwork(new Topology(14, 1, 16));
            Network.

            var Result = Methods.ReadCSV("heart.csv");
        }
    }
}
