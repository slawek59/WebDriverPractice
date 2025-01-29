using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using WebDriverPractice.Business;
using WebDriverPractice.Core.Helpers;

namespace WebDriverPractice.Business.Pages
{
	public class JobDetailsPage : BasePage
	{
		private readonly By _finalContent = By.XPath("//div[@class='section__wrapper']");

		public JobDetailsPage(IWebDriver driver) : base(driver)
		{
			Log.Information($"Open {GetType().Name} page.");
		}

		public bool IsSearchResultDisplayed(string keys)
		{
			return Driver.FindElementWithWait(_finalContent).Text.Contains($"{keys}", StringComparison.OrdinalIgnoreCase);
		}
	}
}
