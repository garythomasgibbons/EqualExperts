Feature: HotelBookings

Background: I am viewing the Equal Experts booking url 
Given I have a browser open 
  And I the url is 'http://hotel-test.equalexperts.io/'

Scenario: Create a booking typing date values in big endian format
Given I enter valid details into all required input fields 
  And I set deposit to false 
  And I type valid and logical dates directly into the checkin and checkout fields in big endian format yyyy-mm-dd 
When I click save 
Then my reservation will be created 
  And my booking details are correct


