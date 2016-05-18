using LoadMNIST;
using Mapack;
using NeuralNetworkLibAM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkNG
{
    public partial class Form1 : Form
    {
        NeuralNetworkLibAM.Network nn = null;
        double[][] testPatterns = null;
        double[] iMean = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (nn == null)
            {
                MessageBox.Show("Please train me first!!!");
                return;
            }
            double[] testInput = {
                0, 1, 1, 1, 1,
                0, 1, 0, 0, 0,
                0, 1, 0.9, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 1, 0.8, 0
            };
            double[] res = nn.Output(testInput);
            string out1 = "";
            int i = 0;
            foreach (double num in res)
            {
                out1 += i.ToString() + " : " + num.ToString() + "\n";
                i++;
            }
            MessageBox.Show(out1);
            out1 = "";
            for (i = 0; i < 10; i++)
            {
                out1 += nn.Output(testPatterns[i])[i].ToString() + "\n";
            }
            MessageBox.Show(out1);
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            //Mapack.Matrix m1 = new Mapack.Matrix(1, 3);
            //m1[0, 0] = 5;
            //m1[0, 1] = 7;
            //m1[0, 2] = 8;
            //Mapack.Matrix m2 = new Mapack.Matrix(3, 1);
            //m2[0, 0] = 3;
            //m2[1, 0] = 4;
            //m2[2, 0] = 2;
            //Matrix m3 = m1 * m2;
            int[] layers = { 40, 10 }; // neurons in hidden layer, ouput layer
            nn = new Network(25, layers);   // # of inputs
            nn.randomizeAll();
            nn.LearningAlg.ErrorTreshold = 0.0001f;
            nn.LearningAlg.MaxIteration = 10000;

            double[] pattern0 = {
                0, 1, 1, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 1, 1, 0
            };
            double[] pattern1 = {
                0, 0, 1, 0, 0,
                0, 1, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0
            };
            double[] pattern2 = {
                0, 1, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 1, 1, 1, 0,
                0, 1, 0, 0, 0,
                0, 1, 1, 1, 0
            };
            double[] pattern3 = {
                0, 1, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 1, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 1, 1, 1, 0
            };
            double[] pattern4 = {
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0
            };
            double[] pattern5 = {
                0, 1, 1, 1, 0,
                0, 1, 0, 0, 0,
                0, 1, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 1, 1, 1, 0
            };
            double[] pattern6 = {
                0, 1, 1, 1, 0,
                0, 1, 0, 0, 0,
                0, 1, 1, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 1, 1, 0
            };
            double[] pattern7 = {
                0, 1, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 1, 0, 0,
                0, 1, 0, 0, 0
            };
            double[] pattern8 = {
                0, 1, 1, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 1, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 1, 1, 0
            };
            double[] pattern9 = {
                0, 1, 1, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 1, 1, 1, 0
            };
            testPatterns = new double[10][];
            for (int i = 0; i < 10; i++)
                testPatterns[i] = new double[25];

            testPatterns[0] = pattern0;
            testPatterns[1] = pattern1;
            testPatterns[2] = pattern2;
            testPatterns[3] = pattern3;
            testPatterns[4] = pattern4;
            testPatterns[5] = pattern5;
            testPatterns[6] = pattern6;
            testPatterns[7] = pattern7;
            testPatterns[8] = pattern8;
            testPatterns[9] = pattern9;

            double[][] expectedOutputs = {  // 50000, 625
                new double[] { 1,0,0,0,0,0,0,0,0,0 },
                new double[] { 0,1,0,0,0,0,0,0,0,0 },
                new double[] { 0,0,1,0,0,0,0,0,0,0 },
                new double[] { 0,0,0,1,0,0,0,0,0,0 },
                new double[] { 0,0,0,0,1,0,0,0,0,0 },
                new double[] { 0,0,0,0,0,1,0,0,0,0 },
                new double[] { 0,0,0,0,0,0,1,0,0,0 },
                new double[] { 0,0,0,0,0,0,0,1,0,0 },
                new double[] { 0,0,0,0,0,0,0,0,1,0 },
                new double[] { 0,0,0,0,0,0,0,0,0,1 },

                /*new double[1] {0.0},
                new double[1] {0.1},
                new double[1] {0.2},
                new double[1] {0.3},
                new double[1] {0.4},
                new double[1] {0.5},
                new double[1] {0.6},
                new double[1] {0.7},
                new double[1] {0.8},
                new double[1] {0.9},*/
            };
            nn.LearningAlg.Learn(testPatterns, expectedOutputs);
            timer.Stop();
            MessageBox.Show("done training.. Time taken " + timer.ElapsedMilliseconds.ToString());
            // All 3 nested loops using TPL 72058
            // Only Matrix Multiplication using TPL 67553
            // No TPL at all 58834, 33715 (once) :)
        }

        private void btnLoadMNIST_Click(object sender, EventArgs e)
        {
            try {
                /* TODO:
                 * Convert the DataPoint array to double[][]
                 * Since DataPoint is byte[], So DataPoint[] is technically
                 * array of array, should be easily converted to double[][]
                 */
                //String trainDir = "..\\..\\..\\..\\..\\..\\handouts\\data\\trainingAll60000";
                String trainDir = "..\\..\\..\\..\\..\\..\\handouts\\data\\train";
                //String testDir = "..\\..\\..\\..\\..\\..\\handouts\\data\\testAll10000";
                Stopwatch sw = new Stopwatch();
                sw.Start();
                double[][] trainData = ImageReader.ReadAllDataScaled(trainDir);
                sw.Stop();
                MessageBox.Show("Time taken to read the trainer data " + sw.ElapsedMilliseconds.ToString());

                int[] layers = { 100, trainData[0].Count() }; // neurons in hidden layer, ouput layer
                nn = new Network(trainData[0].Count(), layers);   // # of inputs
                nn.randomizeAll();
                nn.LearningAlg.ErrorTreshold = 0.0001f;
                nn.LearningAlg.MaxIteration = 10000;

                sw.Restart();
                nn.LearningAlg.Learn(trainData, trainData);
                sw.Stop();
                MessageBox.Show("Done training...Time taken " + sw.ElapsedMilliseconds.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestMNIST_Click(object sender, EventArgs e)
        {
            try {
                if (nn == null)
                {
                    MessageBox.Show("Please train me first!!!");
                    return;
                }

                double[] dtunknown = null;
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    dtunknown = ImageReader.ReadDataPoint(ofd.FileName);
                }

                double[] res = nn.Output(dtunknown);
                string out1 = "";
                int i = 0;
                foreach (double num in res)
                {
                    out1 += i.ToString() + " : " + num.ToString() + "\n";
                    i++;
                }
                MessageBox.Show(out1);
                out1 = "";
                for (i = 0; i < dtunknown.Count(); i++)
                {
                    out1 += nn.Output(testPatterns[i])[i].ToString() + "\n";
                }
                MessageBox.Show(out1);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadPCA_Click(object sender, EventArgs e)
        {
            /*
             * STEPS
             * 1- Convert image to grayscale
             * 2- Convert to 2-D image i.e. conversion to vector
             */
            //String trainDir = "..\\..\\..\\..\\..\\..\\handouts\\data\\trainingAll60000";
            String trainDir = "..\\..\\..\\..\\..\\..\\handouts\\data\\train";
            //String testDir = "..\\..\\..\\..\\..\\..\\handouts\\data\\testAll10000";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[][] trainData = ImageReader.ReadAllData(trainDir);
            sw.Stop();
            MessageBox.Show("Time taken to read the trainer data " + sw.ElapsedMilliseconds.ToString());

            /*
             * STEPS:
             * 3- Compute the mean vector of all test images
             * 4- Subtract mean vector from each image
             * 5- Compute covariant matrix of all test images
             * pass the vector through the PCA
             * then pass that data through NN
             */
            iMean = PCA.FindMean(trainData);
            PCA.SubMean(trainData, iMean);

            double[][] covariance =  PCA.Covariance(trainData);

            /* Compute the eigan values (values are sorted) */
            PCALib.Matrix mapackMatrix = new PCALib.Matrix(covariance);
            PCALib.IEigenvalueDecomposition EigenVal = mapackMatrix.GetEigenvalueDecomposition();

            ///* test code starts */
            //int n = 1001;
            //List<EvalEvac> EVList = new List<EvalEvac>();
            //double[] evcTemp = new double[n];
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //        evcTemp[j] = EigenVal.EigenvectorMatrix[i, j];
            //    EVList.Add(new EvalEvac(EigenVal.RealEigenvalues[i], evcTemp, n));
            //}

            //EVList.Sort();
            ///* test code ends */

            /* select the top 50 Eigen values */
            int top = 50;
#if DEBUG
            /*
             * we don't need the eigen values
             * because the eigen vactors are already
             * calculated by mapack library
             */
            double[] topEigen = new double[top];
            PCA.GetTopN(EigenVal.RealEigenvalues, topEigen, top);
#endif // DEBUG
            /* get Eigen vector */
            double[][] EigenVector = PCA.GetEigenVector(EigenVal.EigenvectorMatrix, top);

            /* multiply eigen vector with vector that has mean substracted */
            double[][] EigenVec = PCA.Transpose(EigenVector, EigenVector[0].Length);
            double[][] basisVector = PCA.Multiply(trainData, EigenVec);
//            double[][] transpose = PCA.Transpose(basisVector, top);

            int[] layers = { 100, trainData[0].Count() }; // neurons in hidden layer, ouput layer
            nn = new Network(trainData[0].Count(), layers);   // # of inputs
            nn.randomizeAll();
            nn.LearningAlg.ErrorTreshold = 0.0001f;
            nn.LearningAlg.MaxIteration = 10000;

            sw.Restart();
            nn.LearningAlg.Learn(trainData, trainData);
            sw.Stop();
            MessageBox.Show("Done training...Time taken " + sw.ElapsedMilliseconds.ToString());
        }

        private void btnTestPCA_Click(object sender, EventArgs e)
        {

        }
    }
}
