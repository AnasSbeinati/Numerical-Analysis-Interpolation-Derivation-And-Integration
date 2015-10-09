using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ta7lilProject
{
    class IntegrationClass
    {
        public static double Simpson(double[] y, int node, double h)
        {
            double[] auxarray;
            auxarray = new double[node + 1];
            double sum = 0;
            for (int j = 1; j < node-1; j++)
            {
                if (j%2 == 0)
                    auxarray[j] = 2*y[j];
                else
                    auxarray[j] = 4*y[j];
                sum = sum + auxarray[j];
            }
            return ((h/3)*(sum + y[0] + y[node-1]  ));
        }
        public static double Trapezoidal(double[] y, int node, double h)
        {
            double integration = 0;
            h = h/2; 
            for (int i = 0; i <= node; i++)
            {
                if ((i==0)|| (i==node))
                {
                    integration = integration + y[i];
                }
                else
                {
                    integration = integration + 2*y[i];
                }
            }
            integration = integration*h;
            return integration; 
        }
        public static double oblong(double[] y,int BeginNode ,int node, double h)
        {
            double integration = 0; 
            for (int i = BeginNode; i < node; i++)
            {
                integration = integration + y[i];
            }
            integration = integration * h;
            return integration; 
        }
    }
}
