using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace _0_9MNIST
{
    class Layers
    {
        private Neuron[] inputNeurons, outputNeurons;
        private Neuron[,] hiddenNeurons;
        

        public Layers()
        {

        }

        /*
         * 
        public void initializeNeuronAmount()
        {
            // gets and stores input neuron amount
            Console.WriteLine("\nInput input neuron amount: ");
            inputNeuronAmount = IntegerType.FromString(Console.In.ReadLine());

            // gets and stores hidden layer amount
            Console.WriteLine("\nHidden layer amount: ");
            hiddenLayerAmount = IntegerType.FromString(Console.In.ReadLine());

            // gets and stores hidden neuron amount
            Console.WriteLine("\nNeurons per hidden layer: ");
            hiddenNeuronAmount = IntegerType.FromString(Console.In.ReadLine());

            // gets and stores output neuron amount
            Console.WriteLine("\nNeurons amount for output layer");
            outputNeuronAmount = IntegerType.FromString(Console.In.ReadLine());
        }
        */
        public void initializeNetwork(int numOfInput, int numOfHiddenLayers, int numOfNeuronsInLayer, int numOfOutput)
        {
            //                           the column is the layer and the row is the specific neuron
            //                                      Rows                    columns
            //                                      y Coordinate        x Coordinate
            Neuron[,] hiddenLayers = new Neuron[numOfNeuronsInLayer, numOfHiddenLayers];
            Neuron[] inputNeuronstemp = new Neuron[numOfInput];
            Neuron[] outputNeuronstemp = new Neuron[numOfOutput];

            hiddenNeurons = hiddenLayers;

            // initializes input neurons
            for (int i = 0; i < numOfInput; i++)
            {
                inputNeuronstemp[i] = new Neuron();
            }
            inputNeurons = inputNeuronstemp;

           for(int x = 0; x < numOfHiddenLayers; x++)
            {
                for (int y = 0; y < numOfNeuronsInLayer; y++)
                {
                    if(x == 0)
                    {
                        Neuron temp1 = new Neuron();
                        temp1.initilizeNeuron(inputNeurons);
                        hiddenLayers[y, x] = temp1;
                    }

                    Neuron temp = new Neuron();
                    temp.initilizeNeuron(getHiddenLayer(hiddenLayers, x));
                    hiddenLayers[y, x] = temp;
                }
                
            }
            
            // initializes output neurons
            for (int k = 0; k < numOfHiddenLayers; k++)
            {
                Neuron temp = new Neuron();
                temp.initilizeNeuron(getHiddenLayer(hiddenLayers, numOfHiddenLayers - 1));
                outputNeuronstemp[k] = temp;
            }
            outputNeurons = outputNeuronstemp;

        }

        public Neuron[] getInputNeurons() { return inputNeurons; }

        public Neuron[,] getHiddenNeurons() { return hiddenNeurons; }

        public Neuron[] getOutputNeurons() { return outputNeurons; }

        public Neuron[] getNeuronList()
        {
            int totalLength = inputNeurons.GetLength(0) + outputNeurons.GetLength(0) + hiddenNeurons.GetLength(0) * hiddenNeurons.GetLength(1);

            Neuron[] neuronList = new Neuron[totalLength];
            int i = 0;
           
            for (int j = 0; j < inputNeurons.GetLength(0); j++)
            {
                neuronList[i] = inputNeurons[j];
                i++;
            }
            for(int j = 0; j < hiddenNeurons.GetLength(1); j++)
            {
                for(int k = 0; k < hiddenNeurons.GetLength(0); k++)
                {
                    neuronList[i] = hiddenNeurons[k, j];
                    i++;
                }
            }
            for(int j = 0; j < outputNeurons.GetLength(0); j++)
            {
                neuronList[i] = outputNeurons[j];
            }

            

            return neuronList;
        }


        //                   the column is the layer and the row is the specific neuron
        //                              Rows             columns
        //                             y Coordinate   x Coordinate
        //          Start counting from 0!!!!!
        public Neuron[] getHiddenLayer(Neuron[,] input, int layerNumber)
        {
            // create an array with the same lenght as the layer
            Neuron[] output = new Neuron[input.GetLength(0)];

            for(int i = 0; i < output.GetLength(0);i++)
            {
                output[i] = input[i, layerNumber];
            }

            return output;
        }



    }
}
