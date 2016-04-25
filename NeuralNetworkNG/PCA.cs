using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkNG
{
    class PCA
    {
        public static double[] FindMean(double[][] Data)
        {
            double[] iMean = new double[Data[0].Count()];
            for (int i = 0; i < iMean.Count(); ++i)
            {
                for (int j = 0; j < Data.Count(); ++j)
                {
                    iMean[i] += Data[j][i];
                }
                iMean[i] /= Data.Count();
            }
            return iMean;
        }

        public static void SubMean(double[][] Data, double[] iMean)
        {
            for (int i = 0; i < Data.Count(); i++)
            {
                for (int j = 0; j < iMean.Count(); ++j)
                {
                    Data[i][j] -= iMean[j];
                }
            }
        }
        public static void Covariance(double[][] Data)
        {

        }
    }
}
