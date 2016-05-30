using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            //for (int i = 0; i < cols; ++i)
            Parallel.For(0, cols, i =>
            {
                covariance[i] = new double[cols];
                for (int j = 0; j < cols; ++j)
                {
                    double val = 0;
                    for (int k = 0; k < row; ++k)
                        val += Data[k][i] * Data[k][j];

                    covariance[i][j] = val;
                }
            });

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
            int len = matrix.Rows - 1;                              /* get final index */
            double[][] EigenVector = new double[matrix.Rows][];     /* create a matrix of top rows */
            for (int i = 0; i < matrix.Rows; ++i) {
                EigenVector[i] = new double[top];                   /* create a row each of matrix.Columns */
                for (int j = 0; j < top; ++j)
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
            //for (int i = 0; i < aRow; ++i)
            Parallel.For(0, aRow, i =>
            {
                result[i] = new double[B[0].Length];
                for (int j = 0; j < bCol; ++j)
                    for (int k = 0; k < aCol; ++k)
                        result[i][j] += A[i][k] * B[k][j];
            });
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

        public static double[] EuclDistance(double[][] project, double[][] projectionInput)
        {
            double[] result = new double[projectionInput.Length];
            for (int i = 0; i < projectionInput.Length; i++)
            {
                double res = 0;
                for (int j = 0; j < projectionInput[0].Length; j++)
                    res += (projectionInput[i][j] - project[0][j]) * (projectionInput[i][j] - project[0][j]);
                result[i] = Math.Sqrt(res);
            }
            return result;
        }

        public static double[][] ConvertToPixels(double[][] data)
        {
            double[][] result = new double[data.Length][];
            double min = 0;
            double max = 0;
            for (int i = 0; i < data.Length; i++)
            {
                min = data[i].Min();
                max = data[i].Max();
                result[i] = new double[data[0].Length];
                for (int j = 0; j < data[0].Length; j++)
                    result[i][j] = ((data[i][j] - min) / (max - min)) * 255;
            }
            return result;
        }

        public static Bitmap Draw(double[][] image, int iNo, string dir)
        {
            DirectoryInfo diR = new DirectoryInfo(dir);

            FileInfo[] files = diR.GetFiles();
            String filename = files[0].FullName;
            Bitmap bmp = new Bitmap(Image.FromFile(filename));
            int width = bmp.Width;
            int height = bmp.Height;
            Bitmap bitmap = new Bitmap(width, height);
            int iCol = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    byte R = (byte)image[iNo][iCol];
                    byte G = (byte)image[iNo][iCol];
                    byte B = (byte)image[iNo][iCol];
                    bitmap.SetPixel(i, j, Color.FromArgb(R, G, B));
                    ++ iCol;
                }
            }
            return bitmap;
        }
    }
}
