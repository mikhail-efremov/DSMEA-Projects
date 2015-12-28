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

        public MainForm(Role activeRole)
        {
            InitializeComponent();
            ActiveRole = activeRole;
        }

        private void button1_Click(object sender, EventArgs e)
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
                            Guest.GetByID(Convert.ToInt32(Convert.ToString(r["GuestId"]) == String.Empty ? 0 : r["GuestId"])),
                            Convert.ToDecimal(r["CostPerDay"])));
                    }

                    var bindingList = new BindingList<Room>(rooms);
                    var source = new BindingSource(bindingList, null);
                    dataGridView1.DataSource = source;
                }
            }
        }

        private static DataTable ConvertToDatatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
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