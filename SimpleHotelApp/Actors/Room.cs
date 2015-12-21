using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelApp.Actors
{
    public class Room
    {
        private bool _busy;
        private Guest _guest;
        private Decimal _costPerMonth;
        
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
        public Decimal CostPerMonth
        {
            get { return _costPerMonth; }
        }
    }
}