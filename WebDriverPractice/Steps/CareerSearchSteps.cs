using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using WebDriverPractice.Business.Pages;
using WebDriverPractice.Core.Browser;

namespace WebDriverPractice.Steps
{
	[Binding]
	public class CareerSearchSteps
	{
		private readonly IWebDriver _driver;
		private readonly EpamMainPage _epamMainPage;
		private CareerSearchPage _careerSearchPage;
		private bool _isSearchResultDisplayed;

		public CareerSearchSteps()
		{
			_driver = DriverManager.GetDriver();
			_epamMainPage = new EpamMainPage(_driver);
		}

		[Given(@"the user is on the Epam homepage")]
		public void GivenTheUserIsOnTheEpamHomepage()
		{
			_careerSearchPage = _epamMainPage.ClickCareersButton();
		}

		[When(@"the user searches for ""(.*)""")]
		public void WhenTheUserSelectsFromTheServicesDropdown(string keyword)
		{
			var carrerSearchResultsPage = _careerSearchPage.PerfromCarrerSearchOperations(keyword);

			var jobDetailsPage = carrerSearchResultsPage.NavigateToLatestResult();

			_isSearchResultDisplayed = jobDetailsPage.IsSearchResultDisplayed(keyword);
		}

		[Then(@"the Career Search should contain the Keyword.")]
		public void CareerSearchShouldContain()
		{
			Assert.IsTrue(_isSearchResultDisplayed, "Search result was not displayed.");
		}
	}
}
