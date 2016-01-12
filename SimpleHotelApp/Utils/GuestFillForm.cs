using System;
using System.Windows.Forms;
using SimpleHotelApp.Actors;
using System.Data.SQLite;

namespace SimpleHotelApp.Utils
{
    public partial class GuestFillForm : Form
    {
        private Guest _guest;
        private SQLiteConnection _sqlconnection;

        public Guest Guest
        {
            get { return _guest; }
            set { _guest = value; }
        }

        public GuestFillForm(SQLiteConnection connection)
        {
            InitializeComponent();
            _sqlconnection = connection;
        }

        public static Guest ShowAndReturnObject(SQLiteConnection connection)
        {
            var dlg = new GuestFillForm(connection);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return new Guest();
            }

            throw new ArgumentException("Please fill all guest fields");
        }

        private void buttonGuestReturn_Click(object sender, EventArgs e)
        {
            var firstName = textBoxFirstName.Text;
            var secondName = textBoxSecondName.Text;
            var dateOfBirth = DateTime.Parse(textBoxDateOfBirth.Text);
            var passportCode = textBoxPassportCode.Text;
            var citizenship = textBoxCitizenship.Text;
            var location = textBoxLocation.Text;

            Guest.Create(_sqlconnection, 
                firstName,
                secondName,
                dateOfBirth,
                passportCode,
                citizenship,
                location);

            this.DialogResult = DialogResult.OK;
        }
    }
}