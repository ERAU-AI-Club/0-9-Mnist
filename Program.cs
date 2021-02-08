using System;

namespace _0_9MNIST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int layerLength = 16;
            Random rand = new Random();

            Neuron testNeuron = new Neuron();

            Neuron[] testLayer = new Neuron[layerLength];

            for(int i = 0; i < layerLength; i++)
            {
                Neuron temp = new Neuron();
                temp.Value = rand.NextDouble();
                testLayer[i] = temp;
            }

            testNeuron.initilizeNeuron(testLayer);

            testNeuron.commputeValue();

            Console.WriteLine(testNeuron.Value);

            Layers testNetwork = new Layers();

            int numOfInputNeurons = 16;
            int numOfHiddenLayers = 2;
            int numOfNeuronsInHiddenLayer = 16;
            int numOfOutputNeurons = 10;




            testNetwork.initializeNetwork(numOfInputNeurons, numOfHiddenLayers, numOfNeuronsInHiddenLayer, numOfOutputNeurons);
        }
    }
}
