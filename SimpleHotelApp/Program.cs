using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            DialogResult result;
            var role = Role.Default;
            using (var loginForm = new LoginForm())
            {
                result = loginForm.ShowDialog();
                role = loginForm.ActiveRole;
            }
            if (result == DialogResult.OK)
            {
                Application.Run(new MainForm(role));
            }
        }
    }
}
