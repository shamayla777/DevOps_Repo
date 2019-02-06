Feature: Employee Webservice tests
	In order to test this webservice 
	As a QE 
	I want these tests to verify it

Scenario: Add New Employee
Given I navigate to my main page 
When I enter valid Employee Information 
Then I should see employee in the list 

Scenario: Delete Employee 
Given I navigate to my main page 
When I enter valid Employee ID 
And I click on Delete button 
Then I should not see employee in the list