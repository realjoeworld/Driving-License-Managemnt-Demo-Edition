using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDInterface.Properties;
using DVLDBussniss;
using System.IO;

namespace DVLDInterface
{
    public partial class ctrlUpdatePerson : UserControl
    {
        public ctrlUpdatePerson()
        {
            InitializeComponent();
        }


        public string PreviousNationalNo { get; set; }

        public string ImagePath { get; set; } = "";
        public int PersonID { get; set; }


        public event Action<object> OnSaveCompleted;

        protected virtual void SaveCompleted(object sender)
        {
            Action<object> Handler = OnSaveCompleted;
            
            if (Handler != null)
            {
                Handler(sender);
            }
        
        }

        private void txtboxFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxFirstName.Text))
            {
                e.Cancel = true; // Cancel the event
                MessageBox.Show("First Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtboxFirstName.Clear();
                txtboxFirstName.Focus(); // Set focus back to the textbox

            }


        }

        private void txtboxSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxSecondName.Text))
            {
                e.Cancel = true; // Cancel the event
                MessageBox.Show("Second Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtboxSecondName.Clear();
                txtboxSecondName.Focus(); // Set focus back to the textbox

            }
        }

        private void txtboxThirdName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxThirdName.Text))
            {
                e.Cancel = true; // Cancel the event
                MessageBox.Show("Third Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtboxThirdName.Clear();
                txtboxThirdName.Focus(); // Set focus back to the textbox

            }
        }

        private void txtboxLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxLastName.Text))
            {
                e.Cancel = true; // Cancel the event
                MessageBox.Show("Last Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtboxLastName.Clear();
                txtboxLastName.Focus(); // Set focus back to the textbox

            }
        }

        private void txtBoxNationalNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxPhone_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtboxPhone.Text))
            {

                MessageBox.Show("National Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtboxPhone.Clear();
                txtboxPhone.Focus(); // Set focus back to the textbox

            }

        }

        private void txtboxAddress_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxAddress.Text))
            {
                MessageBox.Show("Address cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtboxAddress.Clear();
                txtboxAddress.Focus(); // Set focus back to the textbox
            }
        }



        private void linklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog1.FileName;
                picboxImage.Image = Image.FromFile(ImagePath);

            }
        }

        private void linklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rdbMale.Checked)
            {
                if(ImagePath == "")
                  picboxImage.Image = Resources.Male_512;
            }
            else
            {
                if (ImagePath == "")
                    picboxImage.Image = Resources.Female_512;
            }
        }

        private void ctrlUpdatePerson_Load(object sender, EventArgs e)
        {
            CountriesComboBox.DataSource = clsCountry.GetAllCountries();
            CountriesComboBox.DisplayMember = "CountryName"; // Display the country name
            CountriesComboBox.ValueMember = "CountryID"; // Use the country ID as the value
            CountriesComboBox.SelectedValue = 90;
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18).Date.AddDays(1).AddSeconds(-1);
            rdbMale.Checked = true;
        }


        public event Action<object> OnCloseCompleted;

        protected virtual void FormClosing(object sender)
        {

            Action<object> Handler = OnCloseCompleted;

            if (Handler != null)
            {
                Handler(sender);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Close This Form ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                if (OnCloseCompleted != null)
                {

                    FormClosing(this);

                }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(txtboxFirstName.Text) && string.IsNullOrWhiteSpace(txtboxSecondName.Text) && string.IsNullOrWhiteSpace(txtboxLastName.Text) && string.IsNullOrWhiteSpace(txtBoxNationalNumber.Text) && string.IsNullOrWhiteSpace(txtboxPhone.Text) && string.IsNullOrWhiteSpace(txtboxAddress.Text)))
            {
                string Gender = "Male";

                if (rdbFemale.Checked)
                {
                    Gender = "FeMale";
                }


                if (clsPerson.UpdatePersonInfo(PersonID, txtboxFirstName.Text, txtboxSecondName.Text, txtboxThirdName.Text, txtboxLastName.Text, txtBoxNationalNumber.Text, dateTimePicker1.Value, Gender, txtboxAddress.Text, txtboxPhone.Text, txtboxEmail.Text, CountriesComboBox.SelectedIndex, this.ImagePath))
                {
                    MessageBox.Show("Person Info Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if(OnSaveCompleted != null)
                    {
                        SaveCompleted(this);
                    }

                }
                else
                {
                    MessageBox.Show("Failed to update person info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

    

        public void LoadPersonInfo(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNO, DateTime DateOfBirth, int Gender, string Phone, string Email, int CountryID, string Address, string ImagePath)
        {
            this.PersonID = PersonID;
            txtboxFirstName.Text = FirstName;
            txtboxSecondName.Text = SecondName;
            txtboxThirdName.Text = ThirdName;
            txtboxLastName.Text = LastName;
            txtBoxNationalNumber.Text = NationalNO;
            PreviousNationalNo = NationalNO;
            dateTimePicker1.Value = DateOfBirth;

            if (Gender == 0)
            {
                rdbMale.Checked = true;
            }
            else
            {
                rdbMale.Checked = true;
            }

            txtboxPhone.Text = Phone;
            txtboxEmail.Text = Email;
            CountriesComboBox.SelectedValue = CountryID;
            txtboxAddress.Text = Address;

            if (!string.IsNullOrEmpty(ImagePath))
                picboxImage.Image = Image.FromFile(ImagePath);

            this.ImagePath = ImagePath;

        }


        public void LoadPersonInfo(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNO, DateTime DateOfBirth, string Gender, string Phone, string Email, int CountryID, string Address, string ImagePath)
        {
            this.PersonID = PersonID;
            txtboxFirstName.Text = FirstName;
            txtboxSecondName.Text = SecondName;
            txtboxThirdName.Text = ThirdName;
            txtboxLastName.Text = LastName;
            txtBoxNationalNumber.Text = NationalNO;
            PreviousNationalNo = NationalNO;
            dateTimePicker1.Value = DateOfBirth;

            if (Gender == "Male")
            {
                rdbMale.Checked = true;
            }
            else
            {
                rdbMale.Checked = true;
            }

            txtboxPhone.Text = Phone;
            txtboxEmail.Text = Email;
            CountriesComboBox.SelectedValue = CountryID;
            txtboxAddress.Text = Address;

            if (!string.IsNullOrEmpty(ImagePath))
                picboxImage.Image = Image.FromFile(ImagePath);

            this.ImagePath = ImagePath;

        }

        private void txtBoxNationalNumber_Validating(object sender, CancelEventArgs e)
        {



            if (string.IsNullOrWhiteSpace(txtBoxNationalNumber.Text) )
            {

                MessageBox.Show("National Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxNationalNumber.Clear();
                txtBoxNationalNumber.Focus();
                return;// Set focus back to the textbox

            }


            if (txtBoxNationalNumber.Text == PreviousNationalNo)
            {
                return; // No need to validate if the national number hasn't changed
            }

            if (clsPerson.CheckIfNationalNumberExists(txtBoxNationalNumber.Text))
            {
                MessageBox.Show("This National Number Already Exists, Try Another One", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxNationalNumber.Clear();
                txtBoxNationalNumber.Focus();
               
            }
           




        }

        public void SelectIndex(int index) {
         
            if(index > 0)
                CountriesComboBox.SelectedIndex = index;

        }

    }
}
