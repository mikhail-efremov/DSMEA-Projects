using System;
using System.Data.SQLite;

namespace SimpleHotelApp.Actors
{
    public class Guest : IHuman, ICustomer
    {
        private Int32 _id;
        private String _firstName;
        private String _secondName;
        private DateTime _dateOfBirth;
        private String _passportCode;
        private String _citizenship;
        private String _location;
        private DateTime? _settlementDate;
        private DateTime? _departureDate;
        private Decimal? _payMoney;

        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public String FirstName 
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public String SecondName 
        {
            get { return _secondName; }
            set { _secondName = value; }
        }
        public DateTime DateOfBirth 
        { 
            get { return _dateOfBirth; } 
            set { _dateOfBirth = value; } 
        }
        public String PassportCode 
        {
            get { return _passportCode; }
            set { _passportCode = value; }
        }
        public String Citizenship 
        {
            get { return _citizenship; }
            set { _citizenship = value; }
        }
        public String Location 
        {
            get { return _location; }
            set { _location = value; }
        }
        public DateTime? SettlementDate 
        {
            get { return _settlementDate; }
            set { _settlementDate = value; }
        }
        public DateTime? DepartureDate 
        {
            get { return _departureDate; }
            set { _departureDate = value; }
        }
        public Decimal? PayMoney 
        {
            get { return _payMoney; }
            set { _payMoney = value; }
        }

        public static Guest GetByID(Int32 Id)
        {
            return new Guest() {Id = Id};
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public Guest() { }

        public Guest(Int32 id, String firstName, String secondName, DateTime dateOfBirth,
            String passportCode, String citizenship, String location, DateTime? settlementDate,
                DateTime? departureDate, Decimal? payMoney)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.DateOfBirth = dateOfBirth;
            this.PassportCode = passportCode;
            this.Citizenship = citizenship;
            this.Location = location;
            this.SettlementDate = settlementDate;
            this.DepartureDate = departureDate;
            this.PayMoney = payMoney;
        }

        public static Guest Create(String firstName, String secondName, DateTime dateOfBirth,
            String passportCode, String citizenship, String location)
        {
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                connect.Open();
                var command = new SQLiteCommand(connect);

                command.CommandText = String.Format(
                    "INSERT INTO [tblGuests]([Id],[FirstName],[SecondName],[DateOfBirth],[PassportCode],[Citizenship],[Location])"
                    + " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');",
                    100, "vasil", "go", "2007-01-01 10:00:00", "13244", "citizenship", "location");
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connect.Close();
                }
            }
            return new Guest();

            /*
                        SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close(); 
            */
        }
    }
}