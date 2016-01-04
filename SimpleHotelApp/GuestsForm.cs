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
using SimpleHotelApp.Actors;

namespace SimpleHotelApp
{
    public partial class GuestsForm : Form
    {
        private Role ActiveRole;

        public GuestsForm(Role activeRole)
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
                    fmd.CommandText = @"SELECT * FROM tblGuests";
                    fmd.CommandType = CommandType.Text;

                    SQLiteDataReader r = fmd.ExecuteReader();

                    var rooms = new List<Guest>();
                    
                    while (r.Read())
                    {
                        rooms.Add(new Guest(
                            Convert.ToInt32(r["Id"]), 
                            Convert.ToString(r["FirstName"]),
                            r["SecondName"] == DBNull.Value ? String.Empty : Convert.ToString(r["SecondName"]),
                            Convert.ToDateTime(r["DateOfBirth"]),
                            r["PassportCode"] == DBNull.Value ? String.Empty : Convert.ToString(r["PassportCode"]),
                            Convert.ToString(r["Citizenship"]),
                            r["Location"] == DBNull.Value ? String.Empty : Convert.ToString(r["Location"]),
                            r["SettlementDate"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(r["SettlementDate"]),
                            r["DepartureDate"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(r["DepartureDate"]),
                            r["PayMoney"] == DBNull.Value ? (Decimal?) null : Convert.ToDecimal(r["PayMoney"])));
                    }

                    var bindingList = new BindingList<Guest>(rooms);
                    var source = new BindingSource(bindingList, null);
                    dataGridView1.DataSource = source;

                    if (ActiveRole == Role.Administrator)
                        dataGridView1.ReadOnly = false;
                    if (ActiveRole == Role.Customer)
                        dataGridView1.ReadOnly = true;
                }
            }
        }
    }
}
