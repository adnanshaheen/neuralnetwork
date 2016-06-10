using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadMNIST
{
    class DataPoint // represents one image and its class label
    {
        double[] data;
        public double[] Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        int classLabel = -1;  // for digit recog., this can be 0 - 9
        public int ClassLabel
        {
            get
            {
                return classLabel;
            }
            set
            {
                classLabel = value;
            }
        }

        int dimensionality;
        public int Dimensionality
        {
            get
            {
                return dimensionality;
            }
            set
            {
                dimensionality = value;
            }
        }

        public DataPoint(int labelInput, int dimension, double[] dataInput)  // 28x28
        {
            ClassLabel = labelInput;
            dimensionality = dimension;
            data = new double[dimensionality];
            if (dataInput != null)  // added to accomodate Parallel.For
            {
                for (int i = 0; i < dimensionality; i++)
                {
                    data[i] = dataInput[i];
                }
            }
        }

     }
}
