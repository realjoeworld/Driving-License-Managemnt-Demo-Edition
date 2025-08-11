using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussniss;

namespace DVLDInterface
{
    public partial class ManageApplicationTypesScreen: Form
    {
        public ManageApplicationTypesScreen()
        {
            InitializeComponent();
        }

        private void ManageApplicationTypesScreen_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsApplicationTypes.GetAllApplicationTypes();
            dataGridView1.Columns[1].Width = 240;


        }

        private void RefreshData()
        {
            dataGridView1.DataSource = clsApplicationTypes.GetAllApplicationTypes();
            dataGridView1.Columns[1].Width = 240;
        }

        public int IndexRowSelected = 0;
        int IDForSelectedRow = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                IndexRowSelected = e.RowIndex;
                IDForSelectedRow = (int)dataGridView1.Rows[IndexRowSelected].Cells["ID"].Value;

            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Fees = 0;
            string ApplicationTypeName = string.Empty;
            
            if(clsApplicationTypes.GetApplicationTypeInfo(IDForSelectedRow, ref ApplicationTypeName,ref Fees))
            {
                UpdateApplicstionTypes frmUpdateApplicstionTypes = new UpdateApplicstionTypes(IDForSelectedRow, ApplicationTypeName, Fees);
                frmUpdateApplicstionTypes.DataBack += RefreshData;
                frmUpdateApplicstionTypes.ShowDialog();
            }


        }
    }
}
