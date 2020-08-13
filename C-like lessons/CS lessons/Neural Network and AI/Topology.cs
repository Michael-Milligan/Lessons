using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_and_AI
{
    public class Topology
    {
        public int _InputCount { get;  }
        public int _OutputCount { get;  }
        public int[] _HiddenLayers { get;  }

        /// <summary>
        /// Specify the number of neurons in the arguments
        /// </summary>
        /// <param name="InputCount"></param>
        /// <param name="OutputCount"></param>
        /// <param name="HiddenLayers"></param>
        public Topology(int InputCount, int OutputCount, params int[] HiddenLayers)
        {
            _InputCount = InputCount;
            _OutputCount = OutputCount;
            _HiddenLayers = HiddenLayers ?? throw new ArgumentNullException(nameof(HiddenLayers));
        }
    }
}
