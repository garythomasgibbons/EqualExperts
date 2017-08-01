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
When I delete the booking 
Then the booking will be deleted 

Scenario Outline: validation of input fields 
Given I enter <firstName>, <surname>, <price>, <checkIn>, <checkOut> 
When I click Save 
Then a booking is NOT created 

Examples:
| firstName | surname      | price  | checkIn     | checkOut    |
|           |              |        |             |             | 
|           | validSurname | 10.00  | 2020-10-10  | 2020-10-11  | 
| 213       | validSur     | 10.00  | 2020-10-10  | 2020-10-11  | 
| $%#%      | validSur     | 10.00  | 2020-10-10  | 2020-10-11  | 
| vaidfirst |              | 10.00  | 2020-10-10  | 2020-10-11  |
| vaidfirst |       1213   | 10.00  | 2020-10-10  | 2020-10-11  |
| vaidfirst |   $%#%       | 10.00  | 2020-10-10  | 2020-10-11  |
| vaidfirst |   validSur   |        | 2020-10-10  | 2020-10-11  |
| vaidfirst |   validSur   | fds    | 2020-10-10  | 2020-10-11  |
| vaidfirst |   validSur   | -10    | 2020-10-10  | 2020-10-11  |
| vaidfirst |   validSur   | 10.123 | 2020-10-10  | 2020-10-11  |
| vaidfirst |   validSur   | 10     |             | 2020-10-11  |
| vaidfirst |   validSur   | 10     | tenth April | 2020-10-11  |
| vaidfirst |   validSur   | 10.00  | $%#%        | 2020-10-11  |
| vaidfirst |   validSur   | 10.00  | 20201010    | 2020-10-11  |
| vaidfirst |   validSur   | 10.00  | 2020-10-10  |             |
| vaidfirst |   validSur   | 10.00  | 2020-10-10  | third April |
| vaidfirst |   validSur   | 10.00  | 2020-10-10  | $%#%        |
| vaidfirst |   validSur   | 10.00  | 2020-10-10  | 20201010    |



