using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

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
        private By bookings => By.CssSelector("div#bookings > div");

        public HotelBookingsPage()
        {
            Page = driver;
        }

        public void LoadPage(string url)
        {
            Page.Url = url;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
            NumberOfBookings = GetBookingsCount();
        }

        public int GetBookingsCount()
        {
            return Page.FindElements(bookings).Count - 1;
        }

        public void CreateABooking(string firstName, string lastName, string price)
        {
            Page.FindElement(firstNameTxt).SendKeys(firstName);
            Page.FindElement(lastNameTxt).SendKeys(lastName);
            Page.FindElement(totalPriceTxt).SendKeys(price);           
        }

        public void ClickSave()
        {
            Page.FindElement(saveButton).Click();
            Page.Navigate().Refresh();
        }

        public void SetDates(string checkIn, string checkOut)
        {
            Page.FindElement(checkInTxt).SendKeys(checkIn);
            Page.FindElement(checkOutTxt).SendKeys(checkOut);
        }

        public bool BookingCreated()
        {
           return GetBookingsCount().Equals(NumberOfBookings + 1);
        }

        public bool CheckBookingDetails(BookingDetails expectedBookingDetails)
        {
            BookingDetails actualBookingDetails = GetMyBooking();

            if (expectedBookingDetails.FirstName.Equals(actualBookingDetails.FirstName)
                && expectedBookingDetails.LastName.Equals(actualBookingDetails.LastName)
                && expectedBookingDetails.Price.Equals(actualBookingDetails.Price)
                && expectedBookingDetails.Deposit.Equals(actualBookingDetails.Deposit)
                && expectedBookingDetails.CheckIn.Equals(actualBookingDetails.CheckIn)
                && expectedBookingDetails.CheckOut.Equals(actualBookingDetails.CheckOut))
            {
                return true;
            }

            return false;
        }

        private BookingDetails GetMyBooking()
        {
            var myRow = (GetBookingsCount() + 1).ToString();
            var myBooking = Page.FindElements(By.CssSelector("div#bookings > div:nth-child(" + myRow +")"));

            var first = myBooking[0].FindElement(By.CssSelector("div:nth-child(1)")).Text;
            var last = myBooking[0].FindElement(By.CssSelector("div:nth-child(2)")).Text;
            var price = myBooking[0].FindElement(By.CssSelector("div:nth-child(3)")).Text;
            var deposit = myBooking[0].FindElement(By.CssSelector("div:nth-child(4)")).Text;
            var checkIn = myBooking[0].FindElement(By.CssSelector("div:nth-child(5)")).Text;
            var checkOut = myBooking[0].FindElement(By.CssSelector("div:nth-child(6)")).Text;

            return new BookingDetails(first, last, price, deposit, checkIn, checkOut);
        }

        public void SetDeposit(string value)
        {
            new SelectElement(Page.FindElement(depositSelect)).SelectByText(value);
        }
    }
}
