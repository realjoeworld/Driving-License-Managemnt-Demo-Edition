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
    public partial class ChangePasswordScreen: Form
    {
        public ChangePasswordScreen(int personID, int userID, string userName, string password, string firstName, string secondName, string thirdName, string lastName, string nationalNo, DateTime dateOfBirth, string gender, string phone, string email, string country, string address, string ImagePath, bool isActive)
        {
            InitializeComponent();
            PersonID = personID;
            UserID = userID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            NationalNo = nationalNo;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Phone = phone;
            Email = email;
            Country = country;
            Address = address;
            IsActive = isActive;
            ctrlShowPersonDetails1.LoadPersonData(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, Country, ImagePath);
            ctrlLoginInfo1.LoadUserData(UserID, UserName, IsActive);

        }

        public int PersonID { get; set; }
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string LastName { get; set; }

        public string NationalNo { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string ImagePath { get; set; }

        public bool IsActive { get; set; }

        private void ctrlLoginInfo1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtboxCurrentPassword.Text != Password)
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtboxPassword.Text != txtboxConfirmPassword.Text)
            {
                MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtboxConfirmPassword.Text == txtboxPassword.Text) {
                if (clsUser.UpdateUserPassword(UserID, txtboxConfirmPassword.Text))
                {

                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Failed to change password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                    
            }

        }

        private void txtboxCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtboxCurrentPassword.Text))
            {
                MessageBox.Show("Current password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxCurrentPassword.Focus();
            }
        }

        private void txtboxPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxPassword.Text))
            {
                MessageBox.Show("New password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxPassword.Focus();
            }
        }

        private void txtboxConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxConfirmPassword.Text))
            {
                MessageBox.Show("New password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxConfirmPassword.Focus();
            }
        }
    }
}
