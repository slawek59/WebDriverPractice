using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using WebDriverPractice.Business.Pages;

namespace WebDriverPractice.Tests.Steps
{
	[Binding]
	public class InsightsSteps
	{
		private readonly IWebDriver _driver;
		private readonly EpamMainPage _epamMainPage;
		private InsightsPage _insightsPage = null!;
		private InsightsReadMorePage _insightsReadMorePage = null!;
		private string? _slideText;

		public InsightsSteps(ScenarioContext scenarioContext)
		{
			_driver = (IWebDriver)scenarioContext["WebDriver"];
			_epamMainPage = new EpamMainPage(_driver);
		}

		[When(@"the user clicks on the Insights button")]
		public void WhenTheUserClicksOnInsightsButton()
		{
			_insightsPage = _epamMainPage.ClickInsightsButton();
		}

		[When(@"the user clicks slider button two times")]
		public void WhenTheUserClicksOnDownloadButton()
		{
			_insightsPage.ClickSliderButton(2);
		}

		[When(@"the user clicks 'Read More' button")]
		public void WhenTheUserClicksReadMoreButton()
		{
			_slideText = _insightsPage.GetSlideText();

			_insightsReadMorePage = _insightsPage.ClickReadMoreButton();
		}

		[Then(@"the user sees a proper header")]
		public void ThenTheUserSeesTheProperHeader()
		{
			var insightsReadMorePageTitle = _insightsReadMorePage.GetReadMorePageTitle();

			Assert.AreEqual(_slideText, insightsReadMorePageTitle, "Texts are not equal.");
		}
	}
}