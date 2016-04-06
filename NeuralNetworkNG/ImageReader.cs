using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadMNIST
{
    class ImageReader
    {
        //For the MNIST data set 
        public static DataPoint[] ReadAllData(String directory)
        {
            object olock = new object();
            int fileNum = 0;
            int dataIndex = 0;
            DirectoryInfo diR = new DirectoryInfo(directory);

            //count the file number 
            foreach (FileInfo fi in diR.GetFiles())
            {
                fileNum++;
            }
            DataPoint[] dataArray = new DataPoint[fileNum];
            //count the file number 
            //foreach (FileInfo fi in diR.GetFiles())
            FileInfo[] files = diR.GetFiles();
            //for (int counter = 0; counter < fileNum; ++ counter)
            Parallel.For(0, fileNum, counter =>
            {
                String fname = files[counter].FullName;
                Bitmap bmp = new Bitmap(Image.FromFile(fname));
                byte[,] ImgPixelData = new byte[bmp.Width, bmp.Height];
                if (ImageProc.IsGrayScale(bmp) == false) //make sure it is grayscale 
                {
                    ImageProc.ConvertToGray(bmp);
                }
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        ImgPixelData[i, j] = bmp.GetPixel(i, j).R;
                    }
                }

                //convert to 1D
                int totalPixels = bmp.Width * bmp.Height;
                int tempIndex = 0;
                byte[] pointData = new byte[totalPixels];

                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        pointData[tempIndex] = ImgPixelData[i, j]; //convert to 0 to 1 scale 
                        tempIndex++;
                    }
                }

                //String s1 = fi.Name;
                //Char output = s1[0];
                Char output = files[counter].Name[0];
                int classLabel = (Convert.ToInt16(output) - 48); //will only work with numbers 0-9
                lock (olock)
                    dataArray[dataIndex++] = new DataPoint(classLabel, totalPixels, pointData);
               // dataArray[dataIndex].Bmp = bmp;
                //dataIndex++;
                if ((dataIndex % 500) == 0)
                    Console.WriteLine("iter: " + dataIndex);
            });
            return dataArray;
        }

        public static DataPoint ReadDataPoint(String fname)  // fname is full file name
        {
            Bitmap bmp = new Bitmap(Image.FromFile(fname));
            byte[,] ImgPixelData = new byte[bmp.Width, bmp.Height];
            if (ImageProc.IsGrayScale(bmp) == false) //make sure it is grayscale 
            {
                ImageProc.ConvertToGray(bmp);
            }
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    ImgPixelData[i, j] = bmp.GetPixel(i, j).R;
                }
            }

            //convert to 1D
            int totalPixels = bmp.Width * bmp.Height;
            int tempIndex = 0;
            byte[] pointData = new byte[totalPixels];

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    pointData[tempIndex] = ImgPixelData[i, j]; //convert to 0 to 1 scale 
                    tempIndex++;
                }
            }
            char[] seps = { '\\' };
            string[] parts = fname.Split(seps);
            int classLabel = parts[parts.Length - 1][0]-48;
            DataPoint dt = new DataPoint(classLabel, totalPixels, pointData);
            return dt;
        }
    }
}
