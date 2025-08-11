namespace DVLDInterface
{
    partial class ShowLicenseHistory
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
            this.ctrlSearchForPersonByFilter1 = new DVLDInterface.ctrlSearchForPersonByFilter();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlSearchForPersonByFilter1
            // 
            this.ctrlSearchForPersonByFilter1.Location = new System.Drawing.Point(68, 93);
            this.ctrlSearchForPersonByFilter1.Name = "ctrlSearchForPersonByFilter1";
            this.ctrlSearchForPersonByFilter1.PersonID = 0;
            this.ctrlSearchForPersonByFilter1.Size = new System.Drawing.Size(1016, 511);
            this.ctrlSearchForPersonByFilter1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(443, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "License History";
            // 
            // ShowLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 604);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlSearchForPersonByFilter1);
            this.Name = "ShowLicenseHistory";
            this.Text = "ShowLicenseHistory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlSearchForPersonByFilter ctrlSearchForPersonByFilter1;
        private System.Windows.Forms.Label label1;
    }
}