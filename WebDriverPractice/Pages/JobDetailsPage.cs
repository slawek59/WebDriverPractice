using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class JobDetailsPage : BasePage
    {
		private readonly By _finalContent = By.XPath("//div[@class='section__wrapper']");

        public JobDetailsPage(IWebDriver driver) : base(driver)
        {
			Log.Information($"Open {this.GetType().Name} page.");
        }

        public bool IsSearchResultDisplayed(string keys)
        {
			return Driver.FindElementWithWait(_finalContent).Text.Contains($"{keys}", StringComparison.OrdinalIgnoreCase);
		}
	}
}
