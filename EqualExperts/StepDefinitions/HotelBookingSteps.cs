using TechTalk.SpecFlow;
using EqualExperts.Pages;
using OpenQA.Selenium.Chrome;
using FluentAssertions;

namespace EqualExperts.StepDefinitions
{
    [Binding]
    public sealed class HotelBookingSteps : HotelBookingsPage
    {
        private HotelBookingsPage HotelBookingsPage;

        HotelBookingSteps(HotelBookingsPage hotelBookingsPage)
        {
            HotelBookingsPage = hotelBookingsPage;
        }
         
        [Given(@"I have a browser open")]
        public void GivenIHaveABrowserOpen()
        {

        }

        [Given(@"I the url is '(.*)'")]
        public void GivenITheUrlIs(string url)
        {
            HotelBookingsPage.LoadPage(url);
        }

        [Given(@"I enter valid details into all required input fields")]
        public void GivenIEnterValidDetailsIntoAllRequiredInputFields()
        {
            HotelBookingsPage.CreateABooking();
        }

        [Given(@"I set deposit to false")]
        public void GivenISetDepositToFalse()
        {
            HotelBookingsPage.SetDepositToFalse();
        }

        [Given(@"I type valid and logical dates directly into the checkin and checkout fields in big endian format yyyy-mm-dd")]
        public void GivenITypeValidAndLogicalDatesDirectlyIntoTheCheckinAndCheckoutFieldsInBigEndianFormatYyyy_Mm_Dd()
        {
            HotelBookingsPage.SetValidBigEndianDates();
        }

        [When(@"I click save")]
        public void WhenIClickSave()
        {
            HotelBookingsPage.ClickSave();
        }

        [Then(@"my reservation will be created")]
        public void ThenMyReservationWillBeCreated()
        {
            HotelBookingsPage.BookingCreated().Should().BeTrue();
        }

        [Then(@"my booking details are correct")]
        public void ThenMyBookingDetailsAreCorrect()
        {
            HotelBookingsPage.CheckBookingDetails().Should().BeTrue();
        }








    }
}
