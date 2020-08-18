using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neural_Network_and_AI;

namespace Tests
{
    [TestClass]
    public class NeuralNetworkTests
    {
        [TestMethod]
        public void FirstLaunchTest()
        {
            var Network = new NeuralNetwork(new Topology(0.0001, 13, 1, 16));
            var Data = Methods.ReadCSV("heart.csv");
            Network.TrainWhileStandardErrorMoreThan(Data.Item2, Data.Item1, 200, 0.0001);
        }
    }
}
