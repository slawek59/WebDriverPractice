using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using WebDriverPractice.Business.Pages;

namespace WebDriverPractice.Tests.Steps
{
	[Binding]
	public class GlobalSearchSteps
	{
		private readonly IWebDriver _driver;
		private readonly EpamMainPage _epamMainPage;
		private  SearchResultPage _searchResultPage = null!;

		public GlobalSearchSteps(ScenarioContext scenarioContext)
		{
			_driver = (IWebDriver)scenarioContext["WebDriver"];
			_epamMainPage = new EpamMainPage(_driver);
		}

		[When(@"the user searches for ""(.*)"" keyword")]
		public void WhenTheUserSearchesFor(string keyword)
		{
			_searchResultPage = _epamMainPage.SearchForKeyword(keyword);
		}

		[Then(@"all the search result links contains the ""(.*)"" keyword")]
		public void CareerSearchShouldContain(string keyword)
		{
			Assert.IsTrue(_searchResultPage.DoAllLinksContainKeyword(keyword), $"All links do not contain the searched keyword, which is {keyword}");
		}
	}
}
