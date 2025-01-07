using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebDriverPractice
{
	public class WebDriverHelper
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;
		private readonly Actions _actions;

		public WebDriverHelper(IWebDriver driver, WebDriverWait wait, Actions actions)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
		}

		public void Click(By locator)
		{
			var webElement = _wait.Until(driver => _driver.FindElement(locator));

			_actions
				.MoveToElement(webElement)
				.Click()
				.Perform();
		}
	}
}
