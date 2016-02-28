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

        private BindingList<Room> _currentRoomsList;

        public GuestAdderToRoomForm(SQLiteConnection connection, Role activeRole, Guest guest)
        {
            InitializeComponent();
            _connection = connection;
            _activeRole = activeRole;
            labelActiveRole.Text = _activeRole.ToString();
            labelActiveRoom.Text = guest.Id.ToString();
            _guest = guest;
        }

        public Role ActiveRole { get; private set; }

        private void GuestAdderToRoomForm_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_activeRole != Role.Administrator)
                return;

            if (e.ColumnIndex == 3)
            {
                var bRoom = _currentRoomsList[e.RowIndex];
                bRoom.AddGuest(_currentRoomsList.ToList(), e.RowIndex, Convert.ToString(_guest.Id));

                Room.FullUpdateTable(_connection, _currentRoomsList.ToList());
            }
            else if (e.ColumnIndex == 6)
            {
                var bRoom = _currentRoomsList[e.RowIndex];
                bRoom.Guests = String.Empty;

                Room.FullUpdateTable(_connection, _currentRoomsList.ToList());
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
                            Convert.ToString(Convert.ToString(r["GuestId"]) == String.Empty ? 0 : r["GuestId"]),
                            Convert.ToDecimal(r["CostPerDay"]),
                            Convert.ToInt32(r["RoomsCount"])));
                    }

                    _currentRoomsList = new BindingList<Room>(rooms);
                    var source = new BindingSource(_currentRoomsList, null);
                    dataGridView1.DataSource = source;
                    var guestButton = new DataGridViewButtonColumn();
                    guestButton.Name = "dataGridViewDeleteButton";
                    guestButton.HeaderText = "Guests";
                    guestButton.Text = "Guests";
                    dataGridView1.ReadOnly = true;
                }
            }
            dataGridView1.Columns.Add("Clear", "Clear");
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var dr = dataGridView1.Rows[index];
                var buttonCell = new DataGridViewButtonCell();
                dr.Cells[3] = buttonCell;
                var buttonCell1 = new DataGridViewButtonCell();
                dr.Cells[6] = buttonCell1;
                dataGridView1[6, index].Value = "Clear";
            }
        }
    }
}