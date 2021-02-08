using System;

namespace _0_9MNIST
{
    class Neuron
    {
        private double[] weights;
        private double[] bias;
        private Neuron[] previousLayerNeurons;
        private double value;


        public Neuron(){}

        public double Value { get => value; set => this.value = value; }
        public double[] Weights { get => weights; set => weights = value; }
        public double[] Bias { get => bias; set => bias = value; }
        internal Neuron[] ChildNeurons { get => previousLayerNeurons; set => previousLayerNeurons = value; }

        public void initilizeNeuron(Neuron[] prevLayers)
        {
            previousLayerNeurons = prevLayers;
            Random rand = new Random();
            double[] tempWeights = new double[previousLayerNeurons.Length];
            double[] tempBias = new double[previousLayerNeurons.Length];

            for(int i = 0; i < previousLayerNeurons.Length; i++)
            {
                //see if their is some baisc optimization we can do with the initial biases
                tempBias[i] = (20.0 * rand.NextDouble() - 10);
                tempWeights[i] = (20.0 * rand.NextDouble() - 10);
            }
            weights = tempWeights;
            bias = tempBias;

        }

        public double commputeValue()
        {
            double sum = 0.0;

            for(int i = 0; i < previousLayerNeurons.Length; i++)
            {
                sum += weights[i] * previousLayerNeurons[i].value + bias[i];
            }

            value = LogSigmoid(sum);
            return value;
        }
        public double LogSigmoid(double x)
        {
            if (x < -45.0) return 0.0;
            else if (x > 45.0) return 1.0;
            else return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}
