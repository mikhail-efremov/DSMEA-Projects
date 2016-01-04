using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelApp.Actors
{
    public interface ICustomer
    {
        DateTime? SettlementDate { get; set; }
        DateTime? DepartureDate { get; set; }
        Decimal? PayMoney { get; set; }
    }
}
