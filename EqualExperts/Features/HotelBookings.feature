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

Scenario: Delete a booking 
Given I have created a booking 
And I click save
When I delete the booking 
Then the booking will be deleted 

Scenario: Delete all bookings
Given I have one or more bookings
When I delete all the bookings
Then all the bookings will be deleted

Scenario Outline: validation of input fields 
Given I entered the following data into the booking form:
| FirstName     | LastName  | Price   | Deposit   | CheckIn   | CheckOut   |
| <firstName>   | <surname> | <price> | <deposit> | <checkIn> | <checkOut> |
When I click save 
Then a booking is NOT created 

Examples:
| firstName | surname      | price  | deposit | checkIn    | checkOut    |
|           | validSurname | 10.01  | false   | 2020-10-10 | 2020-10-11  | 
| 213       | validSur     | 10.02  | false   | 2020-10-10 | 2020-10-11  | 
| $%#%      | validSur     | 10.03  | false   | 2020-10-10 | 2020-10-11  | 
| vaidfirst |              | 10.04  | false   | 2020-10-10 | 2020-10-11  |
| vaidfirst |       1213   | 10.05  | false   | 2020-10-10 | 2020-10-11  |
| vaidfirst |   $%#%       | 10.06  | false   | 2020-10-10 | 2020-10-11  |
| vaidfirst |   validSur   |        | false   | 2020-10-10 | 2020-10-11  |
| vaidfirst |   validSur   | fds    | false   | 2020-10-10 | 2020-10-11  |
| vaidfirst |   validSur   | -10    | false   | 2020-10-10 | 2020-10-11  |
| vaidfirst |   validSur   | 10.123 | false   | 2020-10-10 | 2020-10-11  |
| vaidfirst |   validSur   | 10.07  | false   |            | 2020-10-11  |
| vaidfirst |   validSur   | 10.08  | false   | tenth April| 2020-10-11  |
| vaidfirst |   validSur   | 10.09  | false   | $%#%       | 2020-10-11  |
| vaidfirst |   validSur   | 10.10  | false   |20201010    | 2020-10-11  |
| vaidfirst |   validSur   | 10.11  | false   |2020-10-10  |             |
| vaidfirst |   validSur   | 10.12  | false   |2020-10-10  | third April |
| vaidfirst |   validSur   | 10.13  | false   |2020-10-10  | $%#%        |
| vaidfirst |   validSur   | 10.00  | false   |2020-10-10  | 20201010    |



