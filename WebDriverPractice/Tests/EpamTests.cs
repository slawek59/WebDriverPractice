using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;
using WebDriverPractice.Pages;

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
		[DataRow("C:\\Users\\wassl\\Downloads\\EPAM_Corporate_Overview_Q4_EOY.pdf")]
		public void AboutPage_ClickDownload_Downloads(string filePath)
		{
			var aboutPage = _epamMainPage.ClickAboutButton();

			aboutPage.ClickDownloadButtonAndWaitUntilDone();

			Thread.Sleep(10000); ///TODO - out z tym

			var doesFileExist = File.Exists(filePath);

			var canFileBeDeleted = doesFileExist;

			if (canFileBeDeleted)
			{
				File.Delete(filePath);
			}

			Assert.IsTrue(doesFileExist);
		}

		[TestMethod]
		public void InsightsPage_ClickReadMoreButtonOnThirdSlide_ValidateArticleName()
		{
			_epamMainPage.ClickInsightsButton();

			var insightsPage = new InsightsPage(_driver, _wait, _actions, _driverHelper);
			
			/// TODO add parametrized method in POM to click twice
			insightsPage.ClickSliderButton();
			insightsPage.ClickSliderButton();

			var slideText = insightsPage.GetSlideText();

			insightsPage.ClickReadMoreButton();

			///TODO create additional PageObjects
			///
			var readMorePageTitle = insightsPage.GetReadMorePageTitle();

			Assert.AreEqual(slideText, readMorePageTitle);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_driver.Quit();
		}
	}
}
