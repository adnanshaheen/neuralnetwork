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
            double[] iMean = new double[Data.Length];
            for (int i = 0; i < Data.Length; ++ i)
            {
                for (int j = 0; j < Data[0].Length; ++ j)
                {
                    iMean[i] += Data[i][j];
                }
                iMean[i] /= Data[0].Length;
            }
            return iMean;
        }

        public static void SubMean(double[][] Data, double[] iMean)
        {
            for (int i = 0; i < Data[0].Length; i++)
            {
                for (int j = 0; j < iMean.Length; ++j)
                {
                    Data[i][j] -= iMean[j];
                }
            }
        }
        public static double[][] Covariance(double[][] Data)
        {
            double[][] covariance = new double[Data[0].Length][];
            int row = Data.Length;
            int cols = Data[0].Length;
            for (int i = 0; i < cols; ++i)
            {
                covariance[i] = new double[Data[i].Length];
                for (int j = 0; j < cols; ++j)
                {
                    for (int k = 0; k < row; ++ k)
                    {
                        covariance[i][j] += Data[k][i] * Data[k][j];
                    }
                }
            }

            return covariance;
        }

        public static void GetTopN(double[] values, double[] topVal, int top)
        {
            for (int i = 0; i < top; ++i)
                topVal[i] = values[i];
        }

        public static double[][] GetEigenVector(PCALib.IMatrix matrix, int top)
        {
            double[][] EigenVector = new double[matrix.Rows][];
            for (int i = 0; i < matrix.Rows; ++i) {
                EigenVector[i] = new double[top];
                for (int j = 0; j < top; ++j)
                    EigenVector[i][j] = matrix[i, j];
            }
            return EigenVector;
        }
    }
}
