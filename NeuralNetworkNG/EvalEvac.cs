using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkNG
{
    class EvalEvac : IComparable, ICloneable
    {
        public double EigenValue;       // Eigen value
        public double[] EigenVec;       // Eigen Vector Array
        public int size;                // Size of Eigen Vector array

        public EvalEvac()
        {
        }

        public EvalEvac(double Ev, double[] Evc, int sz)
        {
            EigenVec = new double[sz];
            EigenValue = Ev;
            size = sz;
            for (int i = 0; i < sz; i++)
                EigenVec[i] = Evc[i];

            // EVecs are already normalized

        }

        public int CompareTo(Object rhs)  // for sorting
        {
            EvalEvac evv = (EvalEvac)rhs;
            return evv.EigenValue.CompareTo(this.EigenValue);  // highest to lowest sorting
        }

        public object Clone()
        {
            EvalEvac clone = new EvalEvac();
            clone.EigenValue = this.EigenValue;
            if (this.EigenVec != null)
                clone.EigenVec = (double[])this.EigenVec.Clone();
            clone.size = this.size;
            return clone;
        }
    }
}
