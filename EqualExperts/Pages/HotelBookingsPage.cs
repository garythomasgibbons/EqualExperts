using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace EqualExperts.Pages
{
    public class HotelBookingsPage : BasePage
    {
        private ChromeDriver Page;
        private int NumberOfBookings = 0;
        private By firstNameTxt => By.Id("firstname");
        private By lastNameTxt => By.Id("lastname");
        private By totalPriceTxt => By.Id("totalprice");
        private By depositSelect => By.Id("depositpaid");
        private By checkInTxt => By.Id("checkin");
        private By checkOutTxt => By.Id("checkout");
        private By saveButton => By.CssSelector("[value=' Save ']");
        private By bookings => By.CssSelector("div#bookings > div");
        private By deleteButton => By.CssSelector("[value='Delete']");

        public HotelBookingsPage()
        {
            Page = driver;
        }

        public void LoadPage(string url)
        {
            Page.Url = url;
            //If no bookings we dont need to wait for ajax to complete
            if (!Page.FindElements(deleteButton).Count.Equals(0))
                WaitForAjax();
                NumberOfBookings = GetBookingsCount();
        }

        private void WaitForAjax()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
        }

        public int GetBookingsCount()
        {
            return Page.FindElements(bookings).Count - 1;
        }

        public void CreateNamePrice(string firstName, string lastName, string price)
        {
            ClearAndSendKeys(Page.FindElement(firstNameTxt), firstName);
            ClearAndSendKeys(Page.FindElement(lastNameTxt), lastName);
            ClearAndSendKeys(Page.FindElement(totalPriceTxt), price);          
        }

        public void ClickSave()
        {
            Page.FindElement(saveButton).Click();
            RefreshPage();
        }

        private void RefreshPage()
        {
            Page.Navigate().Refresh();
            if (!Page.FindElements(deleteButton).Count.Equals(0))
                WaitForAjax();
        }

        public void SetDates(string checkIn, string checkOut)
        {
            ClearAndSendKeys(Page.FindElement(checkInTxt), checkIn);
            ClearAndSendKeys(Page.FindElement(checkOutTxt), checkOut);
        }

        private void ClearAndSendKeys(IWebElement element, string inputText)
        {
            element.Clear();
            element.SendKeys(inputText);
        }

        public bool BookingCreated()
        {
           return GetBookingsCount().Equals(NumberOfBookings + 1);
        }

        public bool BookingDeleted()
        {
            return GetBookingsCount().Equals(NumberOfBookings);
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
            var theLastBooking = GetLastBooking();
            var first = theLastBooking[0].FindElement(By.CssSelector("div:nth-child(1)")).Text;
            var last = theLastBooking[0].FindElement(By.CssSelector("div:nth-child(2)")).Text;
            var price = theLastBooking[0].FindElement(By.CssSelector("div:nth-child(3)")).Text;
            var deposit = theLastBooking[0].FindElement(By.CssSelector("div:nth-child(4)")).Text;
            var checkIn = theLastBooking[0].FindElement(By.CssSelector("div:nth-child(5)")).Text;
            var checkOut = theLastBooking[0].FindElement(By.CssSelector("div:nth-child(6)")).Text;

            return new BookingDetails(first, last, price, deposit, checkIn, checkOut);
        }

        private ReadOnlyCollection<IWebElement> GetLastBooking()
        {
            var myRow = (GetBookingsCount() + 1).ToString();
            return Page.FindElements(By.CssSelector("div#bookings > div:nth-child(" + myRow + ")"));
        }

        public void DeleteTheLastBooking()
        {
            var theLastBooking = GetLastBooking();
            theLastBooking[0].FindElement(deleteButton).Click();
            RefreshPage();
        }

        public void SetDeposit(string value)
        {
            new SelectElement(Page.FindElement(depositSelect)).SelectByText(value);
        }
    }
}
