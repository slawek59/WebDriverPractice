Feature: GlobalSearch

Scenario Outline: Perfom a search on the Epam website
	Given the user is on the Epam page
	When the user searches for "<Keyword>" keyword
	Then all the search result links contains the "<Keyword>" keyword


Examples:
	| Keyword    |
	| BLOCKCHAIN |
	| Cloud      |
	| Automation |
