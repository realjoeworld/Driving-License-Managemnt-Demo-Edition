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
    public partial class AddNewPerson: Form
    {

        public AddNewPerson()
        {
            InitializeComponent();
            ctrlAddNewPerson1.OnSaveCompleted += ctrlAddNewPerson1_OnSaveCompleted;
        }


        public delegate void DataBackEventHandler();
        public event DataBackEventHandler DataBack;


        public delegate void DataBackEventHandlerOnSaved();
        public event DataBackEventHandlerOnSaved DataBackOnSaved;


        private void ctrlAddNewPerson1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddNewPerson1_OnSaveCompleted(int obj)
        {
            lblID.Text = obj.ToString();
            DataBack?.Invoke();
            
           // this.Close();


        }

        private void ctrlAddNewPerson1_OnCloseCompleted(object obj)
        {
           // DataBack?.Invoke();
            this.Close();
        }

        private void AddNewPerson_Load(object sender, EventArgs e)
        {

        }

        //private void ctrlAddNewPerson1_OnSaveCompleted(int obj)
        //{
        //    lblID.Text = obj.ToString();
        //    DataBack?.Invoke();
        //    ctrlAddNewPerson1_OnCloseCompleted(this);


        //}
    }
}
