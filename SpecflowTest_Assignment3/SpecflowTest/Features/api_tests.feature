Feature: api_tests
	In order to atest my api
	As a QE
	I want to execute following tests scenaiors

@mytag
Scenario: Verify add/view/delete employee from API
	Given I send GET request to my API
	Then I should get "200" in response
	When I send a POST request to API to add employee
	Then I should get "200" in response
	When I send GET request to API for an employee
	Then I should have requested employee in result
	When I send DELETE request to API with employeeID
	Then I should get "200" in response
	When I send GET request to API for the deleted employee
	Then I should not receive deleted employee in result