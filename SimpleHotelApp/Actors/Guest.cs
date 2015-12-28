using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private DateTime _settlementDate;
        private DateTime _departureDate;
        private Decimal _payMoney;

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
        public DateTime SettlementDate 
        {
            get { return _settlementDate; }
            set { _settlementDate = value; }
        }
        public DateTime DepartureDate 
        {
            get { return _departureDate; }
            set { _departureDate = value; }
        }
        public Decimal PayMoney 
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
    }
}