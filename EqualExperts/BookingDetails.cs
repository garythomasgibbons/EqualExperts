using System;

namespace EqualExperts
{
    public class BookingDetails
    {
        public string FirstName;
        public string LastName;
        public string Price;
        public string Deposit;
        public string CheckIn;
        public string CheckOut;

        public BookingDetails(string firstname, string lastName, string price, string deposit, string checkIn, string checkOut)
        {
            FirstName = firstname + "_" + GetTimeInSeconds().ToString();
            LastName = lastName + "_" + GetTimeInSeconds().ToString();
            Price = price;
            Deposit = deposit;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        private int GetTimeInSeconds()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }
    }
}
