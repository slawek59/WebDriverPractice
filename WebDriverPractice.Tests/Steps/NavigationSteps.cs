using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using WebDriverPractice.Business.Pages;

namespace WebDriverPractice.Tests.Steps
{
	[Binding]
	public class NavigationSteps
	{
		private readonly IWebDriver _driver;
		private readonly EpamMainPage _epamMainPage;

		public NavigationSteps(ScenarioContext scenarioContext)
		{
			_driver = (IWebDriver)scenarioContext["WebDriver"];
			_epamMainPage = new EpamMainPage(_driver);
		}

		[When(@"the user selects ""(.*)"" from the Services dropdown")]
		public void WhenTheUserSelectsFromTheServicesDropdown(string category)
		{
			_epamMainPage.NavigateToService(category);
		}

		[Then(@"the page title should be ""(.*)""")]
		public void ThenThePageTitleShouldBe(string expectedTitle)
		{
			var actualTitle = _epamMainPage.GetPageTitle();
			StringAssert.Contains(actualTitle, expectedTitle, "Page titles do not match.");
		}

		[Then(@"the section ""(.*)"" should be displayed")]
		public void ThenTheSectionShouldBeDisplayed(string section)
		{
			bool isDisplayed = _epamMainPage.IsSectionDisplayed(section);
			Assert.IsTrue(isDisplayed, $"{section} is not displayed.");
		}
	}
}
