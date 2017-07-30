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
            FirstName = firstname;
            LastName = lastName;
            Price = price;
            Deposit = deposit;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
    }
}
