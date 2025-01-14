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

			//_driver.Manage().Window.Maximize();
			//_driver.Url = "https://www.epam.com";
		}

		[TestMethod]
		[DataRow("JavaScript")]
		public void CareerSearch_ProvideKeyword_GetProperResult(string testData)
		{
			bool isSearchResultDisplayed = false;

			_epamMainPage.ClickCareersButton();

			var carrerSearchResultPage = new CarrerSearchPage(_driver, _wait, _actions, _driverHelper);

			//carrerSearchResultPage.ClickRemoteOptionCheckbox();

			//carrerSearchResultPage.SendKeysToKeywordsInputField(testData);

			//carrerSearchResultPage.ClickLocationsDropdownButton();

			isSearchResultDisplayed = carrerSearchResultPage.PerfromCarrerSearchOperations(testData);

			Assert.IsTrue(isSearchResultDisplayed);
		}

		[TestMethod]
		[DataRow("blockchain")]
		[DataRow("cloud")]
		[DataRow("automation")]
		public void GlobalSearch_ProvideInput_GetProperResult(string keyword)
		{
			bool doAllLinksContainKeyword = false;

			_epamMainPage.SearchForKeyword(keyword);

			//IList<IWebElement> searchResultsContainer = wait.Until(driver => driver.FindElements(By.XPath("//div[@class='search-results__items']//a")));
			//wait.Until(driver => searchResultsContainer.All(element => element.Displayed));

			//doAllLinksContainKeyword = searchResultsContainer.All(item => item.Text.Contains(keys));

			var searchResultPage = new SearchResultPage(_driver, _wait, _actions, _driverHelper);

			doAllLinksContainKeyword = searchResultPage.DoAllLinksContainKeyword(keyword);
			///TODO really all links? you mean <a> ?!?!
			Assert.IsTrue(doAllLinksContainKeyword);
		}

		[TestMethod]
		[DataRow("C:\\Users\\wassl\\Downloads\\EPAM_Corporate_Overview_Q4_EOY.pdf")]
		public void AboutPage_ClickDownload_Downloads(string filePath)
		{
			_epamMainPage.ClickAboutButton();

			var aboutPage = new AboutPage(_driver, _wait, _actions, _driverHelper);

			aboutPage.Download();

			Thread.Sleep(10000); ///TODO - out z tym

			//var filePath = Path.Combine(@"C:\Users\wassl\Downloads\", fileName); 

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
			insightsPage.ClickSliderButton();
			insightsPage.ClickSliderButton();
			//Thread.Sleep(2000);

			var slideText = insightsPage.GetSlideText();

			insightsPage.ClickReadMoreButton();
			//Thread.Sleep(5000);

			///TODO create additional PageObjects
			///
			var readMorePageTitle = insightsPage.GetReadMorePageTitle();

			Assert.AreEqual(slideText, readMorePageTitle);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_driver.Dispose();
		}
	}
}
