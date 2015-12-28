using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelApp.Actors
{
    public class Room
    {
        private Int32 _id;
        private Int32 _number;
        private bool _busy;
        private Guest _guest;
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
        public Guest Guest 
        {
            get {
                if (!Busy)
                {
                    return _guest;
                }
                return null;
            }
            set { _guest = value; }
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
            Guest = guest;
            CostPerDay = costPerDay;
        }
    }
}