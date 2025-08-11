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
    public partial class AddNewLocalLicense: Form
    {
        public AddNewLocalLicense()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           
            if(!ctrlSearchForPersonByFilter1.IsFound)
            {
                MessageBox.Show("Please Search For Person First");
                tabControl1.SelectedIndex = 0;
                return;
            }
            else
            {
                tabControl1.SelectedIndex = 1;

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && !ctrlSearchForPersonByFilter1.IsFound)
            {
                MessageBox.Show("Please Search For Person First");
                tabControl1.SelectedIndex = 0;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void AddNewLocalLicense_Load(object sender, EventArgs e)
        {
            
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblUser.Text = clsCurrentUser.CurrentUser.UserName;
            ClassComboBox.DataSource = clsLicenseClasses.GetClassNameAndID();
            ClassComboBox.DisplayMember = "ClassName"; // Display the class name
            ClassComboBox.ValueMember = "LicenseClassID";
            ClassComboBox.SelectedIndex = 0; // Use the class ID as the value
            this.Size = new Size(750, 570); // Set the form size to 800x600

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlSearchForPersonByFilter1.IsFound)
            {

                int ClassID = Convert.ToInt32(ClassComboBox.SelectedValue);

                int IDResult = 0;

                if ((IDResult = clsPerson.CheckIfPersonHasApplicationItsStatusNewAndSameLicenseClass(ctrlSearchForPersonByFilter1.PersonID, ClassID)) != 0)
                {
                    MessageBox.Show($"This Person Already Has An Application With ID = {IDResult} For The Same License Class {ClassComboBox.SelectedIndex + 1}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }

                else
                {
                    int ApplicationID = -1; // Assuming 1 is the ID for Local License
                    
                    if ((ApplicationID = clsPerson.AddNewApplicationForLocalLicense(ctrlSearchForPersonByFilter1.PersonID, DateTime.Now, 1, 1, DateTime.Now, 15, clsCurrentUser.CurrentUser.UserID)) != -1)
                    {

                        MessageBox.Show($"New Application Added Successfully With ID = {ApplicationID} ");
                       

                        int LocalLicenseID = -1; // Assuming 1 is the ID for Local License

                        if ((LocalLicenseID = clsPerson.AddNewLocalLicenseApplication(ApplicationID, ClassID)) != -1)
                        {
                            btnSave.Enabled = false; // Disable the save button after successful addition
                            MessageBox.Show($"New Local License Application Added Successfully With ID = {LocalLicenseID} ");
                            lblID.Text = LocalLicenseID.ToString();

                        }
                        else
                        {
                            MessageBox.Show("Failed To Add New Local License Application");

                        }
                    }

                    else
                    {
                        MessageBox.Show("Failed To Add New Application");

                    }


                }

            }
        }
    
    
    
    
    
    
    
    
    
    }
}
