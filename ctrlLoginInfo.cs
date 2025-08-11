using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDInterface
{
    public partial class ctrlLoginInfo: UserControl
    {
        public ctrlLoginInfo()
        {
            InitializeComponent();
        }

        private void ctrlLoginInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadUserData(int UserID, string UserName, bool IsActive)
        {
            lblUserID.Text = UserID.ToString();
            lblUserName.Text = UserName;
            lblIsActive.Text = IsActive ? "Yes" : "No";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
