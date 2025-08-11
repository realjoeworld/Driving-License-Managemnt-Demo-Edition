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
    public partial class ManageTestType: Form
    {
        public ManageTestType()
        {
            InitializeComponent();
        }

        private void ManageTestType_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsTestTypes.GetAllTestTypes();
            dataGridView1.Columns[0].Width = 50; // ID column width
            dataGridView1.Columns[1].Width = 150; // Test Title column width
            dataGridView1.Columns[2].Width = 150; // Test Description column width
            dataGridView1.Columns[3].Width = 97; // Test Fees column width
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

        private void RefreshData() {

            dataGridView1.DataSource = clsTestTypes.GetAllTestTypes();
            dataGridView1.Columns[0].Width = 50; // ID column width
            dataGridView1.Columns[1].Width = 150; // Test Title column width
            dataGridView1.Columns[2].Width = 150; // Test Description column width
            dataGridView1.Columns[3].Width = 97;

        }


        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string TestTitle = string.Empty, TestDescription = string.Empty;
            int Fees = 0;
            
            if (clsTestTypes.GetTestTypeInfo(IDForSelectedRow,ref TestTitle,ref TestDescription,ref Fees))
            {
                UpdateTestTypes frmUpdateTestTypes = new UpdateTestTypes(IDForSelectedRow, TestTitle, TestDescription, Fees);
                frmUpdateTestTypes.DataBack += RefreshData;
                frmUpdateTestTypes.ShowDialog();


            }

        }
    }
    }

