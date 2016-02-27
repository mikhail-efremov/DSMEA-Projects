namespace SimpleHotelApp
{
    partial class RoomsAdderForm
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
            this.currentRoomTextBox = new System.Windows.Forms.TextBox();
            this.changeRoomButton = new System.Windows.Forms.Button();
            this.guestJsonLabel = new System.Windows.Forms.Label();
            this.labelActiveRole = new System.Windows.Forms.Label();
            this.infoLabelActiveRole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current room:";
            // 
            // currentRoomTextBox
            // 
            this.currentRoomTextBox.Location = new System.Drawing.Point(85, 216);
            this.currentRoomTextBox.Name = "currentRoomTextBox";
            this.currentRoomTextBox.ReadOnly = true;
            this.currentRoomTextBox.Size = new System.Drawing.Size(100, 20);
            this.currentRoomTextBox.TabIndex = 1;
            // 
            // changeRoomButton
            // 
            this.changeRoomButton.Location = new System.Drawing.Point(12, 264);
            this.changeRoomButton.Name = "changeRoomButton";
            this.changeRoomButton.Size = new System.Drawing.Size(75, 23);
            this.changeRoomButton.TabIndex = 2;
            this.changeRoomButton.Text = "Change";
            this.changeRoomButton.UseVisualStyleBackColor = true;
            this.changeRoomButton.Click += new System.EventHandler(this.changeRoomButton_Click);
            // 
            // guestJsonLabel
            // 
            this.guestJsonLabel.AutoSize = true;
            this.guestJsonLabel.Location = new System.Drawing.Point(81, 31);
            this.guestJsonLabel.Name = "guestJsonLabel";
            this.guestJsonLabel.Size = new System.Drawing.Size(35, 13);
            this.guestJsonLabel.TabIndex = 3;
            this.guestJsonLabel.Text = "empty";
            // 
            // labelActiveRole
            // 
            this.labelActiveRole.AutoSize = true;
            this.labelActiveRole.Location = new System.Drawing.Point(80, 9);
            this.labelActiveRole.Name = "labelActiveRole";
            this.labelActiveRole.Size = new System.Drawing.Size(81, 13);
            this.labelActiveRole.TabIndex = 8;
            this.labelActiveRole.Text = "labelActiveRole";
            // 
            // infoLabelActiveRole
            // 
            this.infoLabelActiveRole.AutoSize = true;
            this.infoLabelActiveRole.Location = new System.Drawing.Point(9, 9);
            this.infoLabelActiveRole.Name = "infoLabelActiveRole";
            this.infoLabelActiveRole.Size = new System.Drawing.Size(65, 13);
            this.infoLabelActiveRole.TabIndex = 7;
            this.infoLabelActiveRole.Text = "Active Role:";
            // 
            // RoomsAdderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 345);
            this.Controls.Add(this.labelActiveRole);
            this.Controls.Add(this.infoLabelActiveRole);
            this.Controls.Add(this.guestJsonLabel);
            this.Controls.Add(this.changeRoomButton);
            this.Controls.Add(this.currentRoomTextBox);
            this.Controls.Add(this.label1);
            this.Name = "RoomsAdderForm";
            this.Text = "RoomsAdderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentRoomTextBox;
        private System.Windows.Forms.Button changeRoomButton;
        private System.Windows.Forms.Label guestJsonLabel;
        private System.Windows.Forms.Label labelActiveRole;
        private System.Windows.Forms.Label infoLabelActiveRole;
    }
}