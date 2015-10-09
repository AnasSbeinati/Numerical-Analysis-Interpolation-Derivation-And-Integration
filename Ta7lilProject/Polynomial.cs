using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ta7lilProject
{
    public class Polynomial
    {
        public double amthal;
        public double power;
        public Polynomial next;

        public static Polynomial insert(double x, double y, Polynomial l)
        {
            Polynomial temp = new Polynomial();
            temp.amthal = x;
            temp.power = y;
            temp.next = null;
            if ((l.next == null) && (l.power == 0) && (l.amthal == 0))
                l = temp;
            else
            {
                Polynomial prv = l;
                if (prv.power < temp.power)
                {
                    temp.next = prv;
                    l = temp;
                }
                else
                {
                    while ((prv.next != null) && (prv.next.power > temp.power))
                        prv = prv.next;
                    if (prv.next == null)
                    {
                        if (prv.power == temp.power)
                            prv.amthal = prv.amthal + temp.amthal;
                        else
                            prv.next = temp;
                    }
                    else
                    {
                        if ((prv.next.power == temp.power))
                            prv.next.amthal = prv.next.amthal + temp.amthal;
                        else if (prv.power == temp.power)
                            prv.amthal = prv.amthal + temp.amthal;
                        else
                        {
                            temp.next = prv.next;
                            prv.next = temp;
                        }
                    }
                }

            }
            return l;
        }
        public static string tostring(Polynomial l)
        {
            Polynomial p = l;
            string temp = "";
            while (p != null)
            {
                if (p.power == 0)
                    if (p.amthal > 0)
                        temp += "+" + p.amthal.ToString();
                    else if (p.amthal == 0)
                        temp += "";
                    else
                        temp += p.amthal.ToString();
                else if ((p.amthal > 0) && (p.power > 0))
                    temp += "+" + p.amthal.ToString() + "X^" + p.power.ToString();
                else if ((p.amthal > 0) && (p.power < 0))
                    temp += "+" + p.amthal.ToString() + "X^" + p.power.ToString();
                else if ((p.amthal < 0) && (p.power != 0))
                    temp += p.amthal.ToString() + "X^" + p.power.ToString();
               
                p = p.next;
            }
            return temp;
        }
        public static Polynomial add(Polynomial n, Polynomial m)
        {
            Polynomial temp = n;
            Polynomial z = new Polynomial();
            while (temp != null)
            {

                double frst = temp.amthal;
                double frstpw = temp.power;
                z = insert(frst, frstpw, z);
                temp = temp.next;
            }
            temp = m;
            while (temp != null)
            {
                double frst = temp.amthal;
                double frstpw = temp.power;
                z = insert(frst, frstpw, z);
                temp = temp.next;
            }
            return z;
        }
        public static Polynomial multi(Polynomial n, Polynomial m)
        {
            Polynomial temp1 = n;
            Polynomial temp2 = m;
            Polynomial q = new Polynomial();
            while (temp1 != null)
            {
                temp2 = m;
                while (temp2 != null)
                {
                    double a = temp1.amthal * temp2.amthal;
                    double wn = temp1.power + temp2.power;
                    q = insert(a, wn, q);
                    temp2 = temp2.next;
                }
                temp1 = temp1.next;
            }
            return q;
        }
        public static Polynomial Derive(Polynomial temp)
        {
            Polynomial l=temp ;
            while((l != null)&&(l.power != 0))
            {
                    l.amthal = l.power*l.amthal;
                    l.power = l.power - 1;
                    l=l.next;
            }
            return temp;
            
        }

    }
}
