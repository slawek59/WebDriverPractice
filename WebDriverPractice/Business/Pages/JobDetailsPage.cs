using OpenQA.Selenium;
using Serilog;
using WebDriverPractice.Core.Helpers;

namespace WebDriverPractice.Business.Pages
{
	public class JobDetailsPage : BasePage
	{
		private readonly By _finalContent = By.XPath("//div[@class='section__wrapper']");

		public JobDetailsPage(IWebDriver driver) : base(driver)
		{
			Log.Information($"Create instance of {GetType().Name} page.");
		}

		public bool IsSearchResultDisplayed(string keys)
		{
			return Driver.FindElementWithWait(_finalContent).Text.Contains($"{keys}", StringComparison.OrdinalIgnoreCase);
		}
	}
}
