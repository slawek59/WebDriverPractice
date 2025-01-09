using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebDriverPractice.Helpers
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
			//var webElement = _wait.Until(driver =>
			//{
			//	var element = _driver.FindElement(locator);
			//	return element.Displayed && element.Enabled ? element : null;
			//});

			var webElement = _wait.Until(driver => _driver.FindElement(locator));

			_actions
				//.MoveToElement(webElement)
				.Pause(TimeSpan.FromSeconds(1))
				.Click(webElement)
				.Perform();
		}

		public void SendKeys(By locator, string keys)
		{
			//var webElement = _wait.Until(driver =>
			//{
			//	var element = _driver.FindElement(locator);
			//	return element.Displayed && element.Enabled ? element : null;
			//});
			var webElement = _wait.Until(driver => _driver.FindElement(locator));

			_actions
				.MoveToElement(webElement)
				.Pause(TimeSpan.FromSeconds(1))
				.Click(webElement)
				.SendKeys(keys)
				.Pause(TimeSpan.FromSeconds(1))
				.Perform();
		}

		public IWebElement FindElementWithWait(By locator)
		{
			//var webElement = _wait.Until(driver =>
			//{
			//	var element = _driver.FindElement(locator);
			//	return element.Displayed && element.Enabled ? element : null;
			//});
			var webElement = _wait.Until(driver => _driver.FindElement(locator));

			return webElement;
		}

		public IList<IWebElement> FindElementsWithWait(By locator)
		{
			//var webElement = _wait.Until(driver =>
			//{
			//	var element = _driver.FindElement(locator);
			//	return element.Displayed && element.Enabled ? element : null;
			//});
			var webElements = _wait.Until(driver => _driver.FindElements(locator));

			return webElements;
		}

		public void ScrollToElement(By locator) => _actions
			.ScrollToElement(FindElementWithWait(locator))
			.Perform();

		public void ClickWithJS(IWebElement element)
		{
			((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
		}

	}
}
