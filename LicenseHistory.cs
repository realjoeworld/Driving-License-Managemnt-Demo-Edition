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
    public partial class LicenseHistory: Form
    {

        int PersonID { get; set; }
        public LicenseHistory(int PersonID)
        {
            InitializeComponent();
            ctrlSearchForPersonByFilter ctrlSearchForPersonByFilter = new ctrlSearchForPersonByFilter(PersonID);
            ctrlSearchForPersonByFilter.Location = new Point(10, 10);     // ✅ Required: position on form
            ctrlSearchForPersonByFilter.Size = new Size(670, 670);        // ✅ Optional: ensure it's not 0x0
            this.Controls.Add(ctrlSearchForPersonByFilter);
            this.PersonID = PersonID;

            dataGridView1.DataSource = clsDriver.GetAllLicenseForPersonID(PersonID);
            dataGridView2.DataSource = clsDriver.GetAllInternationalLicenseForPersonID(PersonID);

        }

        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            this.Top = 0;

            // Maximize the form height to fill the screen (excluding taskbar)
            this.Height = Screen.FromControl(this).WorkingArea.Height;
        }
    }
}
