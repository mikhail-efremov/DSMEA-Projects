using SimpleHotelApp.Actors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleHotelApp
{
    public partial class GuestAdderToRoomForm : Form
    {
        private SQLiteConnection _connection;
        private Role _activeRole;
        private Guest _guest;

        public GuestAdderToRoomForm(SQLiteConnection connection, Role activeRole, Guest guest)
        {
            InitializeComponent();
            _connection = connection;
            _activeRole = activeRole;
            _guest = guest;
        }

        public Role ActiveRole { get; private set; }

        private void GuestAdderToRoomForm_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                //              var list = ((BindingList<Room>)(dataGridView1.DataSource)).ToList();
                //          var bList = (dataGridView1.DataSource);
                //        var b = (BindingList<Room>)bList;
                List<Room> products;
                List<Object> products1;
                var bindSourse = dataGridView1.DataSource;
                var a = new BindingSource(dataGridView1.DataSource, null);
                var list = (BindingList<object>)a.DataSource;
                
                try { products = (List<Room>)dataGridView1.DataSource; }
                catch { }

                try
                {
                    products1 = ((List<Room>)dataGridView1.DataSource).Cast<object>().ToList();
                }
                catch { }
                
                //          var bRoom = bList[e.RowIndex];
                //               var room = list[e.RowIndex];
                //              room.AddGuest(_guest);

                LoadRooms();
            }
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
                            Guest.GetByID(Convert.ToInt32(Convert.ToString(r["GuestId"]) == String.Empty ? 0 : r["GuestId"])),
                            Convert.ToDecimal(r["CostPerDay"])));
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

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var dr = dataGridView1.Rows[index];
                var buttonCell = new DataGridViewButtonCell();
                dr.Cells[3] = buttonCell;
            }
        }
    }
}