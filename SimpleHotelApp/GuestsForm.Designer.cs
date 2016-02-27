namespace SimpleHotelApp
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
            this.labelId = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelSecondName = new System.Windows.Forms.Label();
            this.labelDateOfBirth = new System.Windows.Forms.Label();
            this.labelPassportCode = new System.Windows.Forms.Label();
            this.labelCitizenship = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelSettlementDate = new System.Windows.Forms.Label();
            this.labelDepartureDate = new System.Windows.Forms.Label();
            this.labelPayMoney = new System.Windows.Forms.Label();
            this.filterId = new System.Windows.Forms.TextBox();
            this.filterFirstName = new System.Windows.Forms.TextBox();
            this.filterSecondName = new System.Windows.Forms.TextBox();
            this.filterDateOfBirth = new System.Windows.Forms.TextBox();
            this.filterPassCode = new System.Windows.Forms.TextBox();
            this.filterCitizenship = new System.Windows.Forms.TextBox();
            this.filterLocation = new System.Windows.Forms.TextBox();
            this.filterSettlementDate = new System.Windows.Forms.TextBox();
            this.filterDepartDate = new System.Windows.Forms.TextBox();
            this.filterPayMoney = new System.Windows.Forms.TextBox();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(887, 254);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // buttonSaveDB
            // 
            this.buttonSaveDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveDB.Location = new System.Drawing.Point(10, 284);
            this.buttonSaveDB.Name = "buttonSaveDB";
            this.buttonSaveDB.Size = new System.Drawing.Size(85, 23);
            this.buttonSaveDB.TabIndex = 3;
            this.buttonSaveDB.Text = "Save in base";
            this.buttonSaveDB.UseVisualStyleBackColor = true;
            this.buttonSaveDB.Click += new System.EventHandler(this.buttonSaveDB_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFilter.Location = new System.Drawing.Point(101, 284);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 4;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonResetFilter
            // 
            this.buttonResetFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonResetFilter.Location = new System.Drawing.Point(182, 284);
            this.buttonResetFilter.Name = "buttonResetFilter";
            this.buttonResetFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonResetFilter.TabIndex = 5;
            this.buttonResetFilter.Text = "Reset filter";
            this.buttonResetFilter.UseVisualStyleBackColor = true;
            this.buttonResetFilter.Click += new System.EventHandler(this.buttonResetFilter_Click);
            // 
            // labelId
            // 
            this.labelId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(12, 319);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 6;
            this.labelId.Text = "Id";
            // 
            // labelFirstName
            // 
            this.labelFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(63, 319);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(54, 13);
            this.labelFirstName.TabIndex = 7;
            this.labelFirstName.Text = "FirstName";
            // 
            // labelSecondName
            // 
            this.labelSecondName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSecondName.AutoSize = true;
            this.labelSecondName.Location = new System.Drawing.Point(142, 319);
            this.labelSecondName.Name = "labelSecondName";
            this.labelSecondName.Size = new System.Drawing.Size(72, 13);
            this.labelSecondName.TabIndex = 8;
            this.labelSecondName.Text = "SecondName";
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDateOfBirth.AutoSize = true;
            this.labelDateOfBirth.Location = new System.Drawing.Point(240, 319);
            this.labelDateOfBirth.Name = "labelDateOfBirth";
            this.labelDateOfBirth.Size = new System.Drawing.Size(62, 13);
            this.labelDateOfBirth.TabIndex = 9;
            this.labelDateOfBirth.Text = "DateOfBirth";
            // 
            // labelPassportCode
            // 
            this.labelPassportCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPassportCode.AutoSize = true;
            this.labelPassportCode.Location = new System.Drawing.Point(332, 319);
            this.labelPassportCode.Name = "labelPassportCode";
            this.labelPassportCode.Size = new System.Drawing.Size(73, 13);
            this.labelPassportCode.TabIndex = 10;
            this.labelPassportCode.Text = "PassportCode";
            // 
            // labelCitizenship
            // 
            this.labelCitizenship.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCitizenship.AutoSize = true;
            this.labelCitizenship.Location = new System.Drawing.Point(429, 319);
            this.labelCitizenship.Name = "labelCitizenship";
            this.labelCitizenship.Size = new System.Drawing.Size(57, 13);
            this.labelCitizenship.TabIndex = 11;
            this.labelCitizenship.Text = "Citizenship";
            // 
            // labelLocation
            // 
            this.labelLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(507, 319);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(48, 13);
            this.labelLocation.TabIndex = 12;
            this.labelLocation.Text = "Location";
            // 
            // labelSettlementDate
            // 
            this.labelSettlementDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSettlementDate.AutoSize = true;
            this.labelSettlementDate.Location = new System.Drawing.Point(585, 319);
            this.labelSettlementDate.Name = "labelSettlementDate";
            this.labelSettlementDate.Size = new System.Drawing.Size(80, 13);
            this.labelSettlementDate.TabIndex = 13;
            this.labelSettlementDate.Text = "SettlementDate";
            // 
            // labelDepartureDate
            // 
            this.labelDepartureDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDepartureDate.AutoSize = true;
            this.labelDepartureDate.Location = new System.Drawing.Point(691, 319);
            this.labelDepartureDate.Name = "labelDepartureDate";
            this.labelDepartureDate.Size = new System.Drawing.Size(77, 13);
            this.labelDepartureDate.TabIndex = 14;
            this.labelDepartureDate.Text = "DepartureDate";
            // 
            // labelPayMoney
            // 
            this.labelPayMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPayMoney.AutoSize = true;
            this.labelPayMoney.Location = new System.Drawing.Point(799, 319);
            this.labelPayMoney.Name = "labelPayMoney";
            this.labelPayMoney.Size = new System.Drawing.Size(57, 13);
            this.labelPayMoney.TabIndex = 15;
            this.labelPayMoney.Text = "PayMoney";
            // 
            // filterId
            // 
            this.filterId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterId.Location = new System.Drawing.Point(15, 336);
            this.filterId.Name = "filterId";
            this.filterId.Size = new System.Drawing.Size(45, 20);
            this.filterId.TabIndex = 16;
            // 
            // filterFirstName
            // 
            this.filterFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterFirstName.Location = new System.Drawing.Point(66, 335);
            this.filterFirstName.Name = "filterFirstName";
            this.filterFirstName.Size = new System.Drawing.Size(73, 20);
            this.filterFirstName.TabIndex = 17;
            // 
            // filterSecondName
            // 
            this.filterSecondName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterSecondName.Location = new System.Drawing.Point(145, 335);
            this.filterSecondName.Name = "filterSecondName";
            this.filterSecondName.Size = new System.Drawing.Size(92, 20);
            this.filterSecondName.TabIndex = 18;
            // 
            // filterDateOfBirth
            // 
            this.filterDateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterDateOfBirth.Location = new System.Drawing.Point(243, 335);
            this.filterDateOfBirth.Name = "filterDateOfBirth";
            this.filterDateOfBirth.Size = new System.Drawing.Size(86, 20);
            this.filterDateOfBirth.TabIndex = 19;
            // 
            // filterPassCode
            // 
            this.filterPassCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterPassCode.Location = new System.Drawing.Point(335, 335);
            this.filterPassCode.Name = "filterPassCode";
            this.filterPassCode.Size = new System.Drawing.Size(91, 20);
            this.filterPassCode.TabIndex = 20;
            // 
            // filterCitizenship
            // 
            this.filterCitizenship.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterCitizenship.Location = new System.Drawing.Point(432, 335);
            this.filterCitizenship.Name = "filterCitizenship";
            this.filterCitizenship.Size = new System.Drawing.Size(72, 20);
            this.filterCitizenship.TabIndex = 21;
            // 
            // filterLocation
            // 
            this.filterLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterLocation.Location = new System.Drawing.Point(510, 335);
            this.filterLocation.Name = "filterLocation";
            this.filterLocation.Size = new System.Drawing.Size(72, 20);
            this.filterLocation.TabIndex = 22;
            // 
            // filterSettlementDate
            // 
            this.filterSettlementDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterSettlementDate.Location = new System.Drawing.Point(588, 335);
            this.filterSettlementDate.Name = "filterSettlementDate";
            this.filterSettlementDate.Size = new System.Drawing.Size(100, 20);
            this.filterSettlementDate.TabIndex = 23;
            // 
            // filterDepartDate
            // 
            this.filterDepartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterDepartDate.Location = new System.Drawing.Point(694, 336);
            this.filterDepartDate.Name = "filterDepartDate";
            this.filterDepartDate.Size = new System.Drawing.Size(102, 20);
            this.filterDepartDate.TabIndex = 24;
            // 
            // filterPayMoney
            // 
            this.filterPayMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterPayMoney.Location = new System.Drawing.Point(802, 335);
            this.filterPayMoney.Name = "filterPayMoney";
            this.filterPayMoney.Size = new System.Drawing.Size(97, 20);
            this.filterPayMoney.TabIndex = 25;
            // 
            // labelActiveRole
            // 
            this.labelActiveRole.AutoSize = true;
            this.labelActiveRole.Location = new System.Drawing.Point(83, 9);
            this.labelActiveRole.Name = "labelActiveRole";
            this.labelActiveRole.Size = new System.Drawing.Size(81, 13);
            this.labelActiveRole.TabIndex = 27;
            this.labelActiveRole.Text = "labelActiveRole";
            // 
            // infoLabelActiveRole
            // 
            this.infoLabelActiveRole.AutoSize = true;
            this.infoLabelActiveRole.Location = new System.Drawing.Point(12, 9);
            this.infoLabelActiveRole.Name = "infoLabelActiveRole";
            this.infoLabelActiveRole.Size = new System.Drawing.Size(65, 13);
            this.infoLabelActiveRole.TabIndex = 26;
            this.infoLabelActiveRole.Text = "Active Role:";
            // 
            // GuestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 365);
            this.Controls.Add(this.labelActiveRole);
            this.Controls.Add(this.infoLabelActiveRole);
            this.Controls.Add(this.filterPayMoney);
            this.Controls.Add(this.filterDepartDate);
            this.Controls.Add(this.filterSettlementDate);
            this.Controls.Add(this.filterLocation);
            this.Controls.Add(this.filterCitizenship);
            this.Controls.Add(this.filterPassCode);
            this.Controls.Add(this.filterDateOfBirth);
            this.Controls.Add(this.filterSecondName);
            this.Controls.Add(this.filterFirstName);
            this.Controls.Add(this.filterId);
            this.Controls.Add(this.labelPayMoney);
            this.Controls.Add(this.labelDepartureDate);
            this.Controls.Add(this.labelSettlementDate);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelCitizenship);
            this.Controls.Add(this.labelPassportCode);
            this.Controls.Add(this.labelDateOfBirth);
            this.Controls.Add(this.labelSecondName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.buttonResetFilter);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.buttonSaveDB);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GuestsForm";
            this.Text = "GuestsForm";
            this.Load += new System.EventHandler(this.GuestsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSaveDB;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonResetFilter;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelSecondName;
        private System.Windows.Forms.Label labelDateOfBirth;
        private System.Windows.Forms.Label labelPassportCode;
        private System.Windows.Forms.Label labelCitizenship;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label labelSettlementDate;
        private System.Windows.Forms.Label labelDepartureDate;
        private System.Windows.Forms.Label labelPayMoney;
        private System.Windows.Forms.TextBox filterId;
        private System.Windows.Forms.TextBox filterFirstName;
        private System.Windows.Forms.TextBox filterSecondName;
        private System.Windows.Forms.TextBox filterDateOfBirth;
        private System.Windows.Forms.TextBox filterPassCode;
        private System.Windows.Forms.TextBox filterCitizenship;
        private System.Windows.Forms.TextBox filterLocation;
        private System.Windows.Forms.TextBox filterSettlementDate;
        private System.Windows.Forms.TextBox filterDepartDate;
        private System.Windows.Forms.TextBox filterPayMoney;
        private System.Windows.Forms.Label labelActiveRole;
        private System.Windows.Forms.Label infoLabelActiveRole;
    }
}