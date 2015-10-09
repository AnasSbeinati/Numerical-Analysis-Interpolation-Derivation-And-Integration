using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ta7lilProject
{
    class InterpolationClass
    {
        public static double[,] CreatVandrmondmatrix(int h, double[] x)
        {
            double[,] mat;
            mat = new double[h, h];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (j == 0)
                        mat[i, j] = 1;
                    else
                        mat[i, j] = Math.Pow(x[i], j);
                }
            }
            return mat;
        }
        public static double[,] creatanothermatrix(int h, double[] x, double[] y, int dimension)
        {
            double[,] array;
            array = new double[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (j == h)
                        array[i, j] = y[i];
                    else
                        array[i, j] = Math.Pow(x[i], j);

                }
            }
            return array;
        }
        public static void swap(ref double[,] array, int j)
        {
            for (int s = 0; s < array.Length; s++)
                array[j, s] = array[j + 1, s] + array[j, s];
            for (int s = 0; s < array.Length; s++)
                array[j + 1, s] = array[j, s] - array[j + 1, s];
            for (int s = 0; s < array.Length; s++)
                array[j, s] = array[j, s] - array[j + 1, s];

        }
        public static double determine(double[,] array)
        {
            bool boolean = false;
            int t = -1;
            double sum = 1;
            double rootoflength = Math.Sqrt(array.Length);
            int truelength = array.Length / Convert.ToInt16(rootoflength);
            int p = 0;
            for (int j = 0; j < truelength - 1; j++)
            {
                for (int i = j; i < truelength - 1; i++)
                {
                    int l = 0;
                    boolean = false;
                    while ((array[j, j] == 0) && (l < truelength - 1))
                    {
                        swap(ref array, j);
                        p++;
                        l++;
                    }
                    if (l == truelength - 1)
                        boolean = true;
                    if (boolean == false)
                    {
                        double s = array[i + 1, j] / array[j, j];
                        for (int m = 0; m < truelength; m++)
                            array[i + 1, m] = -s * array[j, m] + array[i + 1, m];

                    }

                }
            }
            for (int k = 0; k < truelength; k++)
                sum = sum * array[k, k];
            for (int k = 0; k < p; k++)
                sum = sum * t;
            return sum;
        }
        public static double ChangeXY(double[,] array, double[] table, int j, int n)
        {
            for (int i = 0; i < n; i++)
            {
                array[j, i] = table[i];
            }
            return determine(array);
        }
        public static string lagrang(double[] x, int node, double[] y)
        {
            Polynomial temp = new Polynomial();
            Polynomial onepoly = new Polynomial();


            bool loop = false;

            for (int i = 0; i < node; i++)
            {

                for (int j = 0; j < node; j++)
                {
                    loop = false;
                    if (i != j)
                    {
                        loop = true;
                        temp = new Polynomial();
                        double amthallagrang = x[i] - x[j];
                        temp = Polynomial.insert(y[i] * amthallagrang, 1, temp);
                        temp = Polynomial.insert(y[i] * amthallagrang * -x[j], 0, temp);

                    }
                    if (loop)
                        onepoly = Polynomial.add(temp, onepoly);
                }

            }
            return Polynomial.tostring(onepoly);
        }
        public static Polynomial Splin(double []x,double []y,int node,double point)
        {
            Polynomial temp=new Polynomial();
           
            int c = 0;
            for (int i = 0; i < node - 1; i++)
            {
                if ((x[i] <= point) && (x[i + 1] >= point))
                {
                    c = i;
                    break;
                }
            }
            double constant = (y[c + 1] - y[c])/(x[c + 1] - x[c]);
            temp = Polynomial.insert(constant, 1, temp);
            temp = Polynomial.insert(-1*constant*x[c], 0, temp);
            temp = Polynomial.insert(y[c], 0, temp);
            return temp;

        }
        public static double[,] newtonftab(double[] x, double[] y, int n)
        {
            double[,] mat;
            mat = new double[n, n];
            for (int i = 0; i < n - 1; i++)
            {
                mat[i, 1] = (y[i + 1] - y[i]) / (x[i + 1] - x[i]);
            }
            int i1, j;
            j = 2;
            while (j < n)
            {
                i1 = 0;
                while (i1 < n - j)
                {
                    mat[i1, j] = (mat[i1 + 1, j - 1] - mat[i1, j - 1]) / (x[i1 + j] - x[i1]);
                    i1++;
                }
                j++;
            }
            return mat;
        }
        public static Polynomial newtonemethod(double[] x, double[] y, double[,] tab, int n)
        {
            Polynomial temp = new Polynomial();
            Polynomial temp1 = new Polynomial();
            Polynomial temp2 = new Polynomial();
            Polynomial temp3 = new Polynomial();
            temp = Polynomial.insert(y[0], .0, temp);
            for (int i = 1; i < n; i++)
            {
                temp1 = new Polynomial();
                temp1 = Polynomial.insert(1.0, .0, temp1);
                temp3 = new Polynomial();
                temp3 = Polynomial.insert(tab[0, i], .0, temp3);
                for (int j = 0; j < i; j++)
                {
                    temp2 = new Polynomial();
                    temp2 = Polynomial.insert(1.0, 1.0, temp2);
                    temp2 = Polynomial.insert(-1.0 * x[j], .0, temp2);
                    temp1 = Polynomial.multi(temp2, temp1);
                }
                temp3 = Polynomial.multi(temp1, temp3);
                temp = Polynomial.add(temp, temp3);
            }
            return temp;
        }

    }
}
