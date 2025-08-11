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
    public partial class AddNewUserScreen: Form
    {
        public AddNewUserScreen()
        {
            InitializeComponent();
        }


        public delegate void DataBackEventHandler();
        public event DataBackEventHandler DataBack;

        bool IsFound = false;

        private void button1_Click(object sender, EventArgs e)
        {

            string FirstName = string.Empty,
                   SecondName = string.Empty,
                   ThirdName = string.Empty,
                   LastName = string.Empty,
                   NationalNo = txtboxNationalNo.Text,
                   Address = string.Empty,
                   Phone = string.Empty,
                   Email = string.Empty,
                   ImagePath = string.Empty;

            int CountryID = 0, PersonID = 0, Gender = 0;
            DateTime DateOfBirth = DateTime.Now;

            string GenderinString = string.Empty, CountryName1 = string.Empty;


            if (comboBox1.SelectedIndex == 0 && !string.IsNullOrWhiteSpace(txtboxNationalNo.Text))
            {
                if (clsPerson.GetPersonInfoByNationalNo(ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryID, ref Address, ref ImagePath))
                {

                    string CountryName = clsCountry.GetCountryNameByIndex(CountryID);

                    string GenderString = "Male";

                    if (Gender == 1)
                        GenderString = "FeMale";

                    ctrlShowPersonDetails1.LoadPersonData(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, GenderString, Address, Phone, Email, CountryName, ImagePath);
                }
                else
                {
                    MessageBox.Show("Person not found with the provided National Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(comboBox1.SelectedIndex == 1 && !string.IsNullOrWhiteSpace(txtboxNationalNo.Text))
            {
                if (clsPerson.GetPersonInfoByID(Convert.ToInt16(txtboxNationalNo.Text), ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth, ref GenderinString, ref Phone, ref Email, ref CountryName1, ref Address, ref ImagePath))
                {

                  PersonID = Convert.ToInt16(txtboxNationalNo.Text);



                    ctrlShowPersonDetails1.LoadPersonData(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, GenderinString, Address, Phone, Email, CountryName1, ImagePath);
                }
                else
                {
                    MessageBox.Show("Person not found with the provided Person ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
          

        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxNationalNo.Text))
            {
                if (comboBox1.SelectedIndex == 0)
                    MessageBox.Show("Please enter National Number to proceed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Please enter Person ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                IsFound = false;
                tabControl1.SelectedTab = tabControl1.TabPages[0];
                return;
            }

            if (comboBox1.SelectedIndex == 0)
            {
                if (!clsPerson.CheckIfNationalNumberExists(txtboxNationalNo.Text))
                {
                    MessageBox.Show("National Number does not exist. Please check the number and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IsFound = false;
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    return;
                }
              

                if(clsPerson.CheckIfThisPersonIsUser(ctrlShowPersonDetails1.ID))
                {
                    MessageBox.Show("This person is already a user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    IsFound = false;
                    return;
                }
          
            }

            else if(comboBox1.SelectedIndex == 1)
            {
                if (clsPerson.CheckIfThisPersonIsUser(ctrlShowPersonDetails1.ID))
                {
                    MessageBox.Show("This person is already a user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    IsFound = false;
                    return;
                }
            }

                IsFound = true;
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                IsFound = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtboxUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtboxUserName.Text))
            {
                MessageBox.Show("Please enter a username.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedIndex = 1;
                txtboxUserName.Focus();
            }
        }

        private void txtboxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxPassword.Text))
            {
                MessageBox.Show("Please enter a Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedIndex = 1;
                txtboxPassword.Focus();
            }
        }

        private void txtboxPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxPasswordConfirm.Text))
            {
                MessageBox.Show("Please enter a Password Confirm.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedIndex = 1;
                txtboxPasswordConfirm.Focus();
                return;
            }

            if(txtboxPassword.Text != txtboxPasswordConfirm.Text)
            {
                MessageBox.Show("Password and Password Confirm do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxPasswordConfirm.Focus();
                return;
            }


        }

        private void LoginInfo_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                if (IsFound)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                    MessageBox.Show("Please fill in the user details to proceed, You Cant Go Back To The First Page", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            //else
            //{
            //    MessageBox.Show("Please search for a person first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tabControl1.SelectedTab = tabControl1.TabPages[0];
            //}

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtboxUserName.Text) && !string.IsNullOrEmpty(txtboxPassword.Text) && !string.IsNullOrEmpty(txtboxPassword.Text))
            {
                if(txtboxPassword.Text == txtboxPasswordConfirm.Text)
                {
                    int ID = -1;


                    bool IsActive = chkIsActive.Checked;

                    if (!clsUser.CheckIfUserNameAlreadyExist(txtboxUserName.Text))
                    {

                        if ((ID = clsUser.AddNewUser(ctrlShowPersonDetails1.ID, txtboxUserName.Text, txtboxPassword.Text, IsActive)) != -1)
                        {
                            lblUserID.Text = ID.ToString();
                            MessageBox.Show($"User added successfully, New User ID: {ID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSave.Enabled = false;
                            DataBack?.Invoke();

                        }
                        else
                        {
                            MessageBox.Show("Failed to add user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewPerson frmAddNewPerson = new AddNewPerson();
            frmAddNewPerson.ShowDialog();
        }

        private void AddNewUserScreen_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            btnSave.Enabled = true;
        }

        private void txtboxNationalNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(!IsFound)
              e.Cancel = true; // Prevent user from selecting any tab
        
        }

    }
}

