Feature: CareerSearch

Scenario Outline: Provide keyword and get a proper search result
	Given the user is on the Epam homepage
	When the user searches for "<Keyword>"
	Then the Career Search should contain the Keyword.

Examples:
	| Keyword    |
	| JavaScript |
