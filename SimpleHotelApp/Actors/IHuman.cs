using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelApp.Actors
{
    public interface IHuman
    {
        String FirstName { get; set; }
        String SecondName { get; set; }
        DateTime DateOfBirth { get; set; }
        String PassportCode { get; set; }
        String Citizenship { get; set; }
        String Location { get; set; }
    }
}
