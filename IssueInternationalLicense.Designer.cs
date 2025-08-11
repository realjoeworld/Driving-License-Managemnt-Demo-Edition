namespace DVLDInterface
{
    partial class IssueInternationalLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.linklblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.linklblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlInternationalApplicationInfo1 = new DVLDInterface.ctrlInternationalApplicationInfo();
            this.ctrlSearchDriverLicense1 = new DVLDInterface.ctrlSearchDriverLicense();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(324, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "International License Application";
            // 
            // linklblShowLicenseHistory
            // 
            this.linklblShowLicenseHistory.AutoSize = true;
            this.linklblShowLicenseHistory.Enabled = false;
            this.linklblShowLicenseHistory.Location = new System.Drawing.Point(37, 885);
            this.linklblShowLicenseHistory.Name = "linklblShowLicenseHistory";
            this.linklblShowLicenseHistory.Size = new System.Drawing.Size(159, 19);
            this.linklblShowLicenseHistory.TabIndex = 3;
            this.linklblShowLicenseHistory.TabStop = true;
            this.linklblShowLicenseHistory.Text = "Show License History";
            this.linklblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseHistory_LinkClicked);
            // 
            // linklblShowLicenseInfo
            // 
            this.linklblShowLicenseInfo.AutoSize = true;
            this.linklblShowLicenseInfo.Enabled = false;
            this.linklblShowLicenseInfo.Location = new System.Drawing.Point(221, 885);
            this.linklblShowLicenseInfo.Name = "linklblShowLicenseInfo";
            this.linklblShowLicenseInfo.Size = new System.Drawing.Size(138, 19);
            this.linklblShowLicenseInfo.TabIndex = 4;
            this.linklblShowLicenseInfo.TabStop = true;
            this.linklblShowLicenseInfo.Text = "Show License Info";
            this.linklblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseInfo_LinkClicked);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.White;
            this.btnIssue.Enabled = false;
            this.btnIssue.Image = global::DVLDInterface.Properties.Resources.International_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(846, 871);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(146, 47);
            this.btnIssue.TabIndex = 79;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Image = global::DVLDInterface.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(672, 871);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 47);
            this.btnClose.TabIndex = 78;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlInternationalApplicationInfo1
            // 
            this.ctrlInternationalApplicationInfo1.Fees = 50;
            this.ctrlInternationalApplicationInfo1.Location = new System.Drawing.Point(21, 576);
            this.ctrlInternationalApplicationInfo1.Name = "ctrlInternationalApplicationInfo1";
            this.ctrlInternationalApplicationInfo1.Size = new System.Drawing.Size(1061, 276);
            this.ctrlInternationalApplicationInfo1.TabIndex = 2;
            // 
            // ctrlSearchDriverLicense1
            // 
            this.ctrlSearchDriverLicense1.IsFound = false;
            this.ctrlSearchDriverLicense1.LocalLicenseID = 0;
            this.ctrlSearchDriverLicense1.Location = new System.Drawing.Point(21, 62);
            this.ctrlSearchDriverLicense1.Name = "ctrlSearchDriverLicense1";
            this.ctrlSearchDriverLicense1.Size = new System.Drawing.Size(1066, 528);
            this.ctrlSearchDriverLicense1.TabIndex = 0;
            this.ctrlSearchDriverLicense1.OnSearchComplete += new System.Action<int>(this.ctrlSearchDriverLicense1_OnSearchComplete);
            // 
            // IssueInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 939);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.linklblShowLicenseInfo);
            this.Controls.Add(this.linklblShowLicenseHistory);
            this.Controls.Add(this.ctrlInternationalApplicationInfo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlSearchDriverLicense1);
            this.Name = "IssueInternationalLicense";
            this.Text = "IssueInternationalLicense";
            this.Load += new System.EventHandler(this.IssueInternationalLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlSearchDriverLicense ctrlSearchDriverLicense1;
        private System.Windows.Forms.Label label1;
        private ctrlInternationalApplicationInfo ctrlInternationalApplicationInfo1;
        private System.Windows.Forms.LinkLabel linklblShowLicenseHistory;
        private System.Windows.Forms.LinkLabel linklblShowLicenseInfo;
        protected System.Windows.Forms.Button btnIssue;
        protected System.Windows.Forms.Button btnClose;
    }
}