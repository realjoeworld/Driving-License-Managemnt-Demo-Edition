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
    public partial class PersonDetails: Form
    {

        ctrlShowPersonDetails ctrlShowPersonDetails;
        public PersonDetails(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNumber, DateTime DateOfBirth, string Gender, string Address, string Phone, string Email, string CountryName, string ImagePath)
        {
            
            InitializeComponent();
            ctrlShowPersonDetails1.LoadPersonData( PersonID,  FirstName,  SecondName,  ThirdName,  LastName, NationalNumber,  DateOfBirth,  Gender,  Address,  Phone,  Email,  CountryName,  ImagePath);
            
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
