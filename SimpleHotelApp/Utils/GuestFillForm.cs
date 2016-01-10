using System;
using System.Windows.Forms;
using SimpleHotelApp.Actors;

namespace SimpleHotelApp.Utils
{
    public partial class GuestFillForm : Form
    {
        private Guest _guest;

        public Guest Guest
        {
            get { return _guest; }
            set { _guest = value; }
        }

        public GuestFillForm()
        {
            InitializeComponent();
        }

        public static Guest ShowAndReturnObject()
        {
            var dlg = new GuestFillForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return new Guest();
            }

            throw new ArgumentException("Please fill all guest fields");
        }

        private void buttonGuestReturn_Click(object sender, EventArgs e)
        {
            Guest.Create("1", "2", new DateTime(), "3", "4", "5");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}