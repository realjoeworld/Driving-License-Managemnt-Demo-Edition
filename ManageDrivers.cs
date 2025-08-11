using DVLDBussniss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDInterface
{
    public partial class ManageDrivers: Form
    {
        public ManageDrivers()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ManageDrivers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsDriver.GetAllDrivers();
            comboBox1.SelectedIndex = 0; // Default to All Drivers
        }

        private void txtboxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            
         
           


        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
           

            if (comboBox1.SelectedIndex == 1)
            {
               
                dataGridView1.DataSource = clsDriver.GetAllDriversWhereDriverIDStartWith(txtboxSearch.Text);
            }

            else if (comboBox1.SelectedIndex == 2)
            {
              
                dataGridView1.DataSource = clsDriver.GetAllDriversWherePersonIDStartWith(txtboxSearch.Text);
            }
            else if(comboBox1.SelectedIndex == 3)
            {
                dataGridView1.DataSource = clsDriver.GetAllDriversWhereFullNameStartWith(txtboxSearch.Text);
            }

        }

        private void txtboxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Block anything else
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != 0)
            {
                txtboxSearch.Visible = true;
            }
            else
            {
                txtboxSearch.Visible = false;
                txtboxSearch.Text = "";
                dataGridView1.DataSource = clsDriver.GetAllDrivers();
            }

        }
    }
}
