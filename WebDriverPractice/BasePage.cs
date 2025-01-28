using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Driver;

namespace WebDriverPractice
{
	public abstract class BasePage
	{
		protected IWebDriver Driver { get; }
		protected WebDriverWait _wait;

		protected BasePage(IWebDriver driver)
		{
			Driver = driver;

			_wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
			{
				PollingInterval = TimeSpan.FromSeconds(0.25),
				Message = "Element not found."
			};
		}
	}
}
