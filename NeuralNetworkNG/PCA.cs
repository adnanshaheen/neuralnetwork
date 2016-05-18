using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkNG
{
    public class PCA
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
            for (int i = 0; i < Data.Length; i++)
            {
                for (int j = 0; j < Data[0].Length; ++j)
                {
                    Data[i][j] -= iMean[i];
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
                covariance[i] = new double[cols];
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
            int len = values.Length - 1;                        /* get final index */
            for (int i = 0; i < top; ++i)
                topVal[i] = values[len - i];                    /* get top values, values are sorted descending order */
        }

        public static double[][] GetEigenVector(PCALib.IMatrix matrix, int top)
        {
            int len = matrix.Rows - 1;                          /* get final index */
            double[][] EigenVector = new double[top][];         /* create a matrix of top rows */
            for (int i = 0; i < top; ++i) {
                EigenVector[i] = new double[matrix.Columns];    /* create a row each of matrix.Columns */
                for (int j = 0; j < matrix.Columns; ++j)
                    EigenVector[i][j] = matrix[len - i, j];     /* copy only top eigen vectors */
            }
            return EigenVector;
        }

        public static double[][] Multiply(double[][] A, double[][] B)
        {
            int aRow = A.Length;
            int aCol = A[0].Length;
            int bCol = B[0].Length;
            double[][] result = new double[aRow][];
            for (int i = 0; i < aRow; ++i)
            {
                result[i] = new double[B[0].Length];
                for (int j = 0; j < bCol; ++j)
                    for (int k = 0; k < aCol; ++k)
                        result[i][j] += A[i][k] * B[k][j];
            }
            return result;
        }

        public static double[][] Transpose(double[][] matrix, int max)
        {
            double[][] result = new double[max][];
            for (int i = 0; i < max; ++i)
            {
                result[i] = new double[matrix.Length];
                for (int j = 0; j < matrix.Length; j++)
                    result[i][j] = matrix[j][i];
            }
            return result;
        }
    }
}
