# EqualExperts - Hotel Bookings Form

## Functional Tests

**Background:** I am viewing the booking url <br>
*Given I have a browser open* <br>
**And the browser has javascript enabled**
*And I the url is 'http://hotel-test.equalexperts.io/'* 

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

**Scenario:** Create a booking typing date values in big endian format<br>
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

**Scenario:** Create a duplicate booking <br>
*Given I have created a booking* <br>
*And I enter duplicate details into all fields* <br>
*When I click Save* <br>
*Then a booking is NOT created* <br>

**Scenario Outline:** validation of input fields <br>
*Given I enter `<firstName>`, `<surName>`, `<price>`, `<checkIn>`, `<checkOut>`* <br>
*When I click Save* <br>
*Then a booking is NOT created* <br>

**Examples:** <br>

 firstName | surName | price | checkIn | checkOut 
  --- | --- | ---| ---  | --- 
|           | validSurname | 10.00 | 2020-10-10 | 2020-10-11 | 










