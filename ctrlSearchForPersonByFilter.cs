using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussniss;

namespace DVLDInterface
{
    public partial class ctrlSearchForPersonByFilter: UserControl
    {
        public ctrlSearchForPersonByFilter()
        {
            InitializeComponent();
        }

        public ctrlSearchForPersonByFilter(int PersonID) : this()
        {
            this.PersonID = PersonID;
            txtboxSearch.Text = PersonID.ToString();
            FilterComboBox.SelectedIndex = 1;
            groupBox1.Enabled = false; // Disable the search box if PersonID is provided
            button1_Click(null, null);
        }

        public bool IsFound = false;

        public int PersonID = 0;

        private void button1_Click(object sender, EventArgs e)
        {


            int ID = 0;
            string FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LastName = string.Empty, NationalNo = string.Empty, Phone = string.Empty, Email = string.Empty, Address = string.Empty, ImagePath = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            string Gender = string.Empty, CountryName = string.Empty;

            if (FilterComboBox.SelectedIndex == 0)
            {
                
                if(clsPerson.GerPersonInfoByNationalO(ref ID,ref FirstName,ref SecondName,ref ThirdName, ref LastName, ref DateOfBirth , txtboxSearch.Text, ref Gender,ref Phone,ref Email,ref CountryName,ref Address,ref ImagePath))
                {
                    
                    PersonID = ID;
                    ctrlShowPersonDetails1.LoadPersonData(ID, FirstName, SecondName, ThirdName, LastName, txtboxSearch.Text, DateOfBirth, Gender, Address, Phone, Email, CountryName, ImagePath);
                    IsFound = true;
                
                }
                
                else
                {
                    MessageBox.Show($"There Is No Person With NO = '{txtboxSearch.Text}' ");
                    IsFound = false;
                }
            
            }

            else if(FilterComboBox.SelectedIndex == 1)
            {

                if (clsPerson.GetPersonInfoByID(Convert.ToInt32(txtboxSearch.Text),ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth, ref Gender,ref Phone, ref Email,ref CountryName,ref Address,ref ImagePath)) {
                    
                    PersonID = Convert.ToInt32(txtboxSearch.Text);
                    ctrlShowPersonDetails1.LoadPersonData(Convert.ToInt32(txtboxSearch.Text), FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, CountryName, ImagePath);
                    IsFound = true;
                
                }
                
                else
                {
                    MessageBox.Show($"There Is No Person With ID = '{txtboxSearch.Text}' ");
                    IsFound = false;

                }

            }
        
        }

        private void txtboxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(FilterComboBox.SelectedIndex == 1)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Block the key
                }
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddNewPerson addNewPersonForm = new AddNewPerson();
            addNewPersonForm.ShowDialog();
        }

        private void ctrlSearchForPersonByFilter_Load(object sender, EventArgs e)
        {
            if (PersonID == 0)
            {
                FilterComboBox.SelectedIndex = 0;
            }
            else
            {
                FilterComboBox.SelectedIndex = 1;
                
            }
        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        public void UnEnabledSearchBox()
        {
            groupBox1.Enabled = false;
          
        }

        public void SetSearchBoxValue(int PersonID)
        {
            txtboxSearch.Text = PersonID.ToString();
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
              
            
        }
    }
}
