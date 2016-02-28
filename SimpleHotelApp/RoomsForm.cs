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
    public partial class RoomsForm : Form
    {
        private Role ActiveRole;

        public RoomsForm(Role activeRole)
        {
            InitializeComponent();
            ActiveRole = activeRole;
            labelActiveRole.Text = ActiveRole.ToString();

            if (ActiveRole == Role.Customer || ActiveRole == Role.Default)
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
            }
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

                    SQLiteDataReader r = fmd.ExecuteReader();

                    var rooms = new List<Room>();

                    while (r.Read())
                    {
                        rooms.Add(new Room(Convert.ToInt32(r["Id"]), Convert.ToInt32(r["Number"]),
                            Convert.ToBoolean(Convert.ToInt32(r["Busy"]) == 1),
                            Convert.ToString(Convert.ToString(r["GuestId"]) == String.Empty ? 0 : r["GuestId"]),
                            Convert.ToDecimal(r["CostPerDay"]),
                            Convert.ToInt32(r["RoomsCount"])));
                    }

                    var bindingList = new BindingList<Room>(rooms);
                    var source = new BindingSource(bindingList, null);
                    dataGridView1.DataSource = source;
                    var guestButton = new DataGridViewButtonColumn();
                    guestButton.Name = "dataGridViewDeleteButton";
                    guestButton.HeaderText = "Guests";
                    guestButton.Text = "Guests";
                    
                    if (ActiveRole == Role.Administrator)
                        dataGridView1.ReadOnly = false;
                    if (ActiveRole == Role.Customer)
                        dataGridView1.ReadOnly = true;
                }
            }
        }
    }
}
