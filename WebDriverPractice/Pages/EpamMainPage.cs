using OpenQA.Selenium;
using WebDriverPractice.Data;
using Serilog;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class EpamMainPage : BasePage
	{
		private readonly By _cookieAcceptButton = By.Id("onetrust-accept-btn-handler");

		private readonly By _careersButton = By.XPath("//span/a[contains(@class, 'top-navigation__item-link js-op') and @href='/careers']");
		private readonly By _magnifierButton = By.XPath("//button[@class='header-search__button header__icon']");
		private readonly By _inputField = By.XPath("//input[@name='q']");
		private readonly By _findButton = By.XPath("//span[contains(text(), 'Find')]/parent::*");
		private readonly By _aboutButton = By.XPath("//span/a[contains(@class, 'top-navigation__item-link js-op') and @href='/about']");
		private readonly By _insightsButton = By.LinkText("Insights");

		public EpamMainPage(IWebDriver driver) : base(driver)
		{
			Log.Information($"Open {this.GetType().Name} page.");
		}

		public void OpenPage() => Driver.Navigate().GoToUrl(DataConstants.BaseURL);

		public SearchResultPage SearchForKeyword(string keyword)
		{
			Log.Information($"Click {nameof(_magnifierButton)}.");
			Driver.Click(_magnifierButton);

			Log.Information($"Send '{keyword}' to {_inputField}.");
			Driver.SendKeys(_inputField, keyword);

			Log.Information($"Click {nameof(_findButton)}.");
			Driver.Click(_findButton);

			return new SearchResultPage(base.Driver);
		}

		public void ClickCookieAcceptButton() => Driver.Click(_cookieAcceptButton);
		public CarrerSearchPage ClickCareersButton()
		{
			Log.Information($"Click {nameof(_careersButton)}.");
			Driver.Click(_careersButton);
			return new CarrerSearchPage(base.Driver);
		}

		public AboutPage ClickAboutButton()
		{
			Log.Information($"Click {nameof(_aboutButton)}.");
			Driver.Click(_aboutButton);

			return new AboutPage(base.Driver);
		}

		public InsightsPage ClickInsightsButton()
		{
			Log.Information($"Click {nameof(_insightsButton)}.");
			Driver.Click(_insightsButton);

			return new InsightsPage(base.Driver);
		}
	}
}
