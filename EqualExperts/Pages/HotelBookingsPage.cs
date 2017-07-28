using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualExperts.Pages
{
    public class HotelBookingsPage : BasePage
    {
        private ChromeDriver Page;
        public int NumberOfBookings = 0;
        private By firstNameTxt => By.Id("firstname");
        private By lastNameTxt => By.Id("lastname");
        private By totalPriceTxt => By.Id("totalprice");
        private By depositSelect => By.Id("depositpaid");
        private By checkInTxt => By.Id("checkin");
        private By checkOutTxt => By.Id("checkout");
        private By saveButton => By.CssSelector("[value=' Save ']");
        private By numberOfBookings => By.Id("bookings");

        public BookingDetails bookingDetails = new BookingDetails("firstname", "lastName", "10.00", "false", "2019-10-10", "2019-10-10");

        public HotelBookingsPage()
        {
            Page = driver;
            NumberOfBookings = GetBookingsCount();
        }

        public void LoadPage(string url)
        {
            Page.Url = url;
        }

        public int GetBookingsCount()
        {
            return Page.FindElements(numberOfBookings).Count - 1;
        }

        public void CreateABooking()
        {
            Page.FindElement(firstNameTxt).SendKeys(bookingDetails.FirstName);
            Page.FindElement(lastNameTxt).SendKeys(bookingDetails.LastName);
            Page.FindElement(totalPriceTxt).SendKeys(bookingDetails.Price);           
        }

        public void ClickSave()
        {
            Page.FindElement(saveButton).Click();
            Page.Navigate().Refresh();
        }

        public void SetValidBigEndianDates()
        {
            Page.FindElement(checkInTxt).SendKeys(bookingDetails.CheckIn);
            Page.FindElement(checkOutTxt).SendKeys(bookingDetails.CheckOut);
        }

        public void SetDepositToFalse()
        {
            SetDeposit("false");
        }

        public bool BookingCreated()
        {
            return GetBookingsCount().Equals(NumberOfBookings + 1);
        }

        public bool CheckBookingDetails()
        {
            //to do
            return true;
        }

        private void SetDeposit(string value)
        {
            new SelectElement(Page.FindElement(depositSelect)).SelectByText(value);
        }

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
}
