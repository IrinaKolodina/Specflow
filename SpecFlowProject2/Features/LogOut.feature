Feature: LogOut
    As a user of the website
    I want to log out from the website
    Background: 
    Given I have navigated to website 
	And I have logged in

@smoke
Scenario: Logout    
	When I press logout button
    Then user should be logged out