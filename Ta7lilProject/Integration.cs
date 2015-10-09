using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ta7lilProject
{
    public partial class Integration : Form
    {
        public Integration()
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
            //if (ThereIsErrorX == true)
            //    MessageBox.Show("Entry Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //if (ThereIsErrorY == true)
            //    MessageBox.Show("Entry Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return ycolum;
        }
        private void Send_Click(object sender, EventArgs e)
        {
            string Method = comboBox1.Text;
            string[] allMethod = { "Simpson", "Trapezoidal", "Oblong" };
            string AnyOfMethod = Array.Find(allMethod, s => s.Equals(Method));
            if ((Method != AnyOfMethod))
            {
                MessageBox.Show("This Is Not Method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool XarrayZero = false;
                bool YarrayZero = false;
                xcolum = CreatXarray(ref ThereIsErrorX);
                ycolum = CreatYarray(ref ThereIsErrorY);
                XarrayZero = Share.IfallZero(xcolum);
                YarrayZero = Share.IfallZero(ycolum);
                if ((ThereIsErrorX != true) && (ThereIsErrorY != true) &&(XarrayZero != true)&&(YarrayZero != true))
                {
                    switch (Method)
                    {
                        case "Simpson":
                            {
                                #region Simpson

                                if (((NumOfNode / 2) != 0))
                                {
                                    Result.Visible = true;
                                    label3.Visible = true;
                                    double result = IntegrationClass.Simpson(ycolum, NumOfNode,
                                                                             xcolum[1] - xcolum[0]);
                                    Result.Text = String.Format("{0:0.00000}", result);
                                }
                                else
                                {
                                    Result.Visible = true;
                                    label3.Visible = true;
                                    double result = IntegrationClass.Simpson(ycolum, NumOfNode - 1,
                                                                             xcolum[1] - xcolum[0]);
                                    double result1 = IntegrationClass.oblong(ycolum, NumOfNode - 1, NumOfNode,
                                                                             xcolum[1] - xcolum[0]);
                                    Result.Text = String.Format("{0:0.00000}", result + result1);
                                }

                                #endregion
                            }
                            break;
                        case "Oblong":
                            {
                                #region Oblong
                                Result.Visible = true;
                                label3.Visible = true;
                                double result = IntegrationClass.oblong(ycolum, 0, NumOfNode - 1,
                                                                        xcolum[1] - xcolum[0]);
                                Result.Text = String.Format("{0:0.00000}", result);
                                #endregion
                            }
                            break;
                        case "Trapezoidal":
                            {
                                #region Trapezoidal

                                Result.Visible = true;
                                label3.Visible = true;
                                double result = IntegrationClass.Trapezoidal(ycolum, NumOfNode - 1,
                                                                             xcolum[1] - xcolum[0]);
                                Result.Text = String.Format("{0:0.00000}", result);
                                #endregion
                            }
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Entry Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

      
           
  
            
            

        }

        private void Integration_Load(object sender, EventArgs e)
        {

        }
    }
}
