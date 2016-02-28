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
    public partial class MainForm : Form
    {
        private Role ActiveRole;
        private SQLiteConnection _sqlConnection;

        public MainForm(Role activeRole, SQLiteConnection connection)
        {
            InitializeComponent();
            _sqlConnection = connection;
            ActiveRole = activeRole;
            labelActiveRole.Text = ActiveRole.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var roomForm = new RoomsForm(ActiveRole);
            roomForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var guestForm = new GuestsForm(_sqlConnection, ActiveRole);
            guestForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void LoadRooms()
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
                    dataGridView1.ReadOnly = true;
                }
            }
        }
    }
}