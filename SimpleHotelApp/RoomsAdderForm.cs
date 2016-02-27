using Newtonsoft.Json;
using SimpleHotelApp.Actors;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SimpleHotelApp
{
    public partial class RoomsAdderForm : Form
    {
        private SQLiteConnection _connection;
        private Role _activeRole;
        private Guest _guest;

        public RoomsAdderForm(SQLiteConnection connection, Role activeRole, Guest guest)
        {
            InitializeComponent();
            _connection = connection;
            _activeRole = activeRole;
            labelActiveRole.Text = activeRole.ToString();
            _guest = guest;
            FillJsonLabel();
        }

        private void FillJsonLabel()
        {
            guestJsonLabel.Text = JsonConvert.SerializeObject(_guest, Formatting.Indented).Replace("\"", String.Empty);
        }

        private void changeRoomButton_Click(object sender, EventArgs e)
        {
            var guestAddederToRoomForm = new GuestAdderToRoomForm(_connection, _activeRole, _guest);
            guestAddederToRoomForm.ShowDialog();
        }
    }
}