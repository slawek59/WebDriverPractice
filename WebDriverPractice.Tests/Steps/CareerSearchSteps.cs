using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using WebDriverPractice.Business.Pages;

namespace WebDriverPractice.Tests.Steps
{
	[Binding]
	public class CareerSearchSteps
	{
		private readonly IWebDriver _driver;
		private readonly EpamMainPage _epamMainPage;
		private CareerSearchPage? _careerSearchPage;
		private bool _isSearchResultDisplayed;

		private CareerSearchPage SearchPage
		{
			get
			{
				if (_careerSearchPage == null)
				{
					_careerSearchPage = _epamMainPage.ClickCareersButton();
				}
				return _careerSearchPage;
			}
		}

		public CareerSearchSteps(ScenarioContext scenarioContext)
		{
			_driver = (IWebDriver)scenarioContext["WebDriver"];
			_epamMainPage = new EpamMainPage(_driver);
		}

		[Given(@"the user is on the Epam homepage")]
		public void GivenTheUserIsOnTheEpamHomepage()
		{
			_ = SearchPage;
		}

		[When(@"the user searches for ""(.*)"" career keyword")]
		public void WhenTheUserSearchesFor(string careerKeyword)
		{
			var carrerSearchResultsPage = SearchPage.PerfromCareerSearchOperations(careerKeyword);

			var jobDetailsPage = carrerSearchResultsPage.NavigateToLatestResult();

			_isSearchResultDisplayed = jobDetailsPage.IsSearchResultDisplayed(careerKeyword);
		}

		[Then(@"the Career Search should contain the Keyword.")]
		public void CareerSearchShouldContain()
		{
			Assert.IsTrue(_isSearchResultDisplayed, "Search result was not displayed.");
		}
	}
}
