using LoadMNIST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworkLibAM
{
    /// <summary>
    /// The abstract class describing a learning
    /// algorithm for a neural network
    /// </summary>
    [Serializable]
    public abstract class LearningAlgorithm
    {
        protected Network nnet;
        public Network N_Network
        {
            get { return nnet; }
        }

        protected double ERROR_THRESHOLD = 0.001f; // training error to stop
        public double ErrorTreshold
        {
            get { return ERROR_THRESHOLD; }
            set { ERROR_THRESHOLD = (value > 0) ? value : ERROR_THRESHOLD; }
        }

        protected int MAX_ITER = 1000;
        public int MaxIteration
        {
            get { return MAX_ITER; }
            set { MAX_ITER = (value > 0) ? value : MAX_ITER; }
        }

        protected double[][] ins;   // input training data
 
        protected double[][] outs;  // expected outputs from training data

        protected int iter = 0;  // iteration count
        public int Iteration
        {
            get { return iter; }
        }

        protected double error = -1;  // current error
        public double Error
        {
            get { return error; }
        }

        private double sparsity;   // sparsity
        public double Sparsity
        {
            get
            {
                return sparsity;
            }

            set
            {
                sparsity = value;
            }
        }

        private bool autoencoder;
        public bool Autoencoder
        {
            get
            {
                return autoencoder;
            }

            set
            {
                autoencoder = value;
            }
        }


        #region CONSTRUCTOR AND METHODS

        /// <summary>
        /// Learning algorithm constructor
        /// </summary>
        /// <param name="n">The neural network to train</param>
        public LearningAlgorithm(Network n)
        {
            nnet = n;
        }

        /// <summary>
        /// To train the neuronal network on data.
        /// inputs[n] represents an input vector of 
        /// the neural network and expected_outputs[n]
        /// the expected ouput for this vector. 
        /// </summary>
        /// <param name="inputs">the input matrix</param>
        /// <param name="expected_outputs">the expected output matrix</param>
        public virtual void Learn(double[][] inputs, double[][] expected_outputs)
        {
            if (inputs.Length < 1)
                throw new Exception("LearningAlgorithme : no input data : cannot learn from nothing");
            if (expected_outputs.Length < 1)
                throw new Exception("LearningAlgorithme : no output data : cannot learn from nothing");
            if (inputs.Length != expected_outputs.Length)
                throw new Exception("LearningAlgorithme : inputs and outputs size does not match : learning aborded ");
            ins = inputs;
            outs = expected_outputs;

            Autoencoder = ins[0].Length == outs[0].Length;
        }


        #endregion

    }
}
