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
    public partial class MainForm : Form
    {
        private Role ActiveRole;

        public MainForm(Role activeRole)
        {
            InitializeComponent();
            ActiveRole = activeRole;
        }
    }
}
