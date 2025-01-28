using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using WebDriverPractice.Data;
using WebDriverPractice.Driver;
using WebDriverPractice.Pages;
using Log = Serilog.Log;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Tests
{
	[TestClass]
	public class EpamTests
	{
		private IWebDriver _driver = null!;
		private EpamMainPage _epamMainPage = null!;

		public TestContext TestContext { get; set; }

		//assemblyinitialize?

		[AssemblyInitialize]
		public static void AssemblyInitialize(TestContext testContext)
		{
			var now = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff");
			///TODO into separate class (path setting as well)
			Log.Logger = new LoggerConfiguration()
				.WriteTo.Console()
				.WriteTo.File(Path.Combine(Environment.CurrentDirectory, $"Logs_{now}.txt"))
				.CreateLogger();

			Log.Information("Assembly initialization.\n");
		}


		[TestInitialize]
		public void Setup()
		{
			_driver = DriverInstance.GetInstance();
			_epamMainPage = new EpamMainPage(_driver);
			_epamMainPage.OpenPage();
			_epamMainPage.ClickCookieAcceptButton();

			Log.Information($"Test initialization for {TestContext.TestName}.");
		}

		[TestMethod]
		[DataRow("JavaScript")]
		public void CareerSearch_ProvideKeyword_GetProperResult(string testData)
		{
			Log.Information($"{TestContext.TestName} test method starts.");

			bool isSearchResultDisplayed = false;

			var carrerSearchPage = _epamMainPage.ClickCareersButton();

			var carrerSearchResultsPage = carrerSearchPage.PerfromCarrerSearchOperations(testData);

			var jobDetailsPage = carrerSearchResultsPage.NavigateToLatestResult();

			isSearchResultDisplayed = jobDetailsPage.IsSearchResultDisplayed(testData);

			Assert.IsTrue(isSearchResultDisplayed, "Search result was not displayed.");
		}

		[TestMethod]
		[DataRow("BLOCKCHAIN")]
		[DataRow("Cloud")]
		[DataRow("Automation")]
		public void GlobalSearch_ProvideInput_GetProperResult(string keyword)
		{
			Log.Information($"{TestContext.TestName} test method starts with '{keyword}' keyword.");
			/// TODO case insensitive????
			bool doAllLinksContainKeyword = false;
			/// TODO sth wrong in pom
			var searchResultPage = _epamMainPage.SearchForKeyword(keyword);

			doAllLinksContainKeyword = searchResultPage.DoAllLinksContainKeyword(keyword);

			Assert.IsTrue(doAllLinksContainKeyword, $"All links do not contain the searched keyword, which is {keyword}");
		}

		[TestMethod]
		[DataRow(AboutPage.DownloadFilePath)]
		public void AboutPage_ClickDownload_Downloads(string fileName)
		{
			Log.Information($"{TestContext.TestName} test method starts and checking for '{fileName}' download.");
			
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
			Log.Information($"{TestContext.TestName} test method starts. Number of swipes: {clickTimes}.");

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
			///TODO this stuff as non-specific should probably be also placed into a separate place

			if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
			{
				Log.Error($"\n!---{TestContext.TestName} FAILED.---!\n");
				var screenshotDriver = (ITakesScreenshot)_driver;
				ScreenshotMaker.TakeBrowserScreenshot(screenshotDriver);
			}
			else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
			{
				Log.Information($"{TestContext.TestName} PASSED.");
			}

			Log.Information($"Closing WebDriver.\n");
			_driver.Quit();
		}

		[AssemblyCleanup]
		public static void AssemblyCleanup()
		{
			Log.Information($"Assembly Cleanup.");

			Log.CloseAndFlush();
		}
	}
}
