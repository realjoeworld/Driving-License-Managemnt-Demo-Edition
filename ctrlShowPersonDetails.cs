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
    public partial class ctrlShowPersonDetails: UserControl
    {

        public int ID { get; set; }
        
        
        public ctrlShowPersonDetails()
        {
            InitializeComponent();
            
        }

        UpdatePerson frmUpdatePerson = null;
        int CountryID = 0;
        public void LoadPersonData(int PersonID, string FirstName, string SecondName, string ThirdName ,string LastName,string NationalNumber ,DateTime DateOfBirth, string Gender , string Address, string Phone, string Email, string CountryName, string ImagePath)
        {
            ID = PersonID;
            lblPersonID.Text = PersonID.ToString();
            lblFullName.Text = $"{FirstName} {SecondName} {ThirdName} {LastName} ";
            lblNationalNo.Text = NationalNumber;
            
           lblGender.Text = Gender;


            lblEmail.Text = Email;
            lblAddress.Text = Address;

            lblDateOfBirth.Text = DateOfBirth.ToString("dd/MM/yyyy");

            lblPhone.Text = Phone;


            lblCountry.Text = CountryName;

            if (ImagePath != "")
            {
                PersonPictureBox.Image = Image.FromFile(ImagePath);
            }

            int GenderType = 0;
            if (Gender == "FeMale")
                GenderType = 1;

            CountryID = clsCountry.GetCountryIndexByName(CountryName);

            frmUpdatePerson = new UpdatePerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNumber, DateOfBirth, GenderType,Phone,Email,CountryID,Address,ImagePath);

        }


      

        private void ctrlShowPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // frmUpdatePerson.selectIndexForComboBox(CountryID);
            frmUpdatePerson.ShowDialog();

        }
    }
}
