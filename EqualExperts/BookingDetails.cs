namespace EqualExperts
{
    public class BookingDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Price { get; set; }
        public string Deposit { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }

        public BookingDetails()
        {

        }

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
