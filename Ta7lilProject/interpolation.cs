using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ta7lilProject
{
    public partial class interpolation : Form
    {
        public interpolation()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }
        public double[] CreatXarray(ref  bool ThereIsErrorX)
        {
            int i = 0;
            int j = 0;
            double[] xcolum = new double[NumOfNode];
            ThereIsErrorX = false;
            while ((i < NumOfNode) && (ThereIsErrorX == false))
            {
                double CurrentCellDouble = 0;

                string CurrentCell = "";
                try
                {
                    CurrentCell = Convert.ToString(dataGridView1[j, i].Value.ToString());
                }
                catch (NullReferenceException)
                {
                    ThereIsErrorX = true;
                }
                if ((ThereIsErrorX != true) && (Share.Isnumber(CurrentCell) == true))
                {

                    CurrentCellDouble = double.Parse(CurrentCell);
                    xcolum[i] = CurrentCellDouble;
                }
                else
                    ThereIsErrorX = true;
                i++;
            }
            if (ThereIsErrorX == true)
                MessageBox.Show("Entry Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return xcolum;
        }
        public double[] CreatYarray(ref  bool ThereIsErrorY)
        {
            int i = 0;
            int j = 1;
            ThereIsErrorY = false;
            double[] ycolum = new double[NumOfNode];
            while ((i < NumOfNode) && (ThereIsErrorY == false))
            {
                double CurrentCellDouble = 0;

                string CurrentCell = "";
                try
                {
                    CurrentCell = Convert.ToString(dataGridView1[j, i].Value.ToString());
                }
                catch (NullReferenceException)
                {
                    ThereIsErrorY = true;
                }
                if ((ThereIsErrorY != true) && (Share.Isnumber(CurrentCell) == true))
                {

                    CurrentCellDouble = double.Parse(CurrentCell);
                    ycolum[i] = CurrentCellDouble;
                }
                else
                    ThereIsErrorY = true;
                i++;
            }
            if (ThereIsErrorY == true)
                MessageBox.Show("Entry Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return ycolum;
        }
        private void Enter_Click(object sender, EventArgs e)
        {
            if (Share.PositiveInteger(textBox1.Text))
            {
                NumOfNode = Convert.ToInt16(textBox1.Text);
                dataGridView1.Visible = true;
                comboBox1.Visible = true;
                Send.Visible = true;
                Enter.Visible = false;
                dataGridView1.RowCount = NumOfNode;
                label2.Visible = true;
            }
            else
                MessageBox.Show("Error Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void interpolation_Load(object sender, EventArgs e)
        {

        }

        private void Send_Click(object sender, EventArgs e)
        {
            bool XarrayZero = false;
            bool YarrayZero = false;
            string Method = comboBox1.Text;
            string[] allMethod = { "General Methode", "Spline", "Lagrange", "Newton", "Least Square Method" };
            if (Method != ".......")
            {
                xcolum = CreatXarray(ref ThereIsErrorX);
                XarrayZero = Share.IfallZero(xcolum);
                if (XarrayZero != true)
                    ycolum = CreatYarray(ref ThereIsErrorY);
                YarrayZero = Share.IfallZero(ycolum);
                string AnyOfMethod = Array.Find(allMethod, s => s.Equals(Method));
                if ((XarrayZero != true) && (YarrayZero != true) && (ThereIsErrorX != true) && (ThereIsErrorY != true))
                    if ((Method == AnyOfMethod))
                        comboBox1.Enabled = false;
                    else
                        MessageBox.Show("This Is Not Method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XarrayZero = Share.IfallZero(xcolum);
            YarrayZero = Share.IfallZero(ycolum);
            switch (Method)
            {
                case "General Methode":
                    {

                        if ((XarrayZero != true) && (YarrayZero != true) && (ThereIsErrorX != true) && (ThereIsErrorY != true))
                        {
                            #region General Methode

                            double[,] matrx;
                            matrx = new double[NumOfNode, NumOfNode];
                            matrx = InterpolationClass.CreatVandrmondmatrix(NumOfNode, xcolum);
                            double determatrx = InterpolationClass.determine(matrx);
                            double[,] another = new double[NumOfNode, NumOfNode];
                            Polynomial temp = new Polynomial();
                            double[] Constant;
                            Constant = new double[NumOfNode];
                            for (int j = 0; j < NumOfNode; j++)
                            {
                                another = InterpolationClass.creatanothermatrix(j, xcolum, ycolum, NumOfNode);
                                double deternother = InterpolationClass.determine(another);
                                Constant[j] = deternother / determatrx;

                            }
                            for (int i = 0; i < Constant.Length; i++)
                            {

                                temp = Polynomial.insert(Constant[i], i, temp);

                            }
                            string result = Polynomial.tostring(temp);


                            if (MessageBox.Show("If You Have An Internet Connection Click Yes To Show The Function On Net Or Click No To See It Here", "Internet Connection",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                    DialogResult.Yes)
                            {
                                string url = "http://texify.com/?" + result;
                                Process.Start(url);
                            }
                            else
                            {
                                label3.Visible = true;
                                richTextBox1.Visible = true;
                                richTextBox1.Text = result;
                            }

                            Send.Enabled = false;
                            Refresh.Visible = true;

                            #endregion
                        }
                    }
                    break;
                case "Least Square Method":
                    {

                        if ((XarrayZero != true) && (YarrayZero != true) && (ThereIsErrorX != true) && (ThereIsErrorY != true))
                        {
                            #region Least Square Method
                            int exp = NumOfNode - 1;
                            double sum;
                            double[] tableX = new double[2 * exp];
                            double[] tableY = new double[NumOfNode];
                            for (int j = 0; j < (2 * exp); j++)
                            {
                                sum = 0;
                                for (int i = 0; i < NumOfNode; i++)
                                {
                                    sum = sum + Math.Pow(xcolum[i], j + 1);
                                    tableX[j] = sum;
                                }
                            }
                            for (int j = 0; j < NumOfNode; j++)
                            {
                                sum = 0;
                                for (int i = 0; i < NumOfNode; i++)
                                {
                                    if (j == 0)
                                    {
                                        sum = sum + ycolum[i];
                                    }
                                    else
                                    {
                                        sum = sum + (Math.Pow(xcolum[i], j) * ycolum[i]);
                                    }
                                    tableY[j] = sum;
                                }
                            }
                            double[,] squer = new double[NumOfNode, NumOfNode];
                            squer[0, 0] = NumOfNode;
                            for (int i = 1; i < NumOfNode; i++)
                            {
                                squer[0, i] = tableX[i - 1];
                            }
                            for (int i = 1; i < NumOfNode; i++)
                            {
                                for (int j = 0; j < NumOfNode; j++)
                                    squer[i, j] = tableX[i + j - 1];
                            }
                            double[] A = new double[NumOfNode];
                            double d = InterpolationClass.determine((double[,])squer.Clone());
                            for (int j = 0; j < NumOfNode; j++)
                                A[j] = InterpolationClass.ChangeXY((double[,])squer.Clone(), tableY, j, NumOfNode) / d;
                            Send.Enabled = false;
                            Refresh.Visible = true;

                            #endregion
                        }
                    }
                    break;
                case "Lagrange":
                    {
                        if ((XarrayZero != true) && (YarrayZero != true) && (ThereIsErrorX != true) && (ThereIsErrorY != true))
                        {
                            #region Lagrange

                            {
                                string result = InterpolationClass.lagrang(xcolum, NumOfNode, ycolum);
                                if (MessageBox.Show("If You Have An Internet Connection Click Yes To Show The Function On Net Or Click No To See It Here", "Internet Connection",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                    DialogResult.Yes)
                                {
                                    string url = "http://texify.com/?" + result;
                                    Process.Start(url);
                                }
                                else
                                {
                                    label3.Visible = true;
                                    richTextBox1.Visible = true;
                                    richTextBox1.Text = result;
                                }
                            }

                            #endregion
                        }

                    }
                    break;
                case "Spline":
                    {
                        if ((XarrayZero != true) && (YarrayZero != true) && (ThereIsErrorX != true) && (ThereIsErrorY != true))
                        {
                            #region Splin
                            {
                                double point = 0;
                                if ((textBox2.Text != null) && (Share.Isnumber(textBox2.Text)))
                                {
                                    point = double.Parse(textBox2.Text);
                                    string result = Polynomial.tostring(InterpolationClass.Splin(xcolum, ycolum, NumOfNode, point));
                                    if (MessageBox.Show("If You Have An Internet Connection Click Yes To Show The Function On Net Or Click No To See It Here", "Internet Connection",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                   DialogResult.Yes)
                                    {
                                        string url = "http://texify.com/?" + result;
                                        Process.Start(url);
                                    }
                                    else
                                    {
                                        label3.Visible = true;
                                        richTextBox1.Visible = true;
                                        richTextBox1.Text = result;
                                    }

                                }
                                else
                                    MessageBox.Show("Error Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            }
                            #endregion
                        }
                    }
                    break;
                case "Newton":
                    {
                        if ((XarrayZero != true) && (YarrayZero != true) && (ThereIsErrorX != true) && (ThereIsErrorY != true))
                        {
                            #region Newton
                            double[,] Temp = InterpolationClass.newtonftab(xcolum, ycolum, NumOfNode);
                            Polynomial Newton = InterpolationClass.newtonemethod(xcolum, ycolum, Temp, NumOfNode);
                            string result = Polynomial.tostring(Newton);
                            if (MessageBox.Show("If You Have An Internet Connection Click Yes To Show The Function On Net Or Click No To See It Here", "Internet Connection",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                  DialogResult.Yes)
                            {
                                string url = "http://texify.com/?" + result;
                                Process.Start(url);
                            }
                            else
                            {
                                label3.Visible = true;
                                richTextBox1.Visible = true;
                                richTextBox1.Text = result;
                            }

                            #endregion
                        }
                    }
                    break;
                default:
                    {
                        if (Method == ".......")
                            MessageBox.Show("No Method Is Selceted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == comboBox1.Items[1].ToString())
            {
                label4.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox2.Visible = false;
            }
        }
    }
}
