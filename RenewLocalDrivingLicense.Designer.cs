namespace DVLDInterface
{
    partial class RenewLocalDrivingLicense
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
            this.ctrlSearchDriverLicense1 = new DVLDInterface.ctrlSearchDriverLicense();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtboxNotes = new System.Windows.Forms.TextBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRenewLicenseID = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linklblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.linklblShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlSearchDriverLicense1
            // 
            this.ctrlSearchDriverLicense1.ApplicationID = 0;
            this.ctrlSearchDriverLicense1.DriverID = 0;
            this.ctrlSearchDriverLicense1.ExpirationDate = new System.DateTime(((long)(0)));
            this.ctrlSearchDriverLicense1.IsFound = false;
            this.ctrlSearchDriverLicense1.LocalLicenseID = 0;
            this.ctrlSearchDriverLicense1.Location = new System.Drawing.Point(12, 46);
            this.ctrlSearchDriverLicense1.Name = "ctrlSearchDriverLicense1";
            this.ctrlSearchDriverLicense1.Size = new System.Drawing.Size(1032, 507);
            this.ctrlSearchDriverLicense1.TabIndex = 0;
            this.ctrlSearchDriverLicense1.OnSearchComplete += new System.Action<int>(this.ctrlSearchDriverLicense1_OnSearchComplete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(376, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Renew License Application";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtboxNotes);
            this.groupBox1.Controls.Add(this.pictureBox11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.pictureBox10);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblApplicationFees);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblExpirationDate);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblIssueDate);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblOldLicenseID);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblApplicationDate);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblRenewLicenseID);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblApplicationID);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 559);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1031, 332);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application New License Info";
            // 
            // txtboxNotes
            // 
            this.txtboxNotes.Location = new System.Drawing.Point(260, 290);
            this.txtboxNotes.Multiline = true;
            this.txtboxNotes.Name = "txtboxNotes";
            this.txtboxNotes.Size = new System.Drawing.Size(743, 41);
            this.txtboxNotes.TabIndex = 32;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::DVLDInterface.Properties.Resources.Notes_32;
            this.pictureBox11.Location = new System.Drawing.Point(206, 289);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(39, 34);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 31;
            this.pictureBox11.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(136, 289);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 19);
            this.label14.TabIndex = 30;
            this.label14.Text = "Notes:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(739, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 19);
            this.label11.TabIndex = 29;
            this.label11.Text = "27";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLDInterface.Properties.Resources.money_32;
            this.pictureBox10.Location = new System.Drawing.Point(678, 236);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(39, 34);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 28;
            this.pictureBox10.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(565, 242);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 19);
            this.label13.TabIndex = 27;
            this.label13.Text = "Total Fees:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(730, 199);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(50, 19);
            this.lblCreatedBy.TabIndex = 26;
            this.lblCreatedBy.Text = "[???]";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLDInterface.Properties.Resources.User_32__2;
            this.pictureBox9.Location = new System.Drawing.Point(676, 193);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(39, 34);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 25;
            this.pictureBox9.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(565, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 19);
            this.label12.TabIndex = 24;
            this.label12.Text = "Created By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(267, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "20";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLDInterface.Properties.Resources.money_32;
            this.pictureBox8.Location = new System.Drawing.Point(206, 236);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(39, 34);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 22;
            this.pictureBox8.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(81, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 19);
            this.label10.TabIndex = 21;
            this.label10.Text = "License Fees:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(267, 199);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(19, 19);
            this.lblApplicationFees.TabIndex = 20;
            this.lblApplicationFees.Text = "7";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLDInterface.Properties.Resources.money_32;
            this.pictureBox7.Location = new System.Drawing.Point(206, 193);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(39, 34);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 19;
            this.pictureBox7.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(49, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "Application Fees:";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDate.Location = new System.Drawing.Point(730, 149);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(50, 19);
            this.lblExpirationDate.TabIndex = 17;
            this.lblExpirationDate.Text = "[???]";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLDInterface.Properties.Resources.Calendar_32;
            this.pictureBox6.Location = new System.Drawing.Point(676, 143);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(39, 34);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 16;
            this.pictureBox6.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(527, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Expiration Date:";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(267, 149);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(50, 19);
            this.lblIssueDate.TabIndex = 14;
            this.lblIssueDate.Text = "[???]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLDInterface.Properties.Resources.Calendar_32;
            this.pictureBox5.Location = new System.Drawing.Point(206, 143);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(39, 34);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(98, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Issue Date:";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(730, 102);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(50, 19);
            this.lblOldLicenseID.TabIndex = 11;
            this.lblOldLicenseID.Text = "[???]";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLDInterface.Properties.Resources.Driver_License_48;
            this.pictureBox4.Location = new System.Drawing.Point(676, 96);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(39, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(539, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Old License ID:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(267, 96);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(50, 19);
            this.lblApplicationDate.TabIndex = 8;
            this.lblApplicationDate.Text = "[???]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLDInterface.Properties.Resources.Calendar_32;
            this.pictureBox3.Location = new System.Drawing.Point(206, 90);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Application Date:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblRenewLicenseID
            // 
            this.lblRenewLicenseID.AutoSize = true;
            this.lblRenewLicenseID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewLicenseID.Location = new System.Drawing.Point(730, 45);
            this.lblRenewLicenseID.Name = "lblRenewLicenseID";
            this.lblRenewLicenseID.Size = new System.Drawing.Size(50, 19);
            this.lblRenewLicenseID.TabIndex = 5;
            this.lblRenewLicenseID.Text = "[???]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDInterface.Properties.Resources.Renew_Driving_License_321;
            this.pictureBox2.Location = new System.Drawing.Point(676, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(510, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Renew License ID:";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(267, 45);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(50, 19);
            this.lblApplicationID.TabIndex = 2;
            this.lblApplicationID.Text = "[???]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDInterface.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(206, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "R.L.Application ID:";
            // 
            // linklblShowLicenseHistory
            // 
            this.linklblShowLicenseHistory.AutoSize = true;
            this.linklblShowLicenseHistory.Enabled = false;
            this.linklblShowLicenseHistory.Location = new System.Drawing.Point(62, 911);
            this.linklblShowLicenseHistory.Name = "linklblShowLicenseHistory";
            this.linklblShowLicenseHistory.Size = new System.Drawing.Size(159, 19);
            this.linklblShowLicenseHistory.TabIndex = 3;
            this.linklblShowLicenseHistory.TabStop = true;
            this.linklblShowLicenseHistory.Text = "Show License History";
            this.linklblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseHistory_LinkClicked);
            // 
            // linklblShowNewLicenseInfo
            // 
            this.linklblShowNewLicenseInfo.AutoSize = true;
            this.linklblShowNewLicenseInfo.Enabled = false;
            this.linklblShowNewLicenseInfo.Location = new System.Drawing.Point(238, 911);
            this.linklblShowNewLicenseInfo.Name = "linklblShowNewLicenseInfo";
            this.linklblShowNewLicenseInfo.Size = new System.Drawing.Size(174, 19);
            this.linklblShowNewLicenseInfo.TabIndex = 4;
            this.linklblShowNewLicenseInfo.TabStop = true;
            this.linklblShowNewLicenseInfo.Text = "Show New License Info";
            this.linklblShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowNewLicenseInfo_LinkClicked);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.White;
            this.btnIssue.Enabled = false;
            this.btnIssue.Image = global::DVLDInterface.Properties.Resources.Renew_Driving_License_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(863, 896);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(146, 47);
            this.btnIssue.TabIndex = 81;
            this.btnIssue.Text = "Renew";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Image = global::DVLDInterface.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(689, 896);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 47);
            this.btnClose.TabIndex = 80;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RenewLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 947);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.linklblShowNewLicenseInfo);
            this.Controls.Add(this.linklblShowLicenseHistory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlSearchDriverLicense1);
            this.Name = "RenewLocalDrivingLicense";
            this.Text = "RenewLocalDrivingLicense";
            this.Load += new System.EventHandler(this.RenewLocalDrivingLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlSearchDriverLicense ctrlSearchDriverLicense1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRenewLicenseID;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel linklblShowLicenseHistory;
        private System.Windows.Forms.TextBox txtboxNotes;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel linklblShowNewLicenseInfo;
        protected System.Windows.Forms.Button btnIssue;
        protected System.Windows.Forms.Button btnClose;
    }
}