﻿namespace SimpleHotelApp
{
    partial class GuestsForm
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
            this.buttonSaveDB = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonResetFilter = new System.Windows.Forms.Button();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(887, 149);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonSaveDB
            // 
            this.buttonSaveDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveDB.Location = new System.Drawing.Point(12, 167);
            this.buttonSaveDB.Name = "buttonSaveDB";
            this.buttonSaveDB.Size = new System.Drawing.Size(88, 23);
            this.buttonSaveDB.TabIndex = 3;
            this.buttonSaveDB.Text = "Save in base";
            this.buttonSaveDB.UseVisualStyleBackColor = true;
            this.buttonSaveDB.Click += new System.EventHandler(this.buttonSaveDB_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(117, 167);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 4;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonResetFilter
            // 
            this.buttonResetFilter.Location = new System.Drawing.Point(199, 167);
            this.buttonResetFilter.Name = "buttonResetFilter";
            this.buttonResetFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonResetFilter.TabIndex = 5;
            this.buttonResetFilter.Text = "Reset filter";
            this.buttonResetFilter.UseVisualStyleBackColor = true;
            this.buttonResetFilter.Click += new System.EventHandler(this.buttonResetFilter_Click);
            // 
            // GuestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 202);
            this.Controls.Add(this.buttonResetFilter);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.buttonSaveDB);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GuestsForm";
            this.Text = "GuestsForm";
            this.Load += new System.EventHandler(this.GuestsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSaveDB;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonResetFilter;
    }
}