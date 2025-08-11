using DVLDBussniss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLDInterface
{
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {

            comboboxFilter.SelectedIndex = 0;

            this.Size = new Size(1000, 700);
            this.AutoSize = false;
            this.AutoScaleMode = AutoScaleMode.None;
            this.MaximizeBox = false;


            // Header style

            //dataGridView1.EnableHeadersVisualStyles = false;
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            //dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            //// Grid lines and border
            //dataGridView1.GridColor = Color.LightGray;
            //dataGridView1.BorderStyle = BorderStyle.None;
            //dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            //// Cell style
            //dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            //dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            //// Row height
            //dataGridView1.RowTemplate.Height = 30;

            //// Fit columns
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //dataGridView1.DataSource = clsPerson.GetAllPersonsInfo();
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDetails frmPersonDetails = new PersonDetails(Convert.ToInt16(dataGridView1.Rows[IndexRowSelected].Cells["PersonID"].Value),
              Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["FirstName"].Value),
              Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["SecondName"].Value),
               Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["ThirdName"].Value),
               Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["LastName"].Value),
               Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["NationalNo"].Value),
               Convert.ToDateTime(dataGridView1.Rows[IndexRowSelected].Cells["DateOfBirth"].Value),
               Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["Gender"].Value),
               Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["Address"].Value),
               Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["Phone"].Value),
               Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["Email"].Value),
               Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["CountryName"].Value),
               Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["ImagePath"].Value));

            frmPersonDetails.ShowDialog();

        }


        public int IndexRowSelected = 0;
        int IDForSelectedRow = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IndexRowSelected = e.RowIndex;
                IDForSelectedRow = (int)dataGridView1.Rows[IndexRowSelected].Cells["PersonID"].Value;

            }

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddNewPerson frmAddNewPerson = new AddNewPerson();
            frmAddNewPerson.DataBack += RefreshPeople; // Subscribe to the DataBack event
            frmAddNewPerson.ShowDialog();
        }

        private void comboboxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxFilter.SelectedIndex == 0)
            {
                
                txtBoxFilter.Visible = false;
                dataGridView1.DataSource = clsPerson.GetAllPersonsInfo();
            }
            else if(comboboxFilter.SelectedIndex == 8)
            {
                if (txtBoxFilter.Items.Count > 0)
                {
                    txtBoxFilter.Items.Clear();
                }
                txtBoxFilter.Items.Add("Male");
                txtBoxFilter.Items.Add("Female");
                txtBoxFilter.SelectedIndex = 0;
                txtBoxFilter.DropDownStyle = ComboBoxStyle.DropDownList; // Set to DropDownList to prevent text input
                txtBoxFilter.Visible = true;
            }
            else
            {
                if (txtBoxFilter.Items.Count > 0)
                {
                    txtBoxFilter.Items.Clear();
                }
                txtBoxFilter.Visible = true;
                txtBoxFilter.DropDownStyle = ComboBoxStyle.Simple; // Set to DropDownList to prevent text input
                txtBoxFilter.Text = string.Empty; // Clear the text box when a filter is selected
            }
        }

        public void refreshDataGridView()
        {
            dataGridView1.DataSource = clsPerson.GetAllPersonsInfo();
        }

        private void txtBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (comboboxFilter.SelectedIndex == 0)
            {
               
                dataGridView1.DataSource = clsPerson.GetAllPersonsInfo();
            }
            else if (comboboxFilter.SelectedIndex == 1)
            {
             
                dataGridView1.DataSource = clsPerson.GetAllPersonsPersonIDStartWith(txtBoxFilter.Text);
            }
            else if (comboboxFilter.SelectedIndex == 2)
            {
            
                dataGridView1.DataSource = clsPerson.GetAllPersonsFirstNameStartWith(txtBoxFilter.Text);
            }
            else if (comboboxFilter.SelectedIndex == 3)
            {
                
                dataGridView1.DataSource = clsPerson.GetAllPersonsSecondNameStartWith(txtBoxFilter.Text);
            }
            else if (comboboxFilter.SelectedIndex == 4)
            {
              
                dataGridView1.DataSource = clsPerson.GetAllPersonsThirdNameStartWith(txtBoxFilter.Text);
            }
            else if (comboboxFilter.SelectedIndex == 5)
            {
                
                dataGridView1.DataSource = clsPerson.GetAllPersonsLastNameStartWith(txtBoxFilter.Text);
            }
            else if (comboboxFilter.SelectedIndex == 6)
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsNationalNoStartWith(txtBoxFilter.Text);
            }
            else if (comboboxFilter.SelectedIndex == 7)
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsCountryNaemStartWith(txtBoxFilter.Text);
            }

            //else if (comboboxFilter.SelectedIndex == 8)
            //{

              
            //}
            
            else if (comboboxFilter.SelectedIndex == 9)
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsWithPhoneStartWith((txtBoxFilter.Text));
            }

            else if(comboboxFilter.SelectedIndex == 10)
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsWithEmailStartWith(txtBoxFilter.Text);
            }

            else
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsInfo();
            }
        }

        private void txtBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboboxFilter.SelectedIndex == 1 || comboboxFilter.SelectedIndex == 9)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Block anything else
                }

            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewPerson frmAddNewPerson = new AddNewPerson();

            frmAddNewPerson.DataBack += RefreshPeople; ; // Subscribe to the DataBack event

            frmAddNewPerson.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LastName = string.Empty, NationalNO = string.Empty, Gender = string.Empty, Address = string.Empty, Phone = string.Empty, Email = string.Empty, ImagePath = string.Empty, CountryName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = 0;

            if (clsPerson.GetPersonInfoByID(IDForSelectedRow, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath))
            {

              

            int GenderType = 0;
            if (Gender == "FeMale")
                GenderType = 1;

              CountryID = clsCountry.GetCountryIndexByName(CountryName);

              UpdatePerson frmUpdatePerson = new UpdatePerson(IDForSelectedRow, FirstName, SecondName, ThirdName, LastName, NationalNO, DateOfBirth, GenderType, Phone, Email, CountryID, Address, ImagePath);
              frmUpdatePerson.DataBack += RefreshPeople; // Subscribe to the DataBack event
              frmUpdatePerson.ShowDialog();

            }

      }



        




        public void RefreshPeople()
        {
            dataGridView1.DataSource = clsPerson.GetAllPersonsInfo();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Do Want To Delete This Person ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                int PersonID = Convert.ToInt16(dataGridView1.Rows[IndexRowSelected].Cells["PersonID"].Value);

                if (clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPeople();
                }
                else
                {
                    MessageBox.Show("Failed to delete person, this Person Is Connected With Entities In The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void txtBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtBoxFilter.SelectedIndex == 0)
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsWithMaleGender();
            }
            else if (txtBoxFilter.SelectedIndex == 1)
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsWithFeMaleGender();
            }
            else
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsInfo();
            }
        }

        private void txtBoxFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (txtBoxFilter.SelectedIndex == 0)
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsWithMaleGender();
            }
            else if (txtBoxFilter.SelectedIndex == 1)
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsWithFeMaleGender();
            }
            else
            {
                dataGridView1.DataSource = clsPerson.GetAllPersonsInfo();
            }
        }


    }
}
