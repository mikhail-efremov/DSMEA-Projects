using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelApp.Actors
{
    public class Hotel
    {
        private List<Room> _rooms;

        public List<Room> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }
    }
}