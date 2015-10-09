using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ta7lilProject
{
    class deriveationclass
    {
        public static Polynomial Newton (double [] Y ,double h ,int n ,double x0)
        {
            Double[] DalthY =new double[3];
            Double[] Dalth2Y = new double[2];
            double Dalth3Y = 0; 
            for (int i = 0; i < 3; i++)
            {
                DalthY[i] = Y[i + 1] - Y[i];
            }
            for (int i = 0; i < 2; i++)
            {
                Dalth2Y[i] = DalthY[i + 1] - DalthY[i]; 
            }
            Dalth3Y = Dalth2Y[1] - Dalth2Y[0];
            Polynomial first = new Polynomial();
            Polynomial second = new Polynomial();
            Polynomial third= new Polynomial();
            Polynomial p= new Polynomial();
            Polynomial p2= new Polynomial();
            Polynomial temp = new Polynomial();
            Polynomial temp1 = new Polynomial();
            Polynomial temp2 = new Polynomial();
            p = Polynomial.insert(1/h, 1, p);
            p = Polynomial.insert(-1*(x0/h), 0, p);
            p2 = Polynomial.multi(p, p);
            second=Polynomial.insert((2*Dalth2Y[0])/2, 0,second );
            second = Polynomial.multi(second, p);
            second = Polynomial.insert(-1*(Dalth2Y[0]/h), 0, second);
            first = Polynomial.insert(DalthY[0], 0, first);
            third = Polynomial.insert((3*Dalth3Y)/6, 0, third);
            third = Polynomial.multi(p2, third);
            temp = Polynomial.insert(-1*(Dalth3Y), 0, temp);
            temp = Polynomial.multi(temp, p);
            third = Polynomial.add(third, temp);
            temp1 = Polynomial.insert((2*Dalth3Y)/6,0,temp1);
            third = Polynomial.add(third, temp1);
            third = Polynomial.add(third,first);
            third = Polynomial.add(third, second);
            temp2 = Polynomial.insert((1/h), 0, temp2);
            third = Polynomial.multi(third, temp2);
            return third; 

            
        }
         public static Polynomial Newtonsecond (double [] Y ,double h ,int n ,double x0)
         {
            
             Double[] DalthY = new double[3];
             Double[] Dalth2Y = new double[2];
             double Dalth3Y = 0;
             for (int i = 0; i < 3; i++)
             {
                 DalthY[i] = Y[i + 1] - Y[i];
             }
             for (int i = 0; i < 2; i++)
             {
                 Dalth2Y[i] = DalthY[i + 1] - DalthY[i];
             }
             Dalth3Y = Dalth2Y[1] - Dalth2Y[0];
             Polynomial p = new Polynomial();
             Polynomial temp = new Polynomial();
             Polynomial temp1 = new Polynomial();
             Polynomial temp2 = new Polynomial();
             temp = Polynomial.insert(Dalth2Y[0], 0, temp);
             p = Polynomial.insert(1 / h, 1, p);
             p = Polynomial.insert(-1 * (x0 / h), 0, p);
             temp1 = Polynomial.insert(Dalth3Y, 0, temp1);
             temp1 = Polynomial.multi(temp1, p);
             temp1 = Polynomial.insert(-1*Dalth3Y, 0, temp1);
             temp1 = Polynomial.add(temp1, temp);
             h = h * h;
             temp2 = Polynomial.insert((1 / h), 0, temp2);
             temp1 = Polynomial.multi(temp1, temp2);
             return temp1; 
         }
    }
}
