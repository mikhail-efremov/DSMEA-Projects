namespace SimpleHotelApp.Utils
{
    partial class GuestFillForm
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
            this.buttonGuestReturn = new System.Windows.Forms.Button();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelSecondName = new System.Windows.Forms.Label();
            this.labelDateOfBirth = new System.Windows.Forms.Label();
            this.labelPassportCode = new System.Windows.Forms.Label();
            this.labelCitizenship = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxSecondName = new System.Windows.Forms.TextBox();
            this.textBoxDateOfBirth = new System.Windows.Forms.TextBox();
            this.textBoxPassportCode = new System.Windows.Forms.TextBox();
            this.textBoxCitizenship = new System.Windows.Forms.TextBox();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGuestReturn
            // 
            this.buttonGuestReturn.Location = new System.Drawing.Point(12, 227);
            this.buttonGuestReturn.Name = "buttonGuestReturn";
            this.buttonGuestReturn.Size = new System.Drawing.Size(82, 23);
            this.buttonGuestReturn.TabIndex = 0;
            this.buttonGuestReturn.Text = "Return guest";
            this.buttonGuestReturn.UseVisualStyleBackColor = true;
            this.buttonGuestReturn.Click += new System.EventHandler(this.buttonGuestReturn_Click);
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(13, 20);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(54, 13);
            this.labelFirstName.TabIndex = 1;
            this.labelFirstName.Text = "FirstName";
            // 
            // labelSecondName
            // 
            this.labelSecondName.AutoSize = true;
            this.labelSecondName.Location = new System.Drawing.Point(13, 46);
            this.labelSecondName.Name = "labelSecondName";
            this.labelSecondName.Size = new System.Drawing.Size(72, 13);
            this.labelSecondName.TabIndex = 2;
            this.labelSecondName.Text = "SecondName";
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.AutoSize = true;
            this.labelDateOfBirth.Location = new System.Drawing.Point(13, 72);
            this.labelDateOfBirth.Name = "labelDateOfBirth";
            this.labelDateOfBirth.Size = new System.Drawing.Size(62, 13);
            this.labelDateOfBirth.TabIndex = 3;
            this.labelDateOfBirth.Text = "DateOfBirth";
            // 
            // labelPassportCode
            // 
            this.labelPassportCode.AutoSize = true;
            this.labelPassportCode.Location = new System.Drawing.Point(13, 98);
            this.labelPassportCode.Name = "labelPassportCode";
            this.labelPassportCode.Size = new System.Drawing.Size(73, 13);
            this.labelPassportCode.TabIndex = 4;
            this.labelPassportCode.Text = "PassportCode";
            // 
            // labelCitizenship
            // 
            this.labelCitizenship.AutoSize = true;
            this.labelCitizenship.Location = new System.Drawing.Point(13, 124);
            this.labelCitizenship.Name = "labelCitizenship";
            this.labelCitizenship.Size = new System.Drawing.Size(57, 13);
            this.labelCitizenship.TabIndex = 5;
            this.labelCitizenship.Text = "Citizenship";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(13, 150);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(48, 13);
            this.labelLocation.TabIndex = 6;
            this.labelLocation.Text = "Location";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(127, 13);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFirstName.TabIndex = 7;
            // 
            // textBoxSecondName
            // 
            this.textBoxSecondName.Location = new System.Drawing.Point(127, 39);
            this.textBoxSecondName.Name = "textBoxSecondName";
            this.textBoxSecondName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSecondName.TabIndex = 8;
            // 
            // textBoxDateOfBirth
            // 
            this.textBoxDateOfBirth.Location = new System.Drawing.Point(127, 65);
            this.textBoxDateOfBirth.Name = "textBoxDateOfBirth";
            this.textBoxDateOfBirth.Size = new System.Drawing.Size(100, 20);
            this.textBoxDateOfBirth.TabIndex = 9;
            // 
            // textBoxPassportCode
            // 
            this.textBoxPassportCode.Location = new System.Drawing.Point(127, 91);
            this.textBoxPassportCode.Name = "textBoxPassportCode";
            this.textBoxPassportCode.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassportCode.TabIndex = 10;
            // 
            // textBoxCitizenship
            // 
            this.textBoxCitizenship.Location = new System.Drawing.Point(127, 117);
            this.textBoxCitizenship.Name = "textBoxCitizenship";
            this.textBoxCitizenship.Size = new System.Drawing.Size(100, 20);
            this.textBoxCitizenship.TabIndex = 11;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(127, 143);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(100, 20);
            this.textBoxLocation.TabIndex = 12;
            // 
            // GuestFillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.textBoxCitizenship);
            this.Controls.Add(this.textBoxPassportCode);
            this.Controls.Add(this.textBoxDateOfBirth);
            this.Controls.Add(this.textBoxSecondName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelCitizenship);
            this.Controls.Add(this.labelPassportCode);
            this.Controls.Add(this.labelDateOfBirth);
            this.Controls.Add(this.labelSecondName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.buttonGuestReturn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GuestFillForm";
            this.Text = "GuestFill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGuestReturn;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelSecondName;
        private System.Windows.Forms.Label labelDateOfBirth;
        private System.Windows.Forms.Label labelPassportCode;
        private System.Windows.Forms.Label labelCitizenship;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxSecondName;
        private System.Windows.Forms.TextBox textBoxDateOfBirth;
        private System.Windows.Forms.TextBox textBoxPassportCode;
        private System.Windows.Forms.TextBox textBoxCitizenship;
        private System.Windows.Forms.TextBox textBoxLocation;
    }
}