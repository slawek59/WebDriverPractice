using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class InsightsReadMorePage
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;
		private readonly Actions _actions;
		private readonly WebDriverHelper _driverHelper;

		private readonly By _readMorePageTitle = By.XPath("//span[@class='font-size-80-33']/span[@class='museo-sans-light']");

		public InsightsReadMorePage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public string GetReadMorePageTitle() => _driverHelper.FindElementWithWait(_readMorePageTitle).Text.Trim();
	}
}
