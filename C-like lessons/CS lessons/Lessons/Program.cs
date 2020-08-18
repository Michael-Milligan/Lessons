using Neural_Network_and_AI;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork NeuralNetwork;
            //= new NeuralNetwork(new Topology(0.001, 13, 1, 420));
            Methods.DeserializeNetwork(out NeuralNetwork, "1.dat");
            //Methods.SerializeNetwork(NeuralNetwork, "1.dat");

            var Data = Methods.ReadCSV("heart.csv");
            
            NeuralNetwork.TrainWhileStandardErrorMoreThan(Data.Item2, Data.Item1, 3000, 1);



            //Console.WriteLine(NeuralNetwork.PushSignalsThroughNetwork(new double[] { 1, 0, 0, 1}).Max());
        }
    }
}
