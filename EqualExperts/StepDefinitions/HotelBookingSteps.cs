using TechTalk.SpecFlow;
using EqualExperts.Pages;
using FluentAssertions;
using System;
using TechTalk.SpecFlow.Assist;

namespace EqualExperts.StepDefinitions
{
    [Binding]
    public sealed class HotelBookingSteps : HotelBookingsPage
    {
        private HotelBookingsPage hotelBookingsPage;
        public BookingDetails bookingDetails;
        public string checkIn;
        public string checkOut;

        HotelBookingSteps(HotelBookingsPage HotelBookingsPage)
        {
            hotelBookingsPage = HotelBookingsPage;
            checkIn = DateTime.Now.ToString("yyyy-MM-dd");
            checkOut = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            bookingDetails = new BookingDetails("firstname_" + GetUniqueValue(), "lastName_" + GetUniqueValue(), "10.52", "false", checkIn, checkOut);
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
            hotelBookingsPage.CreateNamePrice(bookingDetails.FirstName, bookingDetails.LastName, bookingDetails.Price);
        }

        [Given(@"I entered the following data into the booking form:")]
        public void GivenIEnteredTheFollowingDataIntoTheBookingForm(Table booking)
        {
            bookingDetails = booking.CreateInstance<BookingDetails>();
            GivenIHaveCreatedABooking();
        }
        
        [Given(@"I set deposit to false")]
        public void GivenISetDeposit()
        {
            hotelBookingsPage.SetDeposit(bookingDetails.Deposit);
        }

        [Given(@"I type valid and logical dates directly into the checkin and checkout fields in big endian format yyyy-mm-dd")]
        public void GivenITypeValidAndLogicalDatesDirectlyIntoTheCheckinAndCheckoutFieldsInBigEndianFormat()
        {
            hotelBookingsPage.SetDates(bookingDetails.CheckIn, bookingDetails.CheckOut);
        }

        [StepDefinition(@"I click save")]
        public void WhenIClickSave()
        {
            hotelBookingsPage.ClickSave();
        }

        [Then(@"my reservation will be created")]
        public void ThenMyReservationWillBeCreated()
        {
           hotelBookingsPage.BookingCreated().Should().BeTrue();
        }

        [Then(@"a booking is NOT created")]
        public void ThenABookingIsNOTCreated()
        {
            hotelBookingsPage.BookingCreated().Should().BeFalse();
        }

        [Then(@"my booking details are correct")]
        public void ThenMyBookingDetailsAreCorrect()
        {
            hotelBookingsPage.CheckBookingDetails(bookingDetails).Should().BeTrue();
        }

        [Given(@"I have created a booking")]
        public void GivenIHaveCreatedABooking()
        {
            GivenIEnterValidDetailsIntoAllRequiredInputFields();
            GivenISetDeposit();
            GivenITypeValidAndLogicalDatesDirectlyIntoTheCheckinAndCheckoutFieldsInBigEndianFormat();
        }

        [Given(@"I have one or more bookings")]
        public void GivenIHaveOneOrMoreBookings()
        {
            if (hotelBookingsPage.GetBookingsCount() < 1)
            {
                GivenIHaveCreatedABooking();
                WhenIClickSave();
            }
        }

        [When(@"I delete the booking")]
        public void DeleteTheBooking()
        {
            hotelBookingsPage.DeleteTheLastBooking();
        }

        [When(@"I delete all the bookings")]
        public  void WhenIDeleteAllTheBookings()
        {
            var numberOfBookings = GetBookingsCount();
            for (int i=0; i < numberOfBookings; i++)
            {
                DeleteTheBooking();
            }
        }

        [Then(@"all the bookings will be deleted")]
        public void ThenAllTheBookingsWillBeDeleted()
        {
            GetBookingsCount().Should().Be(0);
        }

        [Then(@"the booking will be deleted")]
        public void ThenTheBookingWillBeDeleted()
        {
            hotelBookingsPage.BookingDeleted().Should().BeTrue();
        }

        private int GetUniqueValue()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }
    }
}
