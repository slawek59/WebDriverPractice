using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal.Logging;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Data;
using WebDriverPractice.Driver;
using WebDriverPractice.Helpers;
using WebDriverPractice.Pages;
using Serilog;
using Log = Serilog.Log;

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

		public TestContext TestContext { get; set; }

		//assemblyinitialize?

		[AssemblyInitialize]
		public static void AssemblyInitialize(TestContext testContext)
		{
			Log.Logger = new LoggerConfiguration()
				.WriteTo.Console()
				.WriteTo.File($"test-logs.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			Log.Information("Assembly initialization.");
		}


		[TestInitialize]
		public void Setup()
		{
			var isHeadlessMode = Environment.GetEnvironmentVariable("setting") == "headless";

			_driver = DriverInstance.GetInstance(isHeadlessMode);

			_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
			{
				PollingInterval = TimeSpan.FromSeconds(0.25),
				Message = "Element not found."
			};
			_actions = new Actions(_driver);
			_driverHelper = new WebDriverHelper(_driver, _wait, _actions);
			_epamMainPage = new EpamMainPage(_driver, _wait, _actions, _driverHelper);
			_epamMainPage.OpenPage();
			_epamMainPage.ClickCookieAcceptButton();

			Log.Information($"Test initialization for {TestContext.TestName}.");
		}

		[TestMethod]
		[DataRow("JavaScript")]
		public void CareerSearch_ProvideKeyword_GetProperResult(string testData)
		{
			Log.Information($"{TestContext.TestName} test method starts");

			bool isSearchResultDisplayed = false;

			var carrerSearchPage = _epamMainPage.ClickCareersButton();

			var carrerSearchResultsPage = carrerSearchPage.PerfromCarrerSearchOperations(testData);

			var jobDetailsPage = carrerSearchResultsPage.NavigateToLatestResult();

			isSearchResultDisplayed = jobDetailsPage.IsSearchResultDisplayed(testData);

			Assert.IsTrue(isSearchResultDisplayed, "Search result was not displayed.");
		}

		[TestMethod]
		[DataRow("blockchain")]
		[DataRow("cloud")]
		[DataRow("automation")]
		public void GlobalSearch_ProvideInput_GetProperResult(string keyword)
		{
			Log.Information($"{TestContext.TestName} test method starts");

			bool doAllLinksContainKeyword = false;

			var searchResultPage = _epamMainPage.SearchForKeyword(keyword);

			doAllLinksContainKeyword = searchResultPage.DoAllLinksContainKeyword(keyword);

			Assert.IsTrue(doAllLinksContainKeyword, $"All links do not contain the searched keyword, which is {keyword}");
		}

		[TestMethod]
		[DataRow(AboutPage.DownloadFilePath)]
		public void AboutPage_ClickDownload_Downloads(string fileName)
		{
			Log.Information($"{TestContext.TestName} test method starts");
			
			var aboutPage = _epamMainPage.ClickAboutButton();

			var doesFileExist = aboutPage.ClickDownloadButtonAndWaitUntilDone();

			var canFileBeDeleted = doesFileExist;

			if (canFileBeDeleted)
			{
				File.Delete(fileName);
			}
			
			Assert.IsTrue(doesFileExist, "File does not exist.");
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

			Assert.AreEqual(slideText, insightsReadMorePageTitle, "Texts are not equal.");
		}

		[TestCleanup]
		public void Cleanup()
		{
			Log.Information("Closing WebDriver.");
			_driver.Quit();

			if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
			{
				Log.Error($"{TestContext.TestName} failed.");
			}
			else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
			{
				Log.Information($"{TestContext.TestName} passed.");
			}
		}

		[AssemblyCleanup]
		public static void AssemblyCleanup()
		{
			Log.CloseAndFlush();
		}
	}
}


/// TODO TAF
//The solution should be split into next layers:

//Core layer(core functionality of TAF, that aren’t project specific).

//Business layer(should contain all functionality, related with business logic of the tested application.

//Tests layer (should contain automated tests, TAF configuration).

//Initialization of WebDriver instance should be done with helping Factory design pattern (consider adding dedicated class for Browser Factory functionality)

//	All repeating actions, that should be done from test to test, should be aggregated in an abstract base class (actions such as initialization and closing a browser and so on).

//Logging should be implemented (NLog, log4net or Serilog). Each test should generate logs from what should be clear test actions. TAF should support logging to both, file and console, and opportunity to use different logging levels (Error, Info, etc.). Min log level should be configurable via TAF configuration. When the test fails, a screenshot with the date and time should be taken. 


//Tasks #1-#4:
//Refactor automated tests created in previous module to follow SOLID, DRY, KISS, YAGNI principles, use Design Patterns (Singleton and Browser Factory) and add logging mechanism.  Solution should have Layers in Architecture and be able to execute on several environments.
