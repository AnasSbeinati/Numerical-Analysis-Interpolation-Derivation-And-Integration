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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }
        public int i = 0;
        interpolation form = new interpolation();
        private void interpolation_Click(object sender, EventArgs e)
        {
            if (form.Visible == false)
            {
                try
                {
                    form.Visible = true;
                    if (i > 0)
                        i--;
                }
                catch (System.ObjectDisposedException)
                {
                    i++;

                }
            }
            else
                MessageBox.Show("The Window is already opened ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if ((i > 0) && (form.Visible == false))
            {
                form = new interpolation();
                form.Visible = true;
            }

        }
        Integration formintegration=new Integration();
        public int j = 0;
        private void integration_Click(object sender, EventArgs e)
        {
            if (formintegration.Visible == false)
            {
                try
                {
                    formintegration.Visible = true;
                    if (j > 0)
                        j--;
                }
                catch (System.ObjectDisposedException)
                {
                    j++;

                }
            }
            else
                MessageBox.Show("The Window is already opened ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if ((j > 0) && (formintegration.Visible == false))
            {
                formintegration = new Integration();
                formintegration.Visible = true;
            }

        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
        Deriveation deriveation  = new Deriveation();
        private void Deriveation_Click(object sender, EventArgs e)
        {
 
            if (deriveation.Visible == false)
            {
                try
                {
                    deriveation.Visible = true;
                    if (j > 0)
                        j--;
                }
                catch (System.ObjectDisposedException)
                {
                    j++;

                }
            }
            else
                MessageBox.Show("The Window is already opened ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if ((j > 0) && (deriveation.Visible == false))
            {
                deriveation = new Deriveation();
                deriveation.Visible = true;
            }
        }
    }
}

