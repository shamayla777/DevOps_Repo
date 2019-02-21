Feature: ui_test_FF
	In order to test this webservice on FF
	As a QE 
	I want these tests to verify it


Scenario: Add New Employee on FF
Given I navigate to my main page on FF
When I enter valid Employee Information on FF
Then I should see employee in the list on FF

Scenario: Delete Employee on FF
Given I navigate to my main page on FF
When I enter valid Employee ID on FF
And I click on Delete button on FF
Then I should not see employee in the list on FF