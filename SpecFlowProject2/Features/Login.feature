Feature: Login
     In order to access my account
     As a user of the website
     I want to log into the website

@smoke
Scenario: Login
    Given I have navigated to website 
	And I have entered valid login and password 
	When I press logIn button
	Then I should navigate to the main page of the site
