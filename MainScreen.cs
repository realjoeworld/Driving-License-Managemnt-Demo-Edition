using DVLDBussniss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDInterface
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        string UserName = string.Empty, Password = string.Empty, FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LsatName = string.Empty, NationalNO = string.Empty, Gender = string.Empty, Phone = string.Empty, Email = string.Empty, CountryName = string.Empty, Address = string.Empty, ImagePath = string.Empty;

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string UserName = string.Empty, Password = string.Empty, FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LsatName = string.Empty, NationalNO = string.Empty, Gender = string.Empty, Phone = string.Empty, Email = string.Empty, CountryName = string.Empty, Address = string.Empty, ImagePath = string.Empty;
            int PersonID = 0;
            DateTime DateOfBirth = DateTime.Now;
            bool IsActive = false;

            if (clsUser.GetUserInfoByUserID(clsCurrentUser.CurrentUser.UserID, ref UserName, ref Password, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LsatName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath, ref IsActive))
            {
                ChangePasswordScreen frmChangePasswordScreen = new ChangePasswordScreen(PersonID, clsCurrentUser.CurrentUser.UserID, UserName, Password, FirstName, SecondName, ThirdName, LsatName, NationalNO, DateOfBirth, Gender, Phone, Email, CountryName, Address, ImagePath, IsActive);
                frmChangePasswordScreen.ShowDialog();

            }



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuitemManageApplication_Click(object sender, EventArgs e)
        {

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypesScreen frmManageApplicationTypesScreen = new ManageApplicationTypesScreen();
            frmManageApplicationTypesScreen.ShowDialog();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ManageTestType frmManageTestType = new ManageTestType();
            frmManageTestType.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AddNewLocalLicense frmAddNewLocalLicense = new AddNewLocalLicense();
            frmAddNewLocalLicense.ShowDialog();

        }

        private void localDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplicationsScreen frmLocalDrivingLicenseApplicationsScreen = new LocalDrivingLicenseApplicationsScreen();
            frmLocalDrivingLicenseApplicationsScreen.ShowDialog();

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueInternationalLicense frmIssueInternationalLicense = new IssueInternationalLicense();
            frmIssueInternationalLicense.ShowDialog();
        }

        private void internationaDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageInternationalLicense frmManageInternationalLicense = new ManageInternationalLicense();
            frmManageInternationalLicense.ShowDialog();
        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            RenewLocalDrivingLicense frmRenewLocalDrivingLicense = new RenewLocalDrivingLicense();
            frmRenewLocalDrivingLicense.ShowDialog();

        }

        private void relaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementOrDamagedLicense frmReplacementOrDamagedLicense = new ReplacementOrDamagedLicense();
            frmReplacementOrDamagedLicense.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicense frmDetainLicense = new DetainLicense();
            frmDetainLicense.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frmReleaseDetainedLicense = new ReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();
        }

        private void manageDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDetainedLicense listDetainedLicense = new ListDetainedLicense();
            listDetainedLicense.ShowDialog();
        }

        private void retakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frmReleaseDetainedLicense = new ReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplicationsScreen frmLocalDrivingLicenseApplicationsScreen = new LocalDrivingLicenseApplicationsScreen();
            frmLocalDrivingLicenseApplicationsScreen.ShowDialog();
        }

        int PersonID = 0;
        DateTime DateOfBirth = DateTime.Now;
        bool IsActive = false;

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople frmManagePeopleScreen = new ManagePeople();

            frmManagePeopleScreen.ShowDialog();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDrivers frmManageDrivers = new ManageDrivers();
            frmManageDrivers.ShowDialog();
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
            string FilePath = "C:\\Users\\Lenovo\\UsersToRember\\UserToRemberFile.txt";
            File.WriteAllText(FilePath, ""); // Clear the file on exit

        }

        private List<clsUser> GetAllUsersToRemember()
        {
            List<clsUser> UsersToRemember = new List<clsUser>();

            string filePath = "C:\\Users\\Lenovo\\UsersToRember\\UserToRemberFile.txt";

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {


                    // Split the line using #//# as the separator
                    string[] parts = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                    bool IsActive = (parts[4] == "0") ? false : true;

                    clsUser user = new clsUser(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), parts[2], parts[3], IsActive);
                    UsersToRemember.Add(user);

                }
            }
            return UsersToRemember;
        }


        private void SignOutMenuItem1_Click(object sender, EventArgs e)
        {
            
            List<clsUser> UsersToRemember = GetAllUsersToRemember();

            if (UsersToRemember.Count > 0)
            {
                
                LoginScreen frmLoginScreen = new LoginScreen(UsersToRemember[0].UserName, UsersToRemember[0].Password);
                this.Hide();
                frmLoginScreen.ShowDialog();
                this.Close();
            }
            else
            {
                LoginScreen frmLoginScreen = new LoginScreen();
                this.Hide();
                frmLoginScreen.ShowDialog();
                this.Close();
            }


        }
        

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

           

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsersScreen frmManageUserScreen = new ManageUsersScreen();
            frmManageUserScreen.ShowDialog();

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clsUser.GetUserInfoByUserID(clsCurrentUser.CurrentUser.UserID, ref UserName, ref Password, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LsatName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath, ref IsActive))
            {
                ShowUserDetails frmChangePasswordScreen = new ShowUserDetails(PersonID, clsCurrentUser.CurrentUser.UserID, UserName, Password, FirstName, SecondName, ThirdName, LsatName, NationalNO, DateOfBirth, Gender, Phone, Email, CountryName, Address, ImagePath, IsActive);
                frmChangePasswordScreen.Name = "Current User";
                frmChangePasswordScreen.ShowDialog();

            }

        }
    }
}
