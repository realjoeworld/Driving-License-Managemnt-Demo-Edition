using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using DVLDBussniss;

namespace DVLDInterface
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        public LoginScreen(string UserName, string Password)
        {
            InitializeComponent();
            txtboxUserName.Text = UserName;
            txtboxPassword.Text = Password;
        }

        string FilePath = "C:\\Users\\Lenovo\\UsersToRember\\UserToRemberFile.txt";
        private void AppendUserToRemember(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {

            string IsActiveString = IsActive ? "1" : "0";
            string DataToAppend = $"{UserID}#//#{PersonID}#//#{UserName}#//#{Password}#//#{IsActiveString}";

            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.Write($"{DataToAppend}\r\n");
            }


        }



     

        private void button1_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            int PersonID = 0;
            string UserName = txtboxUserName.Text.Trim();
            string Password = txtboxPassword.Text.Trim();
            bool IsActive = false;

            if (clsUser.CheckIfUserExist(ref UserID,ref PersonID,UserName,Password,ref IsActive))
            {
               
               clsUser CurrentUser = new clsUser(UserID, PersonID, UserName, Password, IsActive);


                if(!CurrentUser.IsActive)
                {
                    MessageBox.Show("Your Account Is Inactive. Please Contact Your Admin.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {

                    
                    if(remembermeChkBox.Checked)
                    {
                       AppendUserToRemember(CurrentUser.UserID, CurrentUser.PersonID, CurrentUser.UserName, CurrentUser.Password, CurrentUser.IsActive);

                    }
                    
                    else
                    {
                       
                       File.WriteAllText(FilePath, "");

                    }

                    clsCurrentUser.CurrentUser = CurrentUser;

                    MainScreen frmMainScreen = new MainScreen();
                    this.Hide();
                    frmMainScreen.ShowDialog();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Invalid UserName/Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
           
        }
    }
}
