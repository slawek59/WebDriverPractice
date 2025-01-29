using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebDriverPractice.Core.Helpers
{
	public static class IWebDriverExtensions
	{
		public static void Click(this IWebDriver driver, By locator)
		{
			Actions _actions = new Actions(driver);

			var webElement = driver.WaitForElement(locator);

			_actions
				.Pause(TimeSpan.FromSeconds(1))
				.Click(webElement)
				.Pause(TimeSpan.FromSeconds(1))
				.Perform();
		}

		public static void SendKeys(this IWebDriver driver, By locator, string keys)
		{
			Actions _actions = new Actions(driver);

			var webElement = driver.WaitForElement(locator);

			_actions
				.MoveToElement(webElement)
				.Pause(TimeSpan.FromSeconds(1))
				.Click(webElement)
				.SendKeys(keys)
				.Pause(TimeSpan.FromSeconds(1))
				.Perform();
		}

		public static IWebElement FindElementWithWait(this IWebDriver driver, By locator)
		{
			var webElement = driver.WaitForElement(locator);

			return webElement;
		}

		public static IList<IWebElement> FindElementsWithWait(this IWebDriver driver, By locator)
		{
			var webElements = driver.WaitForElements(locator);

			return webElements;
		}

		public static void ScrollToElement(this IWebDriver driver, By locator)
		{
			Actions _actions = new Actions(driver);

			_actions
			.ScrollToElement(driver.FindElementWithWait(locator))
			.Perform();
		}

		public static void ClickWithJS(this IWebDriver driver, IWebElement element)
		{
			((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
		}

		public static IWebElement WaitForElement(this IWebDriver driver, By locator)
		{
			WebDriverWait _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
			{
				PollingInterval = TimeSpan.FromSeconds(0.25),
				Message = "Element not found."
			};

			return _wait.Until(driver => driver.FindElement(locator));
		}
		public static IList<IWebElement> WaitForElements(this IWebDriver driver, By locator)
		{
			WebDriverWait _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
			{
				PollingInterval = TimeSpan.FromSeconds(0.25),
				Message = "Element not found."
			};

			return _wait.Until(driver => driver.FindElements(locator));
		}
	}
}