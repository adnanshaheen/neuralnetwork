using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadMNIST
{
    public class DataPoint // represents one image and its class label
    {
        byte[] data;
        public byte[] Data
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

        double bestDistance;
        public double BestDistance
        {
            get
            {
                return bestDistance;
            }
            set
            {
                bestDistance = value;
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

        string fileName;
        public string Filename
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public DataPoint(int labelInput, int dimension, byte[] dataInput)  // 28x28
        {
            ClassLabel = labelInput;
            dimensionality = dimension;
            data = new byte[dimensionality];
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
