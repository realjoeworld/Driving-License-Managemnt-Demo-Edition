using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DVLDBussniss;
using DVLDInterface.Properties;
using System.IO;


namespace DVLDInterface
{
    public partial class ctrlAddNewPerson: UserControl
    {
        public ctrlAddNewPerson()
        {
            InitializeComponent();
        }

        public string ImagePath { get; set; }
        public int ID { get; set; }


        public event Action<int> OnSaveCompleted;

        protected virtual void ReturnedID(int ID) {

            Action<int> Handler = OnSaveCompleted;

            if(Handler != null)
            {
                Handler(ID);
            }

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

        private void ctrlAddNewPerson_Load(object sender, EventArgs e)
        {
            rdbMale.Checked = true;

            CountriesComboBox.DataSource = clsCountry.GetAllCountries();
            CountriesComboBox.DisplayMember = "CountryName"; // Display the country name
            CountriesComboBox.ValueMember = "CountryID"; // Use the country ID as the value
            CountriesComboBox.SelectedValue = 90;
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18).Date.AddDays(1).AddSeconds(-1);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block the key
            }

        }

        private void txtboxFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (txtboxFirstName.Text == string.Empty)
            {

                errorProvider1.SetError(txtboxFirstName, "First name cannot be empty.");
                txtboxFirstName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtboxFirstName, ""); // clear the error
            }
        }


        private void txtboxMiddleName_Validating(object sender, CancelEventArgs e)
        {
            if (txtboxSecondName.Text == string.Empty)
            {
                errorProvider1.SetError(txtboxSecondName, "Last name cannot be empty.");
                txtboxSecondName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtboxSecondName, ""); // clear the error
            }
        }

        private void txtboxThirdName_Validating(object sender, CancelEventArgs e)
        {
            if (txtboxThirdName.Text == string.Empty)
            {
                errorProvider1.SetError(txtboxThirdName, "Last name cannot be empty.");
                txtboxThirdName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtboxThirdName, ""); // clear the error
            }
        }

        private void txtboxLastName_Validating(object sender, CancelEventArgs e)
        {
            if (txtboxLastName.Text == string.Empty)
            {
                errorProvider1.SetError(txtboxLastName, "Last name cannot be empty.");
                txtboxLastName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtboxLastName, ""); // clear the error
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

        private bool IsValidEmail(string email)
        {
            // Simple email pattern (covers most cases)
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        protected virtual void txtBoxNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if(clsPerson.CheckIfNationalNumberExists(txtBoxNationalNumber.Text))
            {
                MessageBox.Show("This National Number Already Exist , Try Another One","", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtBoxNationalNumber.Clear();
                txtBoxNationalNumber.Focus();
                return;
            }

            if(txtBoxNationalNumber.Text == string.Empty)
            {
                errorProvider1.SetError(txtBoxNationalNumber, "National number cannot be empty.");
                txtBoxNationalNumber.Focus();

            }
            else
            {
                errorProvider1.SetError(txtBoxNationalNumber, ""); // clear the error
            }
        }

        private void linklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(rdbMale.Checked)
            {
                picboxImage.Image = Resources.Male_512;
            }
            else
            {
                picboxImage.Image = Resources.Female_512;
            }
        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMale.Checked) {
                ImagePath = "C:\\Users\\Lenovo\\Desktop\\Icons\\Male 512.PNG";
                picboxImage.Image = Image.FromFile(ImagePath);
            }
          
            
        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFemale.Checked)
            {
                ImagePath = "C:\\Users\\Lenovo\\Desktop\\Icons\\FeMale 512.PNG";
                picboxImage.Image = Image.FromFile(ImagePath);
            }
        }

        private void txtboxEmail_Validating(object sender, CancelEventArgs e)
        {
            if(txtboxEmail.Text == string.Empty)
            {
                return;
            }

            if (!IsValidEmail(txtboxEmail.Text))
            {
                errorProvider1.SetError(txtboxEmail, "Invalid email format.");
                txtboxEmail.Focus();
            }
            else
            {
                errorProvider1.SetError(txtboxEmail, ""); // clear the error
            }
        }



        protected virtual void button2_Click(object sender, EventArgs e)
        {

            byte Gender = 0;

            if (rdbFemale.Checked)
                Gender = 1;

            ID = -1;

            if (txtboxFirstName.Text != string.Empty || txtboxSecondName.Text != string.Empty || txtboxThirdName.Text != string.Empty || txtboxLastName.Text != string.Empty || txtBoxNationalNumber.Text != string.Empty || txtboxPhone.Text != string.Empty)
            {

                if (MessageBox.Show("Are You Sure You Want To Save Person Info ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if ((ID = clsPerson.AddNewPerson(txtboxFirstName.Text, txtboxSecondName.Text, txtboxThirdName.Text, txtboxLastName.Text, txtBoxNationalNumber.Text, dateTimePicker1.Value, Gender, txtboxAddress.Text, txtboxPhone.Text, txtboxEmail.Text, Convert.ToByte(CountriesComboBox.SelectedValue), ImagePath)) != -1)
                    {
                        MessageBox.Show($"The New ID Is: {ID}");

                        btnSave.Enabled = false;

                        if (OnSaveCompleted != null)
                        {
                            ReturnedID(ID);
                        }



                        string DestinationPath = @"C:\\DVLD-People-Images";

                        string extension = Path.GetExtension(ImagePath);

                        string NewFileName = Guid.NewGuid().ToString() + extension;

                        string DestinationFilePath = Path.Combine(DestinationPath, NewFileName);

                        File.Copy(ImagePath, DestinationFilePath);

                   



                    }
                }
                else
                {
                    MessageBox.Show("Saving Cancelled");

                }
            }
            else
            {
                MessageBox.Show("Please Fill All Required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure You Want To Close This Form ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                if (OnCloseCompleted != null) {

                    FormClosing(this);

                }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            DateTime selectedDate = dateTimePicker1.Value.Date; // only date
            TimeSpan currentTime = DateTime.Now.TimeOfDay;      // current time

            // Combine selected date + current time
            dateTimePicker1.Value = selectedDate + currentTime;

        }

        private void CountriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtboxPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxPhone.Text))
            {
                errorProvider1.SetError(txtboxPhone, "Phone Cannot Be Empty.");
                txtboxPhone.Focus();
            }
            else
            {
                errorProvider1.SetError(txtboxPhone, ""); // clear the error
            }
        }

        private void txtboxPhone_Validating1()
        {
            if (string.IsNullOrEmpty(txtboxPhone.Text))
            {
                errorProvider1.SetError(txtboxLastName, "Phone Cannot Be Empty.");
                txtboxLastName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtboxPhone, ""); // clear the error
            }
        }

        private void txtboxAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxAddress.Text))
            {
                errorProvider1.SetError(txtboxAddress, "Phone Cannot Be Empty.");
                txtboxAddress.Focus();
            }
            else
            {
                errorProvider1.SetError(txtboxAddress, ""); // clear the error
            }
        }
    }
}
