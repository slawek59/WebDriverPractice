Feature: Insights

Scenario: InsightsSliderVerification
	Given the user visits the Epam website
	When the user clicks on the Insights button
	And the user clicks slider button two times
	And the user clicks 'Read More' button
	Then the user sees a proper header
