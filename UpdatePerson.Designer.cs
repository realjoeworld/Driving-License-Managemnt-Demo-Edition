namespace DVLDInterface
{
    partial class UpdatePerson
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
            this.lblID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlUpdatePerson1 = new DVLDInterface.ctrlUpdatePerson();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(214, 99);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(51, 24);
            this.lblID.TabIndex = 7;
            this.lblID.Text = "N/A";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDInterface.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(147, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Person ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(469, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Update Person";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 61);
            this.panel1.TabIndex = 10;
            // 
            // ctrlUpdatePerson1
            // 
            this.ctrlUpdatePerson1.ImagePath = null;
            this.ctrlUpdatePerson1.Location = new System.Drawing.Point(12, 138);
            this.ctrlUpdatePerson1.Name = "ctrlUpdatePerson1";
            this.ctrlUpdatePerson1.PersonID = 0;
            this.ctrlUpdatePerson1.PreviousNationalNo = null;
            this.ctrlUpdatePerson1.Size = new System.Drawing.Size(1061, 528);
            this.ctrlUpdatePerson1.TabIndex = 8;
            this.ctrlUpdatePerson1.OnSaveCompleted += new System.Action<object>(this.ctrlUpdatePerson1_OnSaveCompleted);
            this.ctrlUpdatePerson1.OnCloseCompleted += new System.Action<object>(this.ctrlUpdatePerson1_OnCloseCompleted);
            this.ctrlUpdatePerson1.Load += new System.EventHandler(this.ctrlUpdatePerson1_Load);
            // 
            // UpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 670);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctrlUpdatePerson1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "UpdatePerson";
            this.Text = "UpdatePerson";
            this.Load += new System.EventHandler(this.UpdatePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ctrlUpdatePerson ctrlUpdatePerson1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}