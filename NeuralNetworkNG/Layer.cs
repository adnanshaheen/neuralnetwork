using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkLibAM
{
    /// <summary>
    /// A layer of neurone in a neuronal network
    /// </summary>
    /// <remarks>
    /// <code>
    ///             / N1 ----->        OUTPUTS
    /// INPUTS ===> - N2 ----->  (1 output for each 
    ///             \ Ni ----->  neuron of the layer)
    /// </code>       
    /// Each neuron of the layer has the same number of
    /// inputs, this is the number of inputs of the layer
    /// itself.
    /// </remarks>
    /// 
    [Serializable]
    public class Layer
    {
        protected int numNeurons;  // number of neurons in a layer
        public int NumNeurons
        {
            get { return numNeurons; }
        }

        protected int numLayerInputs; // number of inputs to the layer
        public int NumLayerInputs
        {
            get { return numLayerInputs; }
        }

        protected Neuron[] neurons;  // neurons in the layer
        public Neuron[] Neurons
        {
            get
            {
                return neurons;
            }

            set
            {
                neurons = value;
            }
        }

        protected double[] outputs;  // outputs of the layer
        public double[] LastOutputs
        {
            get { return outputs; }
        }



        /// <summary>
        /// Indexer of layer's neurons
        /// </summary>
        public Neuron this[int neuronNum]
        {
            get { return Neurons[neuronNum]; }
        }
        

        #region LAYER CONSTRUCTORS

        /// <summary>
        /// Build a new Layer with neurons neurones. Every neuron 
        /// has "inputs" inputs and the activation function f.
        /// </summary>
        /// <param name="inputs">Number of inputs</param>
        /// <param name="neurons">Number of neurons</param>
        /// <param name="f">Activation function of each neuron</param>
        public Layer(int neurons, int inputs, IActivationFunction f)
        {
            numNeurons = neurons;
            numLayerInputs = inputs;
            this.Neurons = new Neuron[numNeurons];
            outputs = new double[numNeurons];
            for (int i = 0; i < neurons; i++)
                this.Neurons[i] = new Neuron(inputs, f);
        }

        /// <summary>
        /// Build a new Layer with neurons neurones. Every neuron 
        /// has "inputs" inputs and the sigmoid activation function.
        /// </summary>
        /// <param name="inputs">Number of inputs</param>
        /// <param name="neurons">Number of neurons</param>
        public Layer(int neurons, int inputs)
        {
            numNeurons = neurons;
            numLayerInputs = inputs;
            this.Neurons = new Neuron[numNeurons];
            outputs = new double[numNeurons];
            for (int i = 0; i < neurons; i++)
                this.Neurons[i] = new Neuron(inputs);
        }

        /// <summary>
        /// Set the activation function f to all neurons of the layer
        /// </summary>
        /// <param name="f">An activation function</param>
        public void setActivationFunction(IActivationFunction f)
        {
            foreach (Neuron n in Neurons)
                n.F = f;
        }

        #endregion

        #region INITIALIZATION FUNCTIONS

        /// <summary>
        /// Randomize all neurons weights
        /// </summary>
        public void randomizeWeight()
        {
            foreach (Neuron n in Neurons)
                n.randomizeWeight();
        }
        /// <summary>
        /// Randomize all neurons thresholds
        /// </summary>
        public void randomizeBias()
        {
            foreach (Neuron n in Neurons)
                n.randomizeBias();
        }
        /// <summary>
        /// Randomize all neurons threshold and weights
        /// </summary>
        public void randomizeAll()
        {
            randomizeWeight();
            randomizeBias();
        }
        /// <summary>
        /// Set the randomization interval for all neurons
        /// </summary>
        /// <param name="min">the minimum value</param>
        /// <param name="max">the maximum value</param>
        public void setRandomizationInterval(double min, double max)
        {
            foreach (Neuron n in Neurons)
            {
                n.RandomMin = min;
                n.RandomMax = max;
            }
        }

        #endregion

        #region OUTPUT VALUE ACCES

        /// <summary>
        /// Compute output of the layer.
        /// The output vector contains the output of each 
        /// neuron of the layer.
        /// </summary>
        /// <param name="input">input of the layer (size must be N_inputs)</param>
        /// <returns>the output vector (size = N_neurons)</returns>
        public double[] Output(double[] input)
        {
            if (input.Length != numLayerInputs)
                throw new Exception("LAYER : Wrong input vector size, unable to compute output value");
            //for (int i = 0; i < numNeurons; i++)
            Parallel.For(0, numNeurons, i =>
            {
                outputs[i] = Neurons[i].ComputeOutput(input);
            });
            return outputs;
        }

        #endregion
    }
}
