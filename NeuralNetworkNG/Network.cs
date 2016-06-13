using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Mapack;

namespace NeuralNetworkLibAM
{
    /// <summary>
    /// Implementation of artificial neural network
    /// </summary>  
    /// <remarks>
    /// <code>
    /// 
    /// 
    ///                        o
    ///                        o  o  o  
    ///    INPUT VECTOR =====> o  o  o =====> OUTPUT VECTOR
    ///                        o  o  o  
    ///                        o
    ///                      NERON LAYERS
    /// 
    /// </code> 
    /// Each neuron of the layer N-1 is conected to 
    /// every neuron of the layer N.
    /// At the begining the neural network needs to
    /// learn using couples (INPUT, EXPECTED OUTPUT)
    /// and a learnig algorithm.
    /// </remarks>
    [Serializable]
    public class Network
    {
        public Layer[] layers;  // layers in the network

        public int NumLayers
        {
            get { return layers.Length; }
        }

        protected int numInputs;  // number of inputs i.e., to first layer
        public int NumInputs
        {
            get { return numInputs; }
        }
        
        public int NumOutputs  // number of outputs = number of neurons in output layer
        {
            get { return layers[NumLayers - 1].NumNeurons; }
        }

        /// <summary>
        /// Learning algorithm used by the network
        /// </summary>
        protected LearningAlgorithm learningAlg;
        public LearningAlgorithm LearningAlg
        {
            get { return learningAlg; }
            set { learningAlg = (value != null) ? value : learningAlg; }
        }
     
       
 
        /// <summary>
        /// Get the n th Layer of the network 
        /// </summary>
        public Layer this[int n]
        {
            get { return layers[n]; }
        }

        #region NETWORK CONSTRUCTOR

        /// <summary>
        /// Create a new neural network
        /// with "inputs" inputs and size of "layers"
        /// layers of neurones.
        /// The layer i is made with layers_desc[i] neurones.
        /// The activation function of each neuron is set to n_act.
        /// The lerning algorithm is set to learn.
        /// </summary>
        /// <param name="inputs">Number of inputs of the network</param>
        /// <param name="layers_desc">Number of neurons for each layer of the network</param>
        /// <param name="activationFunc">Activation function for each neuron in the network</param>
        /// <param name="learnAlg">Learning algorithm to be used by the neural network</param>
        public Network(int inputs, int[] layers_desc, IActivationFunction activationFunc, LearningAlgorithm learnAlg)
        {
            if (layers_desc.Length < 1)
                throw new Exception("PERCEPTRON : cannot build perceptron, it must have at least 1 layer of neurons");
            if (inputs < 1)
                throw new Exception("PERCEPTRON : cannot build perceptron, it must have at least 1 input");
            learningAlg = learnAlg;
            numInputs = inputs;
            layers = new Layer[layers_desc.Length];
            layers[0] = new Layer(layers_desc[0], numInputs);
            for (int i = 1; i < layers_desc.Length; i++)
                layers[i] = new Layer(layers_desc[i], layers_desc[i - 1], activationFunc);
        }
        
        /// <summary>
        /// Create a new neural network
        /// with "inputs" inputs and size of "layers"
        /// layers of neurones.
        /// The layer i is made with layers_desc[i] neurones.
        /// The activation function of each neuron is set to n_act.
        /// The lerning algorithm is set to default (Back Propagation).
        /// </summary>
        /// <param name="inputs">Number of inputs of the network</param>
        /// <param name="layers_desc">Number of neurons for each layer of the network</param>
        /// <param name="activationFunc">Activation function for each neuron in the network</param>
        public Network(int inputs, int[] layers_desc, IActivationFunction activationFunc)
        {
            if (layers_desc.Length < 1)
                throw new Exception("PERCEPTRON : cannot build perceptron, it must have at least 1 layer of neurone");
            if (inputs < 1)
                throw new Exception("PERCEPTRON : cannot build perceptron, it must have at least 1 input");
            learningAlg = new BackPropagationLearningAlgorithm(this);
            numInputs = inputs;
            layers = new Layer[layers_desc.Length];
            layers[0] = new Layer(layers_desc[0], numInputs);
            for (int i = 1; i < layers_desc.Length; i++)
                layers[i] = new Layer(layers_desc[i], layers_desc[i - 1], activationFunc);
        }
        /// <summary>
        /// Create a new neural network
        /// with "inputs" inputs and size of "layers"
        /// layers of neurones.
        /// The layer i is made with layers_desc[i] neurones.
        /// The activation function of each neuron is set to default (Sigmoid with beta = 1).
        /// The lerning algorithm is set to default (Back Propagation).
        /// </summary>
        /// <param name="inputs">Number of inputs of the network</param>
        /// <param name="layers_desc">Number of neurons for each layer of the network</param>
        public Network(int inputs, int[] layers_desc)
        {
            if (layers_desc.Length < 1)
                throw new Exception("PERCEPTRON : cannot build perceptron, it must have at least 1 layer of neurone");
            if (inputs < 1)
                throw new Exception("PERCEPTRON : cannot build perceptron, it must have at least 1 input");
            learningAlg = new BackPropagationLearningAlgorithm(this);
            numInputs = inputs;
            IActivationFunction n_act = new SigmoidActivation();
            layers = new Layer[layers_desc.Length];
            layers[0] = new Layer(layers_desc[0], numInputs);
            for (int i = 1; i < layers_desc.Length; i++)
                layers[i] = new Layer(layers_desc[i], layers_desc[i - 1], n_act);
        }

        #endregion

        #region INITIALIZATION FUNCTIONS

        /// <summary>
        /// Randomize all neurones weights between -0.5 and 0.5
        /// </summary>
        public void randomizeWeight()
        {
            foreach (Layer l in layers)
                l.randomizeWeight();
        }
        /// <summary>
        /// Randomize all neurones threholds between 0 and 1
        /// </summary>
        public void randomizeBias()
        {
            foreach (Layer l in layers)
                l.randomizeBias();
        }
        /// <summary>
        /// Randomize all neurones threholds between 0 and 1
        /// and weights between -0.5 and 0.5
        /// </summary>
        public void randomizeAll()
        {
            foreach (Layer l in layers)
                l.randomizeAll();
        }
        /// <summary>
        /// Set an activation function to all neurons of the network
        /// </summary>
        /// <param name="f">An activation function</param>
        public void setActivationFunction(IActivationFunction f)
        {
            foreach (Layer l in layers)
                l.setActivationFunction(f);
        }
        /// <summary>
        /// Set the interval in which weights and threshold will be randomized
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void setRandomizationInterval(double min, double max)
        {
            foreach (Layer l in layers)
                l.setRandomizationInterval(min, max);
        }

        #endregion

        #region OUPUT METHODS

        /// <summary>
        /// Compute the value for the specified input
        /// </summary>
        /// <param name="input">the input vector</param>
        /// <param name="ins">compute sparseness only for hidden layer</param>
        /// <returns>the output vector of the neuronal network</returns>
        public double[] Output(double[] input, int ins = -1)  // computes output of the whole network, given inputs
        {
            if (input.Length != numInputs)
                throw new Exception("PERCEPTRON : Wrong input vector size, unable to compute output value");
            double[] result;
            result = layers[0].Output(input);

            /* Sparsity */
            if (ins != -1 && LearningAlg.Autoencoder)
                CalculateSparsity(input, result);

            for (int i = 1; i < NumLayers; i++)
                result = layers[i].Output(result);
            return result;
        }

        private void CalculateSparsity(double[] input, double[] result)
        {
            /* compute average of hidden layer */
            double avg = 0;
            for (int i = 0; i < result.Length; i++)
            {
                avg += result[i];
            }
            avg /= result.Length;

            /* multiply avg with sum of input for this image */
            double sum = 0;
            for (int j = 0; j < input.Length; j++)
            {
                sum += input[j];
            }

            avg *= sum;

            /* divide by number of hidden layer */
            avg /= result.Length;

            /* keep it in */
            this.LearningAlg.Sparsity = avg;
        }

        public Matrix GetDelta(int layernum)
        {
            Matrix mres = new Matrix(this.layers[layernum].NumNeurons, 1);
            try
            {
                for (int i = 0; i < this.layers[layernum].NumNeurons; i++)
                {
                    mres[i, 0] = layers[layernum][i].Delta;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return mres;
        }

        public Matrix GetA(int layernum)
        {
            Matrix mres = new Matrix(this.layers[layernum].NumNeurons, 1);
            try
            {
                for (int i = 0; i < this.layers[layernum].NumNeurons; i++)
                {
                    mres[i, 0] = layers[layernum][i].NOutput;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return mres;
        }

        public Matrix Getb(int layernum)
        {
            Matrix mres = new Matrix(this.layers[layernum].NumNeurons, 1);
            try
            {
                for (int i = 0; i < this.layers[layernum].NumNeurons; i++)
                {
                    mres[i, 0] = layers[layernum][i].Bias;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return mres;
        }


        public void Setb(int layernum, Matrix b)
        {
            Matrix mres = new Matrix(this.layers[layernum].NumNeurons, 1);
            try
            {
                for (int i = 0; i < this.layers[layernum].NumNeurons; i++)
                {
                    layers[layernum][i].Bias = b[i,0];
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Matrix GetW(int layernum)
        {
            Matrix mres = null;
            if (layernum == 0)
                mres = new Matrix(this.layers[layernum].NumNeurons, this.numInputs);
            else
                mres = new Matrix(this.layers[layernum].NumNeurons, this.layers[layernum-1].NumNeurons);
            try
            {
                if (layernum == 0)
                {
                    for (int i = 0; i < this.numInputs; i++)
                    {
                        for (int j = 0; j < this.layers[layernum].NumNeurons; j++)
                        {
                            mres[j, i] = layers[layernum][j].weights[i];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.layers[layernum-1].NumNeurons; i++)
                    {
                        for (int j = 0; j < this.layers[layernum].NumNeurons; j++)
                        {
                            mres[j, i] = layers[layernum][j].weights[i];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return mres;
        }

        public void SetW(int layernum, Matrix Wnew)
        {
           try
            {
                if (layernum == 0)
                {
                    for (int i = 0; i < this.numInputs; i++)
                    {
                        for (int j = 0; j < this.layers[layernum].NumNeurons; j++)
                        {
                            layers[layernum][j].weights[i] = Wnew[j,i];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.layers[layernum - 1].NumNeurons; i++)
                    {
                        for (int j = 0; j < this.layers[layernum].NumNeurons; j++)
                        {
                            layers[layernum][j].weights[i] = Wnew[j,i];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region PERSISTANCE IMPLEMENTATION
        /// <summary>
        /// Save the Neural Network in a binary formated file
        /// </summary>
        /// <param name="file">the target file path</param>
        public void save(string file)
        {
            IFormatter binFmt = new BinaryFormatter();
            Stream s = File.Open(file, FileMode.Create);
            binFmt.Serialize(s, this);
            s.Close();
        }
        /// <summary>
        /// Load a neural network from a binary formated file
        /// </summary>
        /// <param name="file">the neural network file file</param>
        /// <returns></returns>
        public static Network load(string file)
        {
            Network result;
            try
            {
                IFormatter binFmt = new BinaryFormatter();
                Stream s = File.Open(file, FileMode.Open);
                result = (Network)binFmt.Deserialize(s);
                s.Close();
            }
            catch (Exception e)
            {
                throw new Exception("NeuralNetwork : Unable to load file " + file + " : " + e);
            }
            return result;
        }
        #endregion
    }
}
