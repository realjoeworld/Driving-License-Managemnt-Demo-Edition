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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace DVLDInterface
{
    public partial class UpdateUser : Form
    {

        public delegate void DataBackEventHandler();

        public event DataBackEventHandler DataBack;

        public UpdateUser(int personID, int userID, string userName, string password, string firstName, string secondName, string thirdName, string lastName, string nationalNo, DateTime dateOfBirth, string gender, string phone, string email, string country, string address, string ImagePath, bool isActive)
        {
            InitializeComponent();
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.NationalNo = nationalNo;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Phone = phone;
            this.Email = email;
            this.Country = country;
            this.Address = address;
            this.ImagePath = ImagePath;
            this.IsActive = isActive;

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

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            txtboxSearch.Text = PersonID.ToString();
            groupBox1.Enabled = false;
            lblUserID.Text = UserID.ToString();
            txtboxUserName.Text = UserName;
            txtboxPassword.Text = Password;
            txtboxPasswordConfirm.Text = Password;
            ctrlShowPersonDetails1.LoadPersonData(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, Country, ImagePath);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtboxUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxUserName.Text))
            {
                MessageBox.Show("Please enter a username.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxUserName.Focus();
            }
        }

        private void txtboxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxPassword.Text))
            {
                MessageBox.Show("Please enter a Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxPassword.Focus();
            }
        }

        private void txtboxPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxPasswordConfirm.Text))
            {
                MessageBox.Show("Please enter a Confirm Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxPasswordConfirm.Focus();
                return;
            }

            if (txtboxPassword.Text != txtboxPasswordConfirm.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxPasswordConfirm.Focus();
                return;
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtboxUserName.Text) && !string.IsNullOrEmpty(txtboxPassword.Text) && !string.IsNullOrEmpty(txtboxPasswordConfirm.Text)) && (txtboxPassword.Text == txtboxPasswordConfirm.Text))
            {

                if ((!clsUser.CheckIfUserNameAlreadyExist(txtboxUserName.Text)) || (txtboxUserName.Text == UserName))
                {

                    if (clsUser.UpdateUser(UserID, txtboxUserName.Text, txtboxPassword.Text, chkIsActive.Checked))
                    {
                        MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataBack?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtboxUserName.Focus();


                }
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }
    
    
    
    
    }
}
