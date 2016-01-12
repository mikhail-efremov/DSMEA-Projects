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
using SimpleHotelApp.Actors;

namespace SimpleHotelApp
{
    public partial class MainForm : Form
    {
        private Role ActiveRole;
        private SQLiteConnection _sqlConnection;

        public MainForm(Role activeRole, SQLiteConnection connection)
        {
            InitializeComponent();
            _sqlConnection = connection;
            ActiveRole = activeRole;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var roomForm = new RoomsForm(ActiveRole);
            roomForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var guestForm = new GuestsForm(_sqlConnection, ActiveRole);
            guestForm.ShowDialog();
        }

        /*
        public void Create(Book book)
        {
            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO Book (Id, Title, Language, PublicationDate, Publisher, Edition, OfficialUrl, Description, EBookFormat) VALUES (?,?,?,?,?,?,?,?)", sql_con);
            insertSQL.Parameters.Add(book.Id);
            insertSQL.Parameters.Add(book.Title);
            insertSQL.Parameters.Add(book.Language);
            insertSQL.Parameters.Add(book.PublicationDate);
            insertSQL.Parameters.Add(book.Publisher);
            insertSQL.Parameters.Add(book.Edition);
            insertSQL.Parameters.Add(book.OfficialUrl);
            insertSQL.Parameters.Add(book.Description);
            insertSQL.Parameters.Add(book.EBookFormat);
            try
            {
                insertSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
         */
    }
}