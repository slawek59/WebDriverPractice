using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverPractice
{
	// TODO change file and class names and remake structure?  
	[TestClass]
	public class EpamTests
	{
		IWebDriver driver;

		[TestInitialize]
		public void Setup()
		{
			driver = new ChromeDriver();
			//driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Manage().Window.Maximize();
			driver.Url = "https://www.epam.com";
		}

		[TestMethod]
		[DataRow("JavaScript")]
		public void CareerSearch_ProvideKeyword_GetProperResult(string testData)
		{
			bool answer = false;

			try
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
				{
					PollingInterval = TimeSpan.FromSeconds(0.25),
					Message = "Element not found."
				};

				var actions = new Actions(driver);

				var cookie = wait.Until(driver => driver.FindElement(By.Id("onetrust-accept-btn-handler")));
				//cookie.Click();

				actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(cookie)
					.Perform();

				//var cookie = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
				//if (cookie.Enabled || cookie.Displayed)
				//{
				//	cookie.Click();
				//}

				var careersButton = wait.Until(driver => driver.FindElement(By.XPath("//span/a[contains(@class, 'top-navigation__item-link js-op') and @href='/careers']")));
				careersButton.Click();

				var remoteOption = wait.Until(driver => driver.FindElement(By.XPath("//input[@name='remote']")));
				//remoteOption.Click();

				actions
					.MoveToElement(remoteOption)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.Perform();

				var keywordsInputField = wait.Until(driver => driver.FindElement(By.Id("new_form_job_search-keyword")));
				//keywordsInputField.SendKeys(testData);

				actions
					.MoveToElement(keywordsInputField)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.SendKeys(testData)
					.Perform();

				//keywordsInputField.SendKeys(testData);

				var locationsDropdown = wait.Until(driver => driver.FindElement(By.CssSelector("span.select2-selection__rendered")));

				//wait.Until(d => locationsDropdown.Enabled);

				//locationsDropdown.Click();

				actions
					.MoveToElement(locationsDropdown)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.Perform();

				var allLocationsOption = wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'All Locations')]")));
				//allLocationsOption.Click();

				actions
					.MoveToElement(allLocationsOption)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.Perform();


				var findButton = wait.Until(driver => driver.FindElement(By.XPath("//form/child::button")));
				//findButton.Click();

				actions
					.MoveToElement(findButton)
					.Pause(TimeSpan.FromSeconds(1))
					.Click()
					.Perform();

				//var sortByDate = wait.Until(driver => driver.FindElement(By.XPath("//input[@name='sort']/following-sibling::label[text()='Date']")));
				//wait.Until(driver => sortByDate.Enabled);
				////sortByDate.Click();

				//actions
				//	.Pause(TimeSpan.FromSeconds(1))
				//	.Click(sortByDate)
				//	.Perform();


				var latestViewAndApplyButton = wait.Until(driver => driver.FindElement(By.XPath("//ul[@class='search-result__list']/li[1]//a[contains(text(), 'View and apply')]")));
				//latestViewAndApplyButton.Click();

				var sortByDate = wait.Until(driver => driver.FindElement(By.XPath("//input[@name='sort']/following-sibling::label[text()='Date']")));
				wait.Until(driver => sortByDate.Enabled);
				//sortByDate.Click();

				actions
					.MoveToElement(latestViewAndApplyButton);

				actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(sortByDate)
					.Perform();


				actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(latestViewAndApplyButton)
					.Perform();

				//actions
				//	.MoveToElement(latestViewAndApplyButton)
				//	.Pause(TimeSpan.FromSeconds(1))
				//	.Click(latestViewAndApplyButton)
				//	.Perform();


				//var finalContent = wait.Until(driver => driver.FindElement(By.XPath($"//div[@class='section__wrapper']//*[contains(text(), {testData})]")));
				var finalContent = wait.Until(driver => driver.FindElement(By.XPath("//div[@class='section__wrapper']")));
				wait.Until(driver => finalContent.Displayed);

				answer = finalContent.Text.Contains($"{testData}", StringComparison.OrdinalIgnoreCase);

				Console.WriteLine(answer);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}


			Assert.IsTrue(answer);
		}

		[TestMethod]
		[DataRow("blockchain")]
		[DataRow("cloud")]
		[DataRow("automation")]
		public void GlobalSearch_ProvideInput_GetProperResult(string keys)
		{
			bool answer = false;

			try
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
				{
					PollingInterval = TimeSpan.FromSeconds(0.25),
					Message = "Element not found."
				};

				var actions = new Actions(driver);

				var cookie = wait.Until(driver => driver.FindElement(By.Id("onetrust-accept-btn-handler")));
				//cookie.Click();

				actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(cookie)
					.Perform();

				//var cookie = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
				//if (cookie.Enabled || cookie.Displayed)
				//{
				//	cookie.Click();
				//}

				var magnifier = wait.Until(driver => driver.FindElement(By.XPath("//button[@class='header-search__button header__icon']")));
				//magnifier.Click();

				actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(magnifier)
					.Perform();

				var input = wait.Until(driver => driver.FindElement(By.XPath("//input[@name='q']")));
				//input.SendKeys(keys);

				actions
					.Pause(TimeSpan.FromSeconds(1))
					.SendKeys(keys)
					.Perform();

				var findButton = wait.Until(driver => driver.FindElement(By.XPath("//span[contains(text(), 'Find')]/parent::*")));
				//findButton.Click();

				actions
					.Pause(TimeSpan.FromSeconds(1))
					.Click(findButton)
					.Perform();

				IList<IWebElement> searchResultsContainer = wait.Until(driver => driver.FindElements(By.XPath("//div[@class='search-results__items']//a")));
				wait.Until(driver => searchResultsContainer.All(element => element.Displayed));

				answer = searchResultsContainer.All(item => item.Text.Contains(keys));

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}


			Assert.IsTrue(answer);
		}

		[TestCleanup]
		public void Cleanup()
		{
			driver.Quit();
		}
	}


}
