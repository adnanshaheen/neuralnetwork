using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworkLibAM
{
    /// <summary>
    /// Class representing an artificial neuron
    /// </summary>
    /// <remarks>
    /// <code>
    ///  
    ///  --------------> * W[0] \                              -----  
    ///  --------------> * W[1] - + -------> Bias -------| f | ---------> O
    ///  --------------> * W[i] /                              -----
    ///     SYNAPSES      WEIGHT             Bias       ACTIVATION       OUTPUT
    ///
    /// </code>
    ///</remarks>
    ///
    [Serializable]
    public class Neuron
    {
        protected static Random rand = new Random((int)DateTime.Now.Ticks);
            // random number generator for initializing weights
        
        protected double randomMIN = -1*0.1 ;  // range of random numbers for initialization
        public double RandomMin                // low values help reduce overfitting
        {
            get { return randomMIN; }
            set { randomMIN = value; }
        }
        
        protected double randomMAX = 1*0.1 ;
        public double RandomMax
        {
            get { return randomMAX; }
            set { randomMAX = value; }
        }

        public double[] weights;      // weights in a Neuron
        
        protected double bias = 0f;  // bias
        public double Bias
        {
            get { return bias; }
            set { bias = value; }
        }

        protected double delta = 0;
        public double Delta
        {
            get { return delta; }
            set { delta = value; }
        }

        protected IActivationFunction f = null;
        public IActivationFunction F
        {
            get { return f; }
            set { f = value; }
        }
        
        protected double noutput = 0f;  // last output of neuron
        public double NOutput
        {
            get { return noutput; }
        }
 
        protected double ws = 0f; // last value of sum plus bias
        public double WS
        {
            get { return ws; }
        }

        protected double a;  // f'(x) * error
        public double A
        {
            get { return a; }
            set { a = value; }
        }
       
        public int NumInputs // number of inputs in a neuron
        {
            get { return weights.Length; }
        }
        
        /// <summary>
        /// Indexer of the neuron to get or set weight of synapses
        /// </summary>
        public double this[int num]
        {
            get { return weights[num]; }
            set { weights[num] = value; }
        }
        
        /// <summary>
        /// Get the last output prime of the neuron (f'(ws))
        /// </summary>
        public double OutputPrime
        {
            get { return f.OutputPrime(ws); }
        }
      
        /// <summary>
        /// Build a neurone with Ni inputs
        /// </summary>
        /// <param name="Ni">number of inputs</param>
        /// <param name="af">The activation function of the neuron</param>
        public Neuron(int Ni, IActivationFunction iaf)
        {
            weights = new double[Ni];
            f = iaf;
        }
        /// <summary>
        /// Build a neurone with Ni inputs whith a default 
        /// activation function (SIGMOID)
        /// </summary>
        /// <param name="Ni">number of inputs</param>
        public Neuron(int Ni)
        {
            weights = new double[Ni];
            f = new SigmoidActivation();
        }

        #region PUBLIC METHODS (INITIALIZATION FUNCTIONS)

        /// <summary>
        /// Randomize Weight for each input between R_MIN and R_MAX
        /// </summary>
        public void randomizeWeight()
        {
            for (int i = 0; i < NumInputs; i++)
            {
                weights[i] = randomMIN + (((double)(rand.Next(1000))) / 1000f) * (randomMAX - randomMIN);
            }
        }
        /// <summary>
        /// Randomize the threshold (between R_MIN and R_MAX)
        /// </summary>
        public void randomizeBias()
        {
            bias = randomMIN + (((double)(rand.Next(1000))) / 1000f) * (randomMAX - randomMIN);
        }
        /// <summary>
        /// Randomize the threshold and the weights
        /// </summary>
        public void randomizeAll()
        {
            randomizeWeight();
            randomizeBias();
        }

        #endregion

        #region PUBLIC METHODS (COMPUTE THE OUTPUT VALUE)

        /// <summary>
        /// Compute the output of the neurone
        /// </summary>
        /// <param name="input">The input vector</param>
        /// <returns>The output value of the neuron ( =f(ws) )</returns>
        public double ComputeOutput(double[] input)
        {
            ws = 0;
            for (int i = 0; i < NumInputs; i++)
                ws += weights[i] * input[i];
            ws += bias;
            if (f != null)
                noutput = f.Output(ws);
            else
                noutput = ws;
            return noutput;
        }
        #endregion
    }
}
