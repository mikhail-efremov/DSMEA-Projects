using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
            var a = JsonConvert.DeserializeObject<List<Guest>>(_guests);
            a.Add(g);
            _guests = JsonConvert.SerializeObject(a);
        }
    }
}