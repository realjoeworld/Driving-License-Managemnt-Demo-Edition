namespace DVLDInterface
{
    partial class LocalDrivingLicenseApplicationsScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWriteTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDrivingLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.txtboxSearch = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(466, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Driving License Applications";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(123, 345);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1135, 439);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellBorderStyleChanged += new System.EventHandler(this.dataGridView1_CellBorderStyleChanged);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationsToolStripMenuItem,
            this.deleteApplicationsToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.sceToolStripMenuItem,
            this.issueDrivingLicenseToolStripMenuItem,
            this.showDrivingLicenseInfoToolStripMenuItem,
            this.showLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(355, 324);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.PersonDetails_32;
            this.showApplicationDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(354, 40);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editApplicationsToolStripMenuItem
            // 
            this.editApplicationsToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.edit_32;
            this.editApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editApplicationsToolStripMenuItem.Name = "editApplicationsToolStripMenuItem";
            this.editApplicationsToolStripMenuItem.Size = new System.Drawing.Size(354, 40);
            this.editApplicationsToolStripMenuItem.Text = "Edit Applications";
            // 
            // deleteApplicationsToolStripMenuItem
            // 
            this.deleteApplicationsToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.Delete_32_2;
            this.deleteApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteApplicationsToolStripMenuItem.Name = "deleteApplicationsToolStripMenuItem";
            this.deleteApplicationsToolStripMenuItem.Size = new System.Drawing.Size(354, 40);
            this.deleteApplicationsToolStripMenuItem.Text = "Delete Applications";
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.Delete_32;
            this.cancelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(354, 40);
            this.cancelToolStripMenuItem.Text = "Cancel Applications";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // sceToolStripMenuItem
            // 
            this.sceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schduleVisionTestToolStripMenuItem,
            this.scheduleWriteTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.sceToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.Written_Test_321;
            this.sceToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sceToolStripMenuItem.Name = "sceToolStripMenuItem";
            this.sceToolStripMenuItem.Size = new System.Drawing.Size(354, 40);
            this.sceToolStripMenuItem.Text = "Sechdule Test";
            // 
            // schduleVisionTestToolStripMenuItem
            // 
            this.schduleVisionTestToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.Vision_Test_32;
            this.schduleVisionTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.schduleVisionTestToolStripMenuItem.Name = "schduleVisionTestToolStripMenuItem";
            this.schduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(281, 42);
            this.schduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.schduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.schduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWriteTestToolStripMenuItem
            // 
            this.scheduleWriteTestToolStripMenuItem.Enabled = false;
            this.scheduleWriteTestToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.Written_Test_32;
            this.scheduleWriteTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleWriteTestToolStripMenuItem.Name = "scheduleWriteTestToolStripMenuItem";
            this.scheduleWriteTestToolStripMenuItem.Size = new System.Drawing.Size(281, 42);
            this.scheduleWriteTestToolStripMenuItem.Text = "Schedule Write Test";
            this.scheduleWriteTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleWriteTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Enabled = false;
            this.scheduleStreetTestToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.Street_Test_32;
            this.scheduleStreetTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(281, 42);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // issueDrivingLicenseToolStripMenuItem
            // 
            this.issueDrivingLicenseToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.IssueDrivingLicense_321;
            this.issueDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issueDrivingLicenseToolStripMenuItem.Name = "issueDrivingLicenseToolStripMenuItem";
            this.issueDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(354, 40);
            this.issueDrivingLicenseToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.issueDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseToolStripMenuItem_Click);
            // 
            // showDrivingLicenseInfoToolStripMenuItem
            // 
            this.showDrivingLicenseInfoToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.License_View_32;
            this.showDrivingLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDrivingLicenseInfoToolStripMenuItem.Name = "showDrivingLicenseInfoToolStripMenuItem";
            this.showDrivingLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(354, 40);
            this.showDrivingLicenseInfoToolStripMenuItem.Text = "Show License ";
            this.showDrivingLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showDrivingLicenseInfoToolStripMenuItem_Click);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Image = global::DVLDInterface.Properties.Resources.PersonLicenseHistory_321;
            this.showLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(354, 40);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter By:";
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Items.AddRange(new object[] {
            "None",
            "App ID",
            "National No",
            "Full Name",
            "Status"});
            this.FilterComboBox.Location = new System.Drawing.Point(227, 312);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(293, 27);
            this.FilterComboBox.TabIndex = 6;
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // txtboxSearch
            // 
            this.txtboxSearch.FormattingEnabled = true;
            this.txtboxSearch.Location = new System.Drawing.Point(543, 312);
            this.txtboxSearch.Name = "txtboxSearch";
            this.txtboxSearch.Size = new System.Drawing.Size(276, 27);
            this.txtboxSearch.TabIndex = 7;
            this.txtboxSearch.SelectedIndexChanged += new System.EventHandler(this.txtboxSearch_SelectedIndexChanged);
            this.txtboxSearch.TextChanged += new System.EventHandler(this.txtboxSearch_TextChanged_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Image = global::DVLDInterface.Properties.Resources.New_Application_64;
            this.button1.Location = new System.Drawing.Point(1147, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 89);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDInterface.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(795, 69);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDInterface.Properties.Resources.Applications1;
            this.pictureBox1.Location = new System.Drawing.Point(516, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // LocalDrivingLicenseApplicationsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 800);
            this.Controls.Add(this.txtboxSearch);
            this.Controls.Add(this.FilterComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "LocalDrivingLicenseApplicationsScreen";
            this.Text = "LocalDrivingLicenseApplicationsScreen";
            this.Load += new System.EventHandler(this.LocalDrivingLicenseApplicationsScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.ComboBox txtboxSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWriteTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDrivingLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
    }
}