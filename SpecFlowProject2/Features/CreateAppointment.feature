Feature: Create Appointment

Background: 
    Given I have logged in	
	And I open scheduler page
	And scheduler page is opened

@mytag
Scenario Outline: Create appointment with different types
	When I create appointment with <type> type
	Then appointment type should be created

	Examples: 
	| type         |
	| Billable     |
	| Non-Billable |
	| Travel       |


@mytag
Scenario Outline: Edit appointments with different types
	Given I create appointment with <type> type
	And appointment type should be created
	When I edit the appointment with <type> type
	Then Changes should be saved 

	Examples: 
	| type         |
	| Billable     |
	| Non-Billable |
	| Travel       |

@tag
Scenario Outline: Delete appointments with different types
	Given I create appointment with <type> type
	And appointment type should be created
	When I delete the appointment with <type> type
	Then Appointment should not be displayed 

	Examples: 
	| type         |
	| Billable     |
	| Non-Billable |
	| Travel       |