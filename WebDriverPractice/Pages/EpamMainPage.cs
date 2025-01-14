using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class EpamMainPage
	{
		private const string BaseURL = "https://www.epam.com";
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
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public void MaximizeWindow() => _driver.Manage().Window.Maximize();
		public void OpenPage() => _driver.Navigate().GoToUrl(BaseURL);
		public SearchResultPage SearchForKeyword(string keyword)
		{
			_driverHelper.Click(_magnifierButton);
			_driverHelper.SendKeys(_inputField, keyword);
			_driverHelper.Click(_findButton);

			return new SearchResultPage(_driver, _wait, _actions, _driverHelper);
		}

		public void ClickCookieAcceptButton() => _driverHelper.Click(_cookieAcceptButton);
		public void ClickCareersButton() => _driverHelper.Click(_careersButton);
		public void ClickAboutButton () => _driverHelper.Click(_aboutButton);
		public void ClickInsightsButton() => _driverHelper.Click(_insightsButton);
	}
}
