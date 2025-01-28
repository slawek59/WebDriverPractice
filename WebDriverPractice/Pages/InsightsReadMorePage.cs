using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class InsightsReadMorePage : BasePage
	{
		private readonly By _readMorePageTitle = By.XPath("//span[@class='font-size-80-33']/span[@class='museo-sans-light']");

		public InsightsReadMorePage(IWebDriver driver) : base(driver)
		{
			Log.Information($"Open {this.GetType().Name} page.");
		}

		public string GetReadMorePageTitle() => Driver.FindElementWithWait(_readMorePageTitle).Text.Trim();
	}
}