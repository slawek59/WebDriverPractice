using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using WebDriverPractice.Business.Pages;
using WebDriverPractice.Core.Browser;

namespace WebDriverPractice.Steps
{
	[Binding]
	public class NavigationSteps
	{
		private readonly IWebDriver _driver;
		private readonly EpamMainPage _epamMainPage;

		public NavigationSteps()
		{
			_driver = DriverManager.GetDriver();
			_epamMainPage = new EpamMainPage(_driver);
		}

		[Given(@"the user is on the main Epam page")]
		public void GivenTheUserIsOnTheEpamHomepage()
		{
			//
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
