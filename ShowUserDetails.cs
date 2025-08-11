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
    public partial class ShowUserDetails: Form
    {
        public ShowUserDetails(int personID, int userID, string userName, string password, string firstName, string secondName, string thirdName, string lastName, string nationalNo, DateTime dateOfBirth, string gender, string phone, string email, string country, string address, string ImagePath, bool isActive)
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

        private void ChangePasswordScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
