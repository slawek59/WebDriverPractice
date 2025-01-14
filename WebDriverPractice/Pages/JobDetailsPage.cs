using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class JobDetailsPage
    {
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;
		private readonly Actions _actions;
		private readonly WebDriverHelper _driverHelper;
		private readonly By _finalContent = By.XPath("//div[@class='section__wrapper']");

		public JobDetailsPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public bool IsSearchResultDisplayed(string keys)
        {
			return _driverHelper.FindElementWithWait(_finalContent).Text.Contains($"{keys}", StringComparison.OrdinalIgnoreCase);
		}
	}
}
