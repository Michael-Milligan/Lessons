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
            var Network = new NeuralNetwork(new Topology(4, 1, 5, 5));

            //var Result = Network.PushSignalsThroughNetwork( 1, 0, 1, 1).First();
        }
    }
}
