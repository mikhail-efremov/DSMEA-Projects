using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SimpleHotelApp
{
    public partial class LoginForm : Form
    {
        public Role ActiveRole;
        private SQLiteConnection _sqlConnection;

        public LoginForm(SQLiteConnection connect)
        {
            InitializeComponent();
            _sqlConnection = connect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Role role;
            if (TryLogin(textBoxLogin.Text, textBoxPassword.Text, out role))
            {
                ActiveRole = role;
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool TryLogin(String login, String password, out Role role)
        {
            List<string> ImportedFiles = new List<string>();
            _sqlConnection.Open();
            using (SQLiteCommand fmd = _sqlConnection.CreateCommand())
            {
                fmd.CommandText = @"SELECT * FROM tblApplicationUsers";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader r = fmd.ExecuteReader();
                while (r.Read())
                {
                    if (login == Convert.ToString(r["Login"])
                        && password == Convert.ToString(r["Password"]))
                    {
                        role = (Role)(Enum.Parse(typeof(Role), Convert.ToString(r["Role"]), true));
#warning               _sqlConnection.Close();
                        return true;
                    }
                }
#warning            _sqlConnection.Close();
            }
            role = Role.Customer;
            return false;
        }
    }

    public enum Role
    {
        Administrator,
        Customer,
        Default
    }
}
