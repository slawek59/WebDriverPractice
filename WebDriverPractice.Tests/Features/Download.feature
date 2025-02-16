Feature: Downlaod

Scenario: DownloadVerification
	Given the user is on the Epam website
	When the user clicks on About button
	And the user clicks the Download button
	Then the file is downloaded
