Feature: Downlaod

Scenario: DownloadVerification
	When the user clicks the About button
	And the user clicks the Download button
	Then the file is downloaded
