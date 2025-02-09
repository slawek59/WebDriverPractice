Feature: CareerSearch

Scenario Outline: Provide keyword and get a proper search result
	Given the user is on the Epam homepage
	When the user searches for "<CareerKeyword>" career keyword
	Then the Career Search should contain the Keyword.

Examples:
	| CareerKeyword    |
	| JavaScript |
