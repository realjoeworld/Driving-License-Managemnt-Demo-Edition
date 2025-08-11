namespace DVLDInterface
{
    partial class ShowUserDetails
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
            this.ctrlShowPersonDetails1 = new DVLDInterface.ctrlShowPersonDetails();
            this.ctrlLoginInfo1 = new DVLDInterface.ctrlLoginInfo();
            this.SuspendLayout();
            // 
            // ctrlShowPersonDetails1
            // 
            this.ctrlShowPersonDetails1.ID = 0;
            this.ctrlShowPersonDetails1.Location = new System.Drawing.Point(12, 21);
            this.ctrlShowPersonDetails1.Name = "ctrlShowPersonDetails1";
            this.ctrlShowPersonDetails1.Size = new System.Drawing.Size(1010, 319);
            this.ctrlShowPersonDetails1.TabIndex = 0;
            // 
            // ctrlLoginInfo1
            // 
            this.ctrlLoginInfo1.Location = new System.Drawing.Point(115, 363);
            this.ctrlLoginInfo1.Name = "ctrlLoginInfo1";
            this.ctrlLoginInfo1.Size = new System.Drawing.Size(815, 134);
            this.ctrlLoginInfo1.TabIndex = 1;
            // 
            // ShowUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 488);
            this.Controls.Add(this.ctrlLoginInfo1);
            this.Controls.Add(this.ctrlShowPersonDetails1);
            this.Name = "ShowUserDetails";
            this.Text = "ChangePasswordScreen";
            this.Load += new System.EventHandler(this.ChangePasswordScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowPersonDetails ctrlShowPersonDetails1;
        private ctrlLoginInfo ctrlLoginInfo1;
    }
}