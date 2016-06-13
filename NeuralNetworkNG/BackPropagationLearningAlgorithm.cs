using Mapack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkLibAM
{
    /// <summary>
    /// Implementation of stockastic gradient backpropagation
    /// learning algorithm
    /// </summary>
    /// <remarks>
    /// <code>
    /// 
    ///                      PROPAGATION WAY IN NN
    ///                    ------------------------->
    /// 
    ///        o ----- Sj = f(WSj) ----> o ----- Si = f(WSi) ----> o
    ///      Neuron j                Neuron i                   Neuron k
    ///    (layer L-1)               (layer L)                 (layer L+1)
    /// 
    /// For the neuron i :
    /// -------------------
    /// W[i,j](n+1) = W[i,j](n) + alpha * Ai * Sj + gamma * ( W[i,j](n) - W[i,j](n-1) )
    /// T[i](n+1) = T[i](n) - alpha * Ai + gamma * ( T[i](n) - T[i](n-1) )
    /// 
    ///		with :
    ///				Ai = f'(WSi) * (expected_output_i - si) for output layer
    ///				Ai = f'(WSi) * SUM( Ak * W[k,i] )       for others
    /// 
    /// </code>
    /// NOTE : This is stockastic version of the algorithm because the error
    /// is back-propaged after every learning case. There is another version
    /// of this algorithm which works on global error.
    /// </remarks>
    [Serializable]
    class BackPropagationLearningAlgorithm : LearningAlgorithm
    {
 		protected double alpha = 0.1f;  // training rate
        object olock = new object();
        public double Alpha 
		{
			get { return alpha; }
			set { alpha = (value>0)?value:alpha; }
		}

        public bool bDoStochastic = true;  // set to false for batch

		protected double gamma = 0.2f;  // (Rumelhart coef) between 0 and 1
        public double Gamma 
		{
			get { return gamma; }
			set { gamma = (value>0)?value:gamma; }
		}

        protected double lambda = 0; //0.00008;  //value has to be small - a ref. paper used 0.00008, 0 = no regularization
        public double Lambda   // regularization parameter - should be a low value
        {
            get { return lambda; }
            set { lambda = value; }
        }

        private double beta = 6.0;  // beta value

        private double rho = 0.01;  // rho value

        protected double[] e;  // error vector

        #region CONSTRUCTOR
        /// <summary>
        /// Build a new BackPropagation learning algorithm instance
        /// with alpha = 0,5 and gamma = 0,3
        /// </summary>
        /// <param name="nn">The neural network to train</param>
        public BackPropagationLearningAlgorithm(Network nn) : base(nn) 
		{
		}

		#endregion

		#region LEARNING METHODS

		/// <summary>
		/// To train the neuronal network on data.
		/// inputs[n] represents an input vector of 
		/// the neural network and expected_outputs[n]
		/// the expected ouput for this vector. 
		/// </summary>
		/// <param name="inputs">the input matrix</param>
		/// <param name="expected_outputs">the expected output matrix</param>
		public override void Learn(double[][] inputs, double[][] expected_outputs) 
		{
            base.Learn(inputs, expected_outputs);
			double[] nout;  // output value array
			double err = 0;
            iter = 0;
			do 
			{
				error = 0f;
				e = new double[nnet.NumOutputs];  // output error array
                
                //--------------initialize lists for storing DeltaWJ and DeltaBJ----
                List<Matrix> DeltaWList = new List<Matrix>();
                List<Matrix> DeltaBList = new List<Matrix>();
                InitializeDeltaWJDeltaBJLists(DeltaWList, DeltaBList);
                //------------------------------------------------------------------

                // ins is the input training data 2-D array
                for (int i=0; i<ins.Length; i++)   // for each input trainng dataset
                //Parallel.For(0, ins.Length, i =>  // NOTE: This gives us bad result, we can't do this
                {
                    err = 0f;
                    nout = nnet.Output(inputs[i], i);  // compute outputs of the Neural Network, for a training set
                                                    // it stores output, ws in each neuron
                    for (int j = 0; j < nout.Length; j++)
                    {
                        e[j] = outs[i][j] - nout[j];  // outs is the training expected data set
                        err += e[j] * e[j];  // square the error
                    }
                    err /= 2f; error = err;

                    ComputeDeltas(i);   // computes delta on each neuron and stores it in the neuron - see NG
                    ComputeDeltaWAndDeltaBForEachLayer(DeltaWList, DeltaBList, inputs, i);
                    if (bDoStochastic == true)
                        UpdateWeightsStochastic(DeltaWList, DeltaBList);
                }//);  // all training set data processed for one round
				iter++;
                if ((iter % 50) == 0)
                    Console.WriteLine("Training Iteration - Epoch = " + iter.ToString() + " Error=" + err.ToString());
                if (bDoStochastic == false)
                    UpdateWeightsBatch(DeltaWList, DeltaBList);
                RandomizeInputsExpectedOutputs();   // double check to see if randomization is proper
            }
            while (iter < MAX_ITER && this.error > ERROR_THRESHOLD);
		}

        void RandomizeInputsExpectedOutputs()
        {
            Random rand = new Random();
            int count = ins.Length;
            for (int i = 0; i < count; i++)
            {
                // swap input i with another randomly selected input
                // make sure you also swap the expected output;
                int nextInput = rand.Next(count);
                if (nextInput != i)
                {
                    int size = ins[0].GetLength(0);
                    double[] t1 = new double[size];
                    for (int j = 0; j < size; j++)
                        t1[j] = ins[i][j];
                    ins[i] = ins[nextInput];
                    ins[nextInput] = t1;

                    int sizeOut = outs[0].GetLength(0);
                    double[] t1out = new double[sizeOut];
                    for (int k = 0; k < sizeOut; k++)
                        t1out[k] = outs[i][k];
                    outs[i] = outs[nextInput];
                    outs[nextInput] = t1out;
                }
            }
        }

        void InitializeDeltaWJDeltaBJLists(List<Matrix> DeltaWList, List<Matrix> DeltaBList)
        {
            //------------initialize deltas (DeltaW and Deltab)----------------------
            for (int i = 0; i < nnet.NumLayers; i++)    // input layer is not counted in NumLayers
            {                                           // output layer is counted
                if (i == 0)
                {
                    Matrix m1 = new Matrix(nnet.layers[i].NumNeurons, nnet.NumInputs);
                    DeltaWList.Add(m1);
                }
                else
                {
                    Matrix m1 = new Matrix(nnet.layers[i].NumNeurons, nnet.layers[i - 1].NumNeurons);
                    DeltaWList.Add(m1);
                }
            }
            //------------create the b list----------------
            for (int i = 0; i < nnet.NumLayers; i++)
            {
                Matrix m1 = new Matrix(nnet.layers[i].NumNeurons, 1);
                DeltaBList.Add(m1);
            }
            //--------------------------------------------
        }

        void ComputeDeltaWAndDeltaBForEachLayer(List<Matrix> DeltaWList,List<Matrix> DeltaBList,
            double[][] inputs, int i)  // i is the training input number
        {
            //---------compute DeltaW and DeltaB----------------
            for (int kk = 0; kk < nnet.NumLayers; kk++)
            {
                Matrix DelWJ = null; Matrix DelbJ = null;
                if (kk == 0)  // first hidden layer's deltaW is based on inputs
                {
                    Matrix inp = new Matrix(nnet.NumInputs, 1);   // input matrix for holding inputs
                    for (int jj = 0; jj < nnet.NumInputs; jj++)
                        inp[jj, 0] = inputs[i][jj];
                    DelWJ = nnet.GetDelta(kk) * (inp.Transpose());
                    DelbJ = nnet.GetDelta(kk);
                }
                else
                {
                    DelWJ = nnet.GetDelta(kk) * (nnet.GetA(kk - 1).Transpose());
                    DelbJ = nnet.GetDelta(kk);
                }
                if (bDoStochastic == true)
                {
                    DeltaWList[kk] = DelWJ;
                    DeltaBList[kk] = DelbJ;
                }
                else
                {
                    DeltaWList[kk] = DeltaWList[kk] + DelWJ;
                    DeltaBList[kk] = DeltaBList[kk] + DelbJ;
                }
            }
        }

        /// <summary>
		/// Compute the "Delta" for each neuron
		/// </summary>
		/// <param name="i">the index of the curent training data</param>
        void ComputeDeltas(int i)  // i is the input
        {
            // ------------------set delta for each neuron-----------------
            double sk;
            int l = nnet.NumLayers - 1;
            // For the last layer
            for (int j = 0; j < nnet[l].NumNeurons; j++)  // N_Neurons = number of neurons in a layer
                nnet[l][j].Delta = nnet[l][j].OutputPrime * -1 * (outs[i][j] - nnet[l][j].NOutput);
            // For other layers
            for (l--; l >= 0; l--)
            {
                for (int j = 0; j < nnet[l].NumNeurons; j++)
                {
                    sk = 0f;
                    for (int k = 0; k < nnet[l + 1].NumNeurons; k++)
                        sk += nnet[l + 1][k].Delta * nnet[l + 1][k][j];    // Delta from curr layer * weight 
                    nnet[l][j].Delta = nnet[l][j].OutputPrime * sk;

                    if (Autoencoder)
                    {
                        nnet[l][j].Delta += beta * (((rho / nnet.LearningAlg.Sparsity) * -1) +
                            ((1 - rho) / (1 - nnet.LearningAlg.Sparsity)));
                    }
                }
            }
        }

        void UpdateWeightsStochastic(List<Matrix> DeltaWList, List<Matrix> DeltaBList)
        {
            for (int kk = 0; kk < nnet.NumLayers; kk++)
            {
                Matrix W = nnet.GetW(kk) - Matrix.Multiply((DeltaWList[kk] + Matrix.Multiply(nnet.GetW(kk), lambda)), alpha);
                nnet.SetW(kk, W);
                Matrix b = nnet.Getb(kk) - Matrix.Multiply(DeltaBList[kk], alpha);
                nnet.Setb(kk, b);
            }
        }

        void UpdateWeightsBatch(List<Matrix> DeltaWList, List<Matrix> DeltaBList)
        {
            for (int kk = 0; kk < nnet.NumLayers; kk++)
            {
                Matrix Wold = nnet.GetW(kk);
                Matrix W = nnet.GetW(kk) - Matrix.Multiply((Matrix.Multiply(DeltaWList[kk], 1.0 / ins.Length) + Matrix.Multiply(nnet.GetW(kk), lambda)), alpha);
                nnet.SetW(kk, W);
                Matrix Wnew2 = nnet.GetW(kk);

                Matrix b = nnet.Getb(kk) - Matrix.Multiply(Matrix.Multiply(DeltaBList[kk], 1.0 / ins.Length), alpha);
                nnet.Setb(kk, b);
            }
        }

        #endregion
    }
}
