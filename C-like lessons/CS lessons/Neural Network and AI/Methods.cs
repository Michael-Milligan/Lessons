using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Neural_Network_and_AI
{
    public class Methods
    {
        public static void SerializeNetwork(ref NeuralNetwork NeuralNetwork)
        {
            BinaryFormatter Formatter;
            using (FileStream Stream = new FileStream("1.dat", FileMode.Create))
            {
                Formatter = new BinaryFormatter();
                Formatter.Serialize(Stream, NeuralNetwork);
            }
        }

        public static void DeserializeNetwork(out NeuralNetwork NeuralNetwork)
        {
            BinaryFormatter Formatter;
            using (FileStream Stream = new FileStream("1.dat", FileMode.Open))
            {
                Formatter = new BinaryFormatter();
                NeuralNetwork = Formatter.Deserialize(Stream) as NeuralNetwork;
            }
        }
    }
}
