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
		private InsightsPage? _insightsPage;
		private InsightsReadMorePage? _insightsReadMorePage;
		private string? _slideText;

		private InsightsPage Insights
		{
			get
			{
				if (_insightsPage == null)
				{
					_insightsPage = _epamMainPage.ClickInsightsButton();
				}
				return _insightsPage;
			}
		}

		private InsightsReadMorePage InsightsReadMore
		{
			get
			{
				if (_insightsReadMorePage == null)
				{
					_insightsReadMorePage = Insights.ClickReadMoreButton();
				}
				return _insightsReadMorePage;
			}
		}


		public InsightsSteps(ScenarioContext scenarioContext)
		{
			_driver = (IWebDriver)scenarioContext["WebDriver"];
			_epamMainPage = new EpamMainPage(_driver);
		}

		[When(@"the user clicks on the Insights button")]
		public void WhenTheUserClicksOnInsightsButton()
		{
			_ = Insights;
		}

		[When(@"the user clicks slider button two times")]
		public void WhenTheUserClicksSliderButtonTwoTimes()
		{
			Insights.ClickSliderButton(2);
		}

		[When(@"the user clicks 'Read More' button")]
		public void WhenTheUserClicksReadMoreButton()
		{
			_slideText = Insights.GetSlideText();

			_insightsReadMorePage = Insights.ClickReadMoreButton();
		}

		[Then(@"the user sees a proper header")]
		public void ThenTheUserSeesTheProperHeader()
		{
			var insightsReadMorePageTitle = InsightsReadMore.GetReadMorePageTitle();

			Assert.AreEqual(_slideText, insightsReadMorePageTitle, "Texts are not equal.");
		}
	}
}