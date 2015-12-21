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
    public partial class LoginForm : Form
    {
        public Role ActiveRole;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Role role;
            if (TryLogin(textBoxLogin.Text, textBoxPassword.Text, out role))
            {
                ActiveRole = role;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool TryLogin(String login, String password, out Role role)
        {
            List<string> ImportedFiles = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
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
                            return true;
                        }
                    }
                }
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
