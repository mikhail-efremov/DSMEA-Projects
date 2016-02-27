namespace SimpleHotelApp
{
    partial class GuestAdderToRoomForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelActiveRole = new System.Windows.Forms.Label();
            this.infoLabelActiveRole = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(610, 217);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelActiveRole
            // 
            this.labelActiveRole.AutoSize = true;
            this.labelActiveRole.Location = new System.Drawing.Point(83, 9);
            this.labelActiveRole.Name = "labelActiveRole";
            this.labelActiveRole.Size = new System.Drawing.Size(81, 13);
            this.labelActiveRole.TabIndex = 10;
            this.labelActiveRole.Text = "labelActiveRole";
            // 
            // infoLabelActiveRole
            // 
            this.infoLabelActiveRole.AutoSize = true;
            this.infoLabelActiveRole.Location = new System.Drawing.Point(12, 9);
            this.infoLabelActiveRole.Name = "infoLabelActiveRole";
            this.infoLabelActiveRole.Size = new System.Drawing.Size(65, 13);
            this.infoLabelActiveRole.TabIndex = 9;
            this.infoLabelActiveRole.Text = "Active Role:";
            // 
            // GuestAdderToRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 332);
            this.Controls.Add(this.labelActiveRole);
            this.Controls.Add(this.infoLabelActiveRole);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GuestAdderToRoomForm";
            this.Text = "GuestAdderToRoomForm";
            this.Load += new System.EventHandler(this.GuestAdderToRoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelActiveRole;
        private System.Windows.Forms.Label infoLabelActiveRole;
    }
}