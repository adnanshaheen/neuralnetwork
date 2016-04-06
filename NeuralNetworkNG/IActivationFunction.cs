using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworkLibAM
{
    public interface IActivationFunction
    {
        double Output(double x);       // f(x) computation, e.g. Sigmoid
        double OutputPrime(double x);  // f'(x) computation
    }
}
