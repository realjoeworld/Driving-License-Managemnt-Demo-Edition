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
    public partial class ManageUsersScreen : Form
    {
        public ManageUsersScreen()
        {
            InitializeComponent();
        }

        string UserName = string.Empty, Password = string.Empty, FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LsatName = string.Empty, NationalNO = string.Empty, Gender = string.Empty, Phone = string.Empty, Email = string.Empty, CountryName = string.Empty, Address = string.Empty, ImagePath = string.Empty;
        int PersonID = 0;
        DateTime DateOfBirth = DateTime.Now;
        bool IsActive = false;

        private void ManageUsersScreen_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsUser.GetAllUsers();
            ComboBoxFilter.SelectedIndex = 0;
            ComboBoxSearch.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewUserScreen frmAddNewUserScreen = new AddNewUserScreen();
            frmAddNewUserScreen.DataBack += RefreshData;
            frmAddNewUserScreen.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUser.GetUserInfoByUserID(IDForSelectedRow, ref UserName, ref Password, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LsatName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath, ref IsActive))
            {
                UpdateUser frmUpdateUser = new UpdateUser(PersonID, IDForSelectedRow, UserName, Password, FirstName, SecondName, ThirdName, LsatName, NationalNO, DateOfBirth, Gender, Phone, Email, CountryName, Address, ImagePath, IsActive);
                frmUpdateUser.DataBack += RefreshData;
                frmUpdateUser.ShowDialog();

            }
        }

        private void addNewUSerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUserScreen frmAddNewUserScreen = new AddNewUserScreen();
            frmAddNewUserScreen.DataBack += RefreshData;
            frmAddNewUserScreen.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clsUser.GetUserInfoByUserID(IDForSelectedRow, ref UserName, ref Password, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LsatName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath, ref IsActive))
            {
                ChangePasswordScreen frmChangePasswordScreen = new ChangePasswordScreen(PersonID, IDForSelectedRow, UserName, Password, FirstName, SecondName, ThirdName, LsatName, NationalNO, DateOfBirth, Gender, Phone, Email, CountryName, Address, ImagePath, IsActive);
                frmChangePasswordScreen.ShowDialog();

            }
        }

        private void ComboBoxSearch_TextChanged(object sender, EventArgs e)
        {

            if (ComboBoxFilter.SelectedIndex == 0)
            {
                dataGridView1.DataSource = clsUser.GetAllUsers();
            }

            else if (ComboBoxFilter.SelectedIndex == 1)
            {
                dataGridView1.DataSource = clsUser.GetAllUsersUserIDStartWith(ComboBoxSearch.Text);
            }

            else if (ComboBoxFilter.SelectedIndex == 2)
            {
                dataGridView1.DataSource = clsUser.GetAllUsersPersonIDtartWith(ComboBoxSearch.Text);

            }

            else if (ComboBoxFilter.SelectedIndex == 3)
            {
                dataGridView1.DataSource = clsUser.GetAllUsersUserNameStartWith(ComboBoxSearch.Text);
            }

            else if (ComboBoxFilter.SelectedIndex == 4)
            {
                dataGridView1.DataSource = clsUser.GetAllUsersFullNameStartWith(ComboBoxSearch.Text);
            }


        }

        private void RefreshData() {
            dataGridView1.DataSource = clsUser.GetAllUsers();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxFilter.SelectedIndex == 0)
            {
                ComboBoxSearch.Visible = false;
            }
            else
            {
                ComboBoxSearch.DropDownStyle = ComboBoxStyle.Simple;
                ComboBoxSearch.Items.Clear();
                ComboBoxSearch.Text = string.Empty;
                ComboBoxSearch.Visible = true;
            }

            if (ComboBoxFilter.SelectedIndex == 5)
            {
                ComboBoxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
                ComboBoxSearch.Items.Add("Active");
                ComboBoxSearch.Items.Add("InActive");
                ComboBoxSearch.SelectedIndex = 0; // Default to Active


            }

        }

        private void txtboxFilter_TextChanged(object sender, EventArgs e)
        {

            if (ComboBoxFilter.SelectedIndex == 0)
            {
                dataGridView1.DataSource = clsUser.GetAllUsers();
            }

            else if (ComboBoxFilter.SelectedIndex == 1)
            {
                dataGridView1.DataSource = clsUser.GetAllUsersUserIDStartWith(ComboBoxSearch.Text);
            }

            else if (ComboBoxFilter.SelectedIndex == 2)
            {
                dataGridView1.DataSource = clsUser.GetAllUsersPersonIDtartWith(ComboBoxSearch.Text);

            }

            else if (ComboBoxFilter.SelectedIndex == 3)
            {
                dataGridView1.DataSource = clsUser.GetAllUsersUserNameStartWith(ComboBoxSearch.Text);
            }

            else if (ComboBoxFilter.SelectedIndex == 4)
            {
                dataGridView1.DataSource = clsUser.GetAllUsersFullNameStartWith(ComboBoxSearch.Text);
            }




        }

        private void ComboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ComboBoxSearch.SelectedIndex == 0)
            {

                dataGridView1.DataSource = clsUser.GetAllUsersActive();
            }
            else
            {
                dataGridView1.DataSource = clsUser.GetAllUsersInActive();
            }


        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Fiture Will Be Implemented Soon", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Fiture Will Be Implemented Soon", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Do You Want To Delete This User ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsUser.DeleteUserByUserID(IDForSelectedRow)) {
                    MessageBox.Show("User Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Failed To Delete User, This Connected With Other Entities", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("User Deletion Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int IndexRowSelected = 0;
        int IDForSelectedRow = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                IndexRowSelected = e.RowIndex;
                IDForSelectedRow = (int)dataGridView1.Rows[IndexRowSelected].Cells["UserID"].Value;

            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           


            if(clsUser.GetUserInfoByUserID(IDForSelectedRow,ref UserName,ref Password,ref PersonID,ref FirstName,ref SecondName,ref ThirdName,ref LsatName,ref NationalNO,ref DateOfBirth,ref Gender,ref Phone,ref Email,ref CountryName,ref Address,ref ImagePath,ref IsActive))
            {
                ShowUserDetails frmChangePasswordScreen = new ShowUserDetails(PersonID, IDForSelectedRow, UserName, Password, FirstName, SecondName, ThirdName, LsatName, NationalNO, DateOfBirth, Gender, Phone, Email, CountryName, Address, ImagePath, IsActive);
                frmChangePasswordScreen.ShowDialog();
            
            }

        }

       



        }
}

