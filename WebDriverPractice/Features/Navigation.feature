Feature: Navigation

Scenario Outline: Validate Navigation to Services Section
	Given the user is on the Epam homepage
	When the user selects "<Category>" from the Services dropdown
	Then the page title should be "<ExpectedTitle>"
	And the section "Our Related Expertise" should be displayed

Examples:
	| Category       | ExpectedTitle  |
	| Generative AI  | Generative AI  |
	| Responsible AI | Responsible AI |
