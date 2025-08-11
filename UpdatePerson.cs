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
    public partial class UpdatePerson: Form
    {
        public UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNumber, DateTime DateOfBirth, int Gender, string Phone, string Email, int CountryID,string Address , string ImagePath)
        {
            InitializeComponent();
            lblID.Text = PersonID.ToString();
            ctrlUpdatePerson1.LoadPersonInfo(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNumber, DateOfBirth, Gender, Phone, Email, CountryID, Address, ImagePath);

        }

        public UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNumber, DateTime DateOfBirth, string Gender, string Phone, string Email, int CountryID, string Address, string ImagePath)
        {
            InitializeComponent();
            lblID.Text = PersonID.ToString();
            ctrlUpdatePerson1.LoadPersonInfo(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNumber, DateOfBirth, Gender, Phone, Email, CountryID, Address, ImagePath);

        }

        public delegate void DataBackEventHandler();

        public event DataBackEventHandler DataBack;


        private void UpdatePerson_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ctrlUpdatePerson1_OnCloseCompleted(object obj)
        {
           // DataBack?.Invoke();
            this.Close();

        }

        private void ctrlUpdatePerson1_OnSaveCompleted(object obj)
        {
            DataBack?.Invoke();
            this.Close();
        }

        private void ctrlUpdatePerson1_Load(object sender, EventArgs e)
        {

        }

        public void selectIndexForComboBox(int CountryID)
        {
            ctrlUpdatePerson1.SelectIndex(CountryID);
        }
    }
}
