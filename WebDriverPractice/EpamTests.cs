using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebDriverPractice
{
	[TestClass]
	public class EpamTests
	{
		private IWebDriver _driver;
		private WebDriverWait _wait;
		private EpamMainPage _epamMainPage;
		private Actions _actions;

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
			_epamMainPage = new EpamMainPage(_driver, _wait, _actions);
			_epamMainPage.MaximizeWindow();
			_epamMainPage.OpenPage();

			//_driver.Manage().Window.Maximize();
			//_driver.Url = "https://www.epam.com";
		}

		[TestMethod]
		[DataRow("JavaScript")]
		public void CareerSearch_ProvideKeyword_GetProperResult(string testData)
		{
			bool isSearchResultDisplayed;

			try
			{
				_epamMainPage.ClickCookieAcceptButton();
				_epamMainPage.ClickCareersButton();


				

				

				var remoteOption = _wait.Until(driver => driver.FindElement(By.XPath("//input[@name='remote']")));

				_actions
					.MoveToElement(remoteOption)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.Perform();

				var keywordsInputField = _wait.Until(driver => driver.FindElement(By.Id("new_form_job_search-keyword")));

				_actions
					.MoveToElement(keywordsInputField)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.SendKeys(testData)
					.Perform();

				var locationsDropdown = _wait.Until(driver => driver.FindElement(By.CssSelector("span.select2-selection__rendered")));

				_actions
					.MoveToElement(locationsDropdown)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.Perform();

				var allLocationsOption = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'All Locations')]")));

				_actions
					.MoveToElement(allLocationsOption)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.Perform();

				var findButton = _wait.Until(driver => driver.FindElement(By.XPath("//form/child::button")));

				_actions
					.MoveToElement(findButton)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.Perform();

				var latestViewAndApplyButton = _wait.Until(driver => driver.FindElement(By.XPath("//ul[@class='search-result__list']/li[1]//a[contains(text(), 'View and apply')]")));

				var sortByDate = _wait.Until(driver => driver.FindElement(By.XPath("//input[@name='sort']/following-sibling::label[text()='Date']")));
				_wait.Until(driver => sortByDate.Enabled);

				_actions
					.MoveToElement(latestViewAndApplyButton);

				_actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(sortByDate)
					.Perform();

				_actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(latestViewAndApplyButton)
					.Perform();
				
				var finalContent = _wait.Until(driver => driver.FindElement(By.XPath("//div[@class='section__wrapper']")));
				_wait.Until(driver => finalContent.Displayed);

				isSearchResultDisplayed = finalContent.Text.Contains($"{testData}", StringComparison.OrdinalIgnoreCase);

				Console.WriteLine(isSearchResultDisplayed);

			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred during the CareerSearch_ProvideKeyword_GetProperResult", ex);
			}

			Assert.IsTrue(isSearchResultDisplayed);
		}

		[TestMethod]
		[DataRow("blockchain")]
		[DataRow("cloud")]
		[DataRow("automation")]
		public void GlobalSearch_ProvideInput_GetProperResult(string keys)
		{
			bool doAllLinksContainKeyword;

			try
			{
				var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
				{
					PollingInterval = TimeSpan.FromSeconds(0.25),
					Message = "Element not found."
				};

				var actions = new Actions(_driver);

				var cookie = wait.Until(driver => driver.FindElement(By.Id("onetrust-accept-btn-handler")));

				actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(cookie)
					.Perform();

				var magnifier = wait.Until(driver => driver.FindElement(By.XPath("//button[@class='header-search__button header__icon']")));

				actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(magnifier)
					.Perform();

				var input = wait.Until(driver => driver.FindElement(By.XPath("//input[@name='q']")));

				actions
					.Click(input)
					.Pause(TimeSpan.FromSeconds(1))
					.SendKeys(keys)
					.Perform();

				var findButton = wait.Until(driver => driver.FindElement(By.XPath("//span[contains(text(), 'Find')]/parent::*")));

				actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(findButton)
					.Perform();

				IList<IWebElement> searchResultsContainer = wait.Until(driver => driver.FindElements(By.XPath("//div[@class='search-results__items']//a")));
				wait.Until(driver => searchResultsContainer.All(element => element.Displayed));

				doAllLinksContainKeyword = searchResultsContainer.All(item => item.Text.Contains(keys));
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred during the GlobalSearch_ProvideInput_GetProperResult", ex);
			}

			Assert.IsTrue(doAllLinksContainKeyword);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_driver.Quit();
		}
	}
}
