using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using WebDriverPractice.Business.Pages;

namespace WebDriverPractice.Tests.Steps
{
	[Binding]
	public class DownloadSteps
	{
		private readonly IWebDriver _driver;
		private readonly EpamMainPage _epamMainPage;
		private AboutPage _aboutPage = null!;
		private bool _doesFileExist;

		public DownloadSteps(ScenarioContext scenarioContext)
		{
			_driver = (IWebDriver)scenarioContext["WebDriver"];
			_epamMainPage = new EpamMainPage(_driver);
		}

		[When(@"the user clicks the About button")]
		public void WhenTheUserClicksTheAboutButton()
		{
			_aboutPage = _epamMainPage.ClickAboutButton();
		}

		[When(@"the user clicks the Download button")]
		public void WhenTheUserClicksTheDownloadButton()
		{
			_doesFileExist = _aboutPage.ClickDownloadButtonAndWaitUntilDone();
		}

		[Then(@"the file is downloaded")]
		public void TheTheFileIsDownloaded()
		{
			bool canFileBeDeleted = _doesFileExist;

			var fileName = AboutPage.DownloadFilePath;

			if (canFileBeDeleted)
			{
				File.Delete(fileName);
			}

			Assert.IsTrue(_doesFileExist, "File does not exist.");
		}
	}
}