using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworkLibAM
{
    /// <summary>
    /// The sigmoid activation function
    /// </summary>
    /// <remarks>
    /// Here is the definition of the sigmoid activation function
    /// <code>
    ///                1
    /// f(x) = -----------------   beta > 0
    ///         1 + e^(-beta*x)
    /// 
    /// f'(x) = beta * f(x) * ( 1 - f(x) )   
    /// </code>     
    /// </remarks>
    [Serializable]
    class SigmoidActivation : IActivationFunction
    {
        protected double beta = 1.0f;  // sigmoid parameter
        public double Beta
        {
            get { return beta; }
            set { beta = (value > 0) ? value : 1.0f; }
        }
        
        public string Name  // readonly
        {
            get { return "Sigmoid"; }
        }
        
        public virtual double Output(double x)
        {
            return (double)(1 / (1 + Math.Exp(-beta * x)));
        }


        /// <summary>
        /// <code>
        /// f'(x) = beta * f(x) * ( 1 - f(x) )
        /// </code>
        /// </summary>
        /// <param name="x">x</param>
        /// <returns>f'(x)</returns>
        public virtual double OutputPrime(double x)
        {
            double y = Output(x);
            return (beta * y * (1 - y));
        }
    }
}
