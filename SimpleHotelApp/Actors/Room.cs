using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SimpleHotelApp.Actors
{
    public class Room
    {
        private Int32 _id;
        private Int32 _number;
        private bool _busy;
        private String _guests;
        private Decimal _costPerDay;

        public Int32 ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public Int32 Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public bool Busy
        {
            get { return _busy; }
            set { _busy = value; }
        }
        
        public String Guests 
        {
            get {
                if (!Busy)
                {
                    return _guests;
                }
                return null;
            }
            set { _guests = value; }
        }
        public Decimal CostPerDay
        {
            get { return _costPerDay; }
            set { _costPerDay = value; }
        }

        public Room(Int32 id, Int32 number, Boolean busy, Guest guest, Decimal costPerDay)
        {
            ID = id;
            Number = number;
            Busy = busy;
            AddGuest(guest);
            CostPerDay = costPerDay;
        }

        public void AddGuest(Guest g)
        {
            if (g == null)
                return;
            if (g.IsEmpty())
                return;
            if (_guests == null)
                _guests = String.Empty;
            var a = JsonConvert.DeserializeObject<List<Guest>>(_guests);
            if (a == null)
                a = new List<Guest>();
            a.Add(g);
            _guests = JsonConvert.SerializeObject(a);
        }

        public static void FullUpdateTable(SQLiteConnection connection, List<Room> list)
        {
            var clearComand = "DELETE FROM tblRooms;";

            var sqlCommand = new SQLiteCommand(clearComand, connection);
            sqlCommand.ExecuteNonQuery();

            foreach (var r in list)
            {
                Room.Create(connection, r);
            }
        }

        public static Guest Create(SQLiteConnection connection, Room room)
        {
            return Create(connection, room.Number, room.Busy, room.Guests, room.CostPerDay);
        }

        public static Guest Create(SQLiteConnection connection, int number, bool busy,
            string guests, decimal costPerDay)
        {
            SQLiteCommand insertSQL = new SQLiteCommand(
                "INSERT INTO tblRooms " +
                "(Id, Number, Busy, GuestId, CostPerDay) " +
                "VALUES (?,?,?,?,?);", connection
                );
            insertSQL.Parameters.Add(new SQLiteParameter("Id", null));
            insertSQL.Parameters.Add(new SQLiteParameter("Number", number));
            insertSQL.Parameters.Add(new SQLiteParameter("Busy", busy));
            insertSQL.Parameters.Add(new SQLiteParameter("GuestId", guests));
            insertSQL.Parameters.Add(new SQLiteParameter("CostPerDay", costPerDay));
            try
            {
                insertSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
            return new Guest();
        }
    }
}