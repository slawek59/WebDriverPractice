using OpenQA.Selenium;
using WebDriverPractice.Data;
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

		}

		public void OpenPage() => Driver.Navigate().GoToUrl(DataConstants.BaseURL);

		public SearchResultPage SearchForKeyword(string keyword)
		{
			Driver.Click(_magnifierButton);
			Driver.SendKeys(_inputField, keyword);
			Driver.Click(_findButton);

			return new SearchResultPage(base.Driver);
		}

		public void ClickCookieAcceptButton() => Driver.Click(_cookieAcceptButton);
		public CarrerSearchPage ClickCareersButton()
		{
			Driver.Click(_careersButton);
			return new CarrerSearchPage(base.Driver);
		}

		public AboutPage ClickAboutButton()
		{
			Driver.Click(_aboutButton);

			return new AboutPage(base.Driver);
		}

		public InsightsPage ClickInsightsButton()
		{
			Driver.Click(_insightsButton);

			return new InsightsPage(base.Driver);
		}
	}
}
