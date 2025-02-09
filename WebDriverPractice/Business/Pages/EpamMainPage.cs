using OpenQA.Selenium;
using Serilog;
using WebDriverPractice.Business.Data;
using WebDriverPractice.Core.Config;
using WebDriverPractice.Core.Helpers;

namespace WebDriverPractice.Business.Pages
{
	public class EpamMainPage : BasePage
	{
		private readonly By _cookieAcceptButton = By.Id("onetrust-accept-btn-handler");
		private readonly string _baseUrl = ConfigManager.GetSetting("BrowserSettings:URL");

		private readonly By _careersButton = By.XPath("//span/a[contains(@class, 'top-navigation__item-link js-op') and @href='/careers']");
		private readonly By _magnifierButton = By.XPath("//button[@class='header-search__button header__icon']");
		private readonly By _inputField = By.XPath("//input[@name='q']");
		private readonly By _findButton = By.XPath("//span[contains(text(), 'Find')]/parent::*");
		private readonly By _aboutButton = By.XPath("//span/a[contains(@class, 'top-navigation__item-link js-op') and @href='/about']");
		private readonly By _insightsButton = By.LinkText("Insights");

		private readonly By _servicesButton = By.XPath("//span/a[contains(@class, 'top-navigation__item-link js-op') and @href='/services']");
		private readonly By _responsibleAIButton = By.LinkText("Responsible AI");
		private readonly By _generativeAIButton = By.LinkText("Generative AI");

		public EpamMainPage(IWebDriver driver) : base(driver)
		{
			Log.Information($"Create instance of {GetType().Name} page.");
		}

		public void OpenPage() => Driver.Navigate().GoToUrl(_baseUrl);

		public SearchResultPage SearchForKeyword(string keyword)
		{
			Log.Information($"Click {nameof(_magnifierButton)}.");
			Driver.ClickWithWait(_magnifierButton);

			Log.Information($"Send '{keyword}' to {nameof(_inputField)}.");
			Driver.SendKeys(_inputField, keyword);

			Log.Information($"Click {nameof(_findButton)}.");
			Driver.ClickWithWait(_findButton);

			return new SearchResultPage(Driver);
		}

		public void ClickCookieAcceptButton() => Driver.ClickWithWait(_cookieAcceptButton);
		public CarrerSearchPage ClickCareersButton()
		{
			Log.Information($"Click {nameof(_careersButton)}.");
			Driver.Click(_careersButton);
			return new CarrerSearchPage(Driver);
		}

		public AboutPage ClickAboutButton()
		{
			Log.Information($"Click {nameof(_aboutButton)}.");
			Driver.Click(_aboutButton);

			return new AboutPage(Driver);
		}

		public InsightsPage ClickInsightsButton()
		{
			Log.Information($"Click {nameof(_insightsButton)}.");
			Driver.Click(_insightsButton);

			return new InsightsPage(Driver);
		}

		public void NavigateToService(string category)
		{
			Driver.HoverOver(_servicesButton);

			if (category == "Responsible AI")
			{
				Driver.Click(_responsibleAIButton);
			}
			else if (category == "Generative AI")
			{
				Driver.Click(_generativeAIButton);
			}
		}

		public string? GetPageTitle()
		{
			return Driver.Title;
		}

		public bool IsSectionDisplayed(string section)
		{
			return Driver.FindElementsWithWait(By.XPath($"//h2[contains(text(), '{section}')]")).Count > 0;
		}
	}
}
