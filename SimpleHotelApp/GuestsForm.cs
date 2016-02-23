using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using SimpleHotelApp.Actors;
using Newtonsoft.Json;

namespace SimpleHotelApp
{
    public partial class GuestsForm : Form
    {
        public WorkingStatus ActiveStatus
        {
            get
            {
                return _activeStatus;
            }
            set
            {
                _activeStatus = value;
                if (_activeStatus == WorkingStatus.Normal)
                    dataGridView1.AllowUserToAddRows = true;
                else if (_activeStatus == WorkingStatus.Searching)
                    dataGridView1.AllowUserToAddRows = false;
            }
        }
        
        private WorkingStatus _activeStatus;
        private Role ActiveRole;
        private SQLiteConnection _sqlConnection;

        public GuestsForm(SQLiteConnection connection, Role activeRole)
        {
            InitializeComponent();
            _sqlConnection = connection;
            ActiveRole = activeRole;
            ActiveStatus = WorkingStatus.Normal;

            if (ActiveRole == Role.Customer || ActiveRole == Role.Default)
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
            }
        }

        private void buttonAddGuest_Click(object sender, EventArgs e)
        {
            var myObject = Utils.GuestFillForm.ShowAndReturnObject(_sqlConnection);
        }

        private void buttonSaveDB_Click(object sender, EventArgs e)
        {
            var bindingList = dataGridView1.DataSource as BindingList<Guest>;
            SaveInDataBase(bindingList.ToList());
        }

        public void SaveInDataBase(List<Guest> guestsList)
        {
            if (ActiveStatus == WorkingStatus.Searching)
                Guest.UpdateTableGuests(_sqlConnection, guestsList);
            else
            if (ActiveStatus == WorkingStatus.Normal)
                Guest.FullUpdateTable(_sqlConnection, guestsList);
        }

        private void GuestsForm_Load(object sender, EventArgs e)
        {
            LoadFullGuestList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveStatus = WorkingStatus.Searching;
            var bindingList = (BindingList<Guest>)dataGridView1.DataSource;
            var a = Filter(bindingList);
            var nb = new BindingList<Guest>(a.ToList());
            dataGridView1.DataSource = nb;
        }

        private void buttonResetFilter_Click(object sender, EventArgs e)
        {
            ActiveStatus = WorkingStatus.Normal;
            LoadFullGuestList();
        }

        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void LoadFullGuestList()
        {
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT * FROM tblGuests";
                    fmd.CommandType = CommandType.Text;

                    SQLiteDataReader r = fmd.ExecuteReader();

                    var rooms = new List<Guest>();

                    while (r.Read())
                    {
                        rooms.Add(new Guest(
                            Convert.ToInt32(r["Id"]),
                            Convert.ToString(r["FirstName"]),
                            r["SecondName"] == DBNull.Value ? String.Empty : Convert.ToString(r["SecondName"]),
                            Convert.ToDateTime(r["DateOfBirth"]),
                            r["PassportCode"] == DBNull.Value ? String.Empty : Convert.ToString(r["PassportCode"]),
                            Convert.ToString(r["Citizenship"]),
                            r["Location"] == DBNull.Value ? String.Empty : Convert.ToString(r["Location"]),
                            r["SettlementDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["SettlementDate"]),
                            r["DepartureDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["DepartureDate"]),
                            r["PayMoney"] == DBNull.Value ? (Decimal?)null : Convert.ToDecimal(r["PayMoney"])));
                    }
                    var bindingRooms = new BindingList<Guest>(rooms);
                    dataGridView1.DataSource = bindingRooms;

                    FillButtonsToTable();

                    if (ActiveRole == Role.Administrator)
                        dataGridView1.ReadOnly = false;
                    if (ActiveRole == Role.Customer)
                        dataGridView1.ReadOnly = true;
                }
            }
        }

        private List<Guest> Filter(BindingList<Guest> bindingList)
        {
            var list = bindingList.ToList();

            if(!String.IsNullOrWhiteSpace(filterId.Text))
            {
                list = list.Where(p => p.Id == Convert.ToInt32(filterId.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(filterFirstName.Text))
            {
                list = list.Where(p => p.FirstName.Contains(filterFirstName.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(filterSecondName.Text))
            {
                list = list.Where(p => p.SecondName.Contains(filterSecondName.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(filterDateOfBirth.Text))
            {
                list = list.Where(p => p.DateOfBirth == Convert.ToDateTime(filterDateOfBirth.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(filterPassCode.Text))
            {
                list = list.Where(p => p.PassportCode.Contains(filterPassCode.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(filterCitizenship.Text))
            {
                list = list.Where(p => p.Citizenship.Contains(filterCitizenship.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(filterLocation.Text))
            {
                list = list.Where(p => p.Location.Contains(filterLocation.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(filterSettlementDate.Text))
            {
                list = list.Where(p => p.SettlementDate == Convert.ToDateTime(filterSettlementDate.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(filterDepartDate.Text))
            {
                list = list.Where(p => p.DepartureDate == Convert.ToDateTime(filterDepartDate.Text)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(filterPayMoney.Text))
            {
                list = list.Where(p => p.PayMoney == Convert.ToDecimal(filterPayMoney.Text)).ToList();
            }
            return list;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                var list = ((BindingList<Guest>)(dataGridView1.DataSource)).ToList();
                var a = list[e.RowIndex];

                var guestForm = new RoomsAdderForm(_sqlConnection, ActiveRole, a);
                guestForm.ShowDialog();
            //    MessageBox.Show(JsonConvert.SerializeObject(a, Formatting.Indented).Replace("\"", String.Empty));
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            FillButtonsToTable();
        }

        private void FillButtonsToTable()
        {
            for (int index = 0; index < dataGridView1.Rows.Count - 1; index++)
            {
                var dr = dataGridView1.Rows[index];
                var buttonCell = new DataGridViewButtonCell();
                dr.Cells[10] = buttonCell;
            }
        }
    }

    public enum WorkingStatus
    {
        Normal = 0,
        Searching = 1
    }
}