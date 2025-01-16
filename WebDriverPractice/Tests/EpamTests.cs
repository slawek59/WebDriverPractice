using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;
using WebDriverPractice.Pages;
using WebDriverPractice.Data;

namespace WebDriverPractice.Tests
{
	[TestClass]
	public class EpamTests
	{
		private IWebDriver _driver;
		private WebDriverWait _wait;
		private EpamMainPage _epamMainPage;
		private Actions _actions;
		private WebDriverHelper _driverHelper;

		[TestInitialize]
		public void Setup()
		{
			///TODO incorporate headless mode

			///TODO - download setup
			var chromeOptions = new ChromeOptions();
			chromeOptions.AddUserProfilePreference("download.default_directory", @"C:\Users\wassl\Downloads\");
			chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
			chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
			///TODO - end of download setup
			///
			_driver = new ChromeDriver(@"C:\chromedriver", chromeOptions);

			_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
			{
				PollingInterval = TimeSpan.FromSeconds(0.25),
				Message = "Element not found."
			};

			_actions = new Actions(_driver);
			_driverHelper = new WebDriverHelper(_driver, _wait, _actions);
			_epamMainPage = new EpamMainPage(_driver, _wait, _actions, _driverHelper);
			_epamMainPage.MaximizeWindow();
			_epamMainPage.OpenPage();
			_epamMainPage.ClickCookieAcceptButton();
		}

		[TestMethod]
		[DataRow("JavaScript")]
		public void CareerSearch_ProvideKeyword_GetProperResult(string testData)
		{
			bool isSearchResultDisplayed = false;

			var carrerSearchPage = _epamMainPage.ClickCareersButton();

			var carrerSearchResultsPage = carrerSearchPage.PerfromCarrerSearchOperations(testData);

			var jobDetailsPage = carrerSearchResultsPage.NavigateToLatestResult();

			isSearchResultDisplayed = jobDetailsPage.IsSearchResultDisplayed(testData);

			Assert.IsTrue(isSearchResultDisplayed);
		}

		[TestMethod]
		[DataRow("blockchain")]
		[DataRow("cloud")]
		[DataRow("automation")]
		public void GlobalSearch_ProvideInput_GetProperResult(string keyword)
		{
			bool doAllLinksContainKeyword = false;

			var searchResultPage = _epamMainPage.SearchForKeyword(keyword);

			doAllLinksContainKeyword = searchResultPage.DoAllLinksContainKeyword(keyword);

			Assert.IsTrue(doAllLinksContainKeyword);
		}

		[TestMethod]
		public void AboutPage_ClickDownload_Downloads()
		{
			var aboutPage = _epamMainPage.ClickAboutButton();

			var doesFileExist = aboutPage.ClickDownloadButtonAndWaitUntilDone();

			var canFileBeDeleted = doesFileExist;

			if (canFileBeDeleted)
			{
				File.Delete(aboutPage.DownloadFilePath);
			}

			Assert.IsTrue(doesFileExist);
		}

		[TestMethod]
		[DataRow(DataConstants.ClickTimes)]
		public void InsightsPage_ClickReadMoreButtonOnThirdSlide_ValidateArticleName(int clickTimes)
		{
			var insightsPage = _epamMainPage.ClickInsightsButton();

			insightsPage.ClickSliderButton(clickTimes);

			var slideText = insightsPage.GetSlideText();

			var insightsReadMorePage = insightsPage.ClickReadMoreButton();

			var insightsReadMorePageTitle = insightsReadMorePage.GetReadMorePageTitle();

			Assert.AreEqual(slideText, insightsReadMorePageTitle);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_driver.Quit();
		}
	}
}

/// TODO get rid off reduntant usings, waits and actions etc; 