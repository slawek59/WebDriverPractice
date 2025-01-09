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
			_driver = new ChromeDriver();

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

			//_driver.Manage().Window.Maximize();
			//_driver.Url = "https://www.epam.com";
		}

		[TestMethod]
		[DataRow("JavaScript")]
		public void CareerSearch_ProvideKeyword_GetProperResult(string testData)
		{
			bool isSearchResultDisplayed = false;
			_epamMainPage.ClickCookieAcceptButton();

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

			Assert.IsTrue(doAllLinksContainKeyword);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_driver.Dispose();
		}
	}
}
