using TechTalk.SpecFlow;
using EqualExperts.Pages;
using FluentAssertions;
using System;

namespace EqualExperts.StepDefinitions
{
    [Binding]
    public sealed class HotelBookingSteps : HotelBookingsPage
    {
        private HotelBookingsPage hotelBookingsPage;
        public BookingDetails bookingDetails;

        HotelBookingSteps(HotelBookingsPage HotelBookingsPage)
        {
            hotelBookingsPage = HotelBookingsPage;
            var checkIn = DateTime.Now.ToString("yyyy-MM-dd");
            var checkOut = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            bookingDetails = new BookingDetails("firstname", "lastName", "10.52", "false", checkIn, checkOut);
        }
         
        [Given(@"I have a browser open")]
        public void GivenIHaveABrowserOpen()
        {
        }

        [Given(@"I the url is '(.*)'")]
        public void GivenITheUrlIs(string url)
        {
            hotelBookingsPage.LoadPage(url);
        }

        [Given(@"I enter valid details into all required input fields")]
        public void GivenIEnterValidDetailsIntoAllRequiredInputFields()
        {
             hotelBookingsPage.CreateABooking(bookingDetails.FirstName, bookingDetails.LastName, bookingDetails.Price);
        }

        [Given(@"I set deposit to false")]
        public void GivenISetDepositToFalse()
        {
            hotelBookingsPage.SetDeposit(bookingDetails.Deposit);
        }

        [Given(@"I type valid and logical dates directly into the checkin and checkout fields in big endian format yyyy-mm-dd")]
        public void GivenITypeValidAndLogicalDatesDirectlyIntoTheCheckinAndCheckoutFieldsInBigEndianFormatYyyy_Mm_Dd()
        {
            hotelBookingsPage.SetDates(bookingDetails.CheckIn, bookingDetails.CheckOut);
        }

        [When(@"I click save")]
        public void WhenIClickSave()
        {
            hotelBookingsPage.ClickSave();
        }

        [Then(@"my reservation will be created")]
        public void ThenMyReservationWillBeCreated()
        {
           hotelBookingsPage.BookingCreated().Should().BeTrue();
        }

        [Then(@"my booking details are correct")]
        public void ThenMyBookingDetailsAreCorrect()
        {
            hotelBookingsPage.CheckBookingDetails(bookingDetails).Should().BeTrue();
        }
    }
}
