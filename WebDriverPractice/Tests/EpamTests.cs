using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using WebDriverPractice.Data;
using WebDriverPractice.Driver;
using WebDriverPractice.Pages;

namespace WebDriverPractice.Tests
{
	[TestClass]
	public class EpamTests
	{
		private IWebDriver _driver = null!;
		private EpamMainPage _epamMainPage = null!;

		[TestInitialize]
		public void Setup()
		{
			_driver = DriverInstance.GetInstance();
			_epamMainPage = new EpamMainPage(_driver);
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

			Assert.IsTrue(isSearchResultDisplayed, "Search result was not displayed.");
		}

		[TestMethod]
		[DataRow("BLOCKCHAIN")]
		[DataRow("Cloud")]
		[DataRow("Automation")]
		public void GlobalSearch_ProvideInput_GetProperResult(string keyword)
		{
			bool doAllLinksContainKeyword = false;

			var searchResultPage = _epamMainPage.SearchForKeyword(keyword);

			doAllLinksContainKeyword = searchResultPage.DoAllLinksContainKeyword(keyword);

			Assert.IsTrue(doAllLinksContainKeyword,"All links do not contain the searched keyword.");
		}

		[TestMethod]
		[DataRow(AboutPage.DownloadFilePath)]
		public void AboutPage_ClickDownload_Downloads(string fileName)
		{
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
			_driver.Quit();
		}
	}
}


/// TODO list:

//The only object to send to Page's constructor is IWebDriver instance. Refactor the framework in the next way:

//Change constructor of pages to obtain only IWebDriver

//Make WebDriverHelper class static, rename it to IWebDriverExtensions and make all methods as extensions to IWebDriver(https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) and you 'll have the IwebDriver instance inside the page object and just use it to call for extensions.

//Using DriverInstance.GetInstance you can initialize driver inside the Page objects - in that way you will not need to create instances of Helper , WebDriver, Wait, Actions inside the PO but not in test, cause if you make it all in tests it will produce a duplication of code, and if we cover it in one place (BasePage) the code will not be duplicated