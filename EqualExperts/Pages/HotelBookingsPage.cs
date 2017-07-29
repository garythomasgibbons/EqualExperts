using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            //to do
            BookingDetails actualBookingDetails = GetMyBooking();
            return true;
        }

        private BookingDetails GetMyBooking()
        {
            var allBookings = Page.FindElements(bookings);
            var hold = (GetBookingsCount() + 1).ToString();
            var myBooking = Page.FindElements(By.CssSelector("div#bookings > div:nth(13)"));
            return new BookingDetails("firstname", "lastName", "10.00", "false", "2019-10-10", "2019-10-10");
        }

        public void SetDeposit(string value)
        {
            new SelectElement(Page.FindElement(depositSelect)).SelectByText(value);
        }
    }
}
