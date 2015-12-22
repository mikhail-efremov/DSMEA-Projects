using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace SimpleHotelApp
{
    public partial class MainForm : Form
    {
        private Role ActiveRole;

        public MainForm(Role activeRole)
        {
            InitializeComponent();
            ActiveRole = activeRole;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT * FROM tblRooms";
                    fmd.CommandType = CommandType.Text;

                    DataSet ds = new DataSet();
                    var da = new SQLiteDataAdapter(fmd);
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;

                }
            }
        }
    }
}