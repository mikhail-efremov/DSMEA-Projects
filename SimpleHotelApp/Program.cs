using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SimpleHotelApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var connect = new SQLiteConnection(@"Data Source=DataBase.db");
#warning            connect.Open();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            DialogResult result;
            var role = Role.Default;
            using (var loginForm = new LoginForm(connect))
            {
                result = loginForm.ShowDialog();
                role = loginForm.ActiveRole;
            }
            if (result == DialogResult.OK)
            {
                Application.Run(new MainForm(role, connect));
            }
        }
    }
}
