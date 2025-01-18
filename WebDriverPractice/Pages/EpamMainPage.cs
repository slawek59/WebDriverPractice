using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;
using WebDriverPractice.Data;
using Serilog;

namespace WebDriverPractice.Pages
{
	public class EpamMainPage
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;
		private readonly Actions _actions;
		private readonly WebDriverHelper _driverHelper;

		private readonly By _cookieAcceptButton = By.Id("onetrust-accept-btn-handler");

		private readonly By _careersButton = By.XPath("//span/a[contains(@class, 'top-navigation__item-link js-op') and @href='/careers']");
		private readonly By _magnifierButton = By.XPath("//button[@class='header-search__button header__icon']");
		private readonly By _inputField = By.XPath("//input[@name='q']");
		private readonly By _findButton = By.XPath("//span[contains(text(), 'Find')]/parent::*");
		private readonly By _aboutButton = By.XPath("//span/a[contains(@class, 'top-navigation__item-link js-op') and @href='/about']");
		private readonly By _insightsButton = By.LinkText("Insights");

		public EpamMainPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			Log.Information($"Open {this.GetType().Name} page.");
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public void OpenPage() => _driver.Navigate().GoToUrl(DataConstants.BaseURL);

		public SearchResultPage SearchForKeyword(string keyword)
		{
			Log.Information($"Click {nameof(_magnifierButton)}.");
			_driverHelper.Click(_magnifierButton);

			Log.Information($"Send '{keyword}' to {_inputField}.");
			_driverHelper.SendKeys(_inputField, keyword);

			Log.Information($"Click {nameof(_findButton)}.");
			_driverHelper.Click(_findButton);

			return new SearchResultPage(_driver, _wait, _actions, _driverHelper);
		}

		public void ClickCookieAcceptButton() => _driverHelper.Click(_cookieAcceptButton);
		public CarrerSearchPage ClickCareersButton()
		{
			Log.Information($"Click {nameof(_careersButton)}.");
			_driverHelper.Click(_careersButton);

			return new CarrerSearchPage(_driver, _wait, _actions, _driverHelper);
		}

		public AboutPage ClickAboutButton()
		{
			Log.Information($"Click {nameof(_aboutButton)}.");
			_driverHelper.Click(_aboutButton);

			return new AboutPage(_driver, _wait, _actions, _driverHelper);
		}
		public InsightsPage ClickInsightsButton()
		{
			Log.Information($"Click {nameof(_insightsButton)}.");
			_driverHelper.Click(_insightsButton);

			return new InsightsPage(_driver, _wait, _actions, _driverHelper);
		}
	}
}
