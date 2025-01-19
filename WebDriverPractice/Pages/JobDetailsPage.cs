using OpenQA.Selenium;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class JobDetailsPage : BasePage
    {
		private readonly By _finalContent = By.XPath("//div[@class='section__wrapper']");

        public JobDetailsPage(IWebDriver driver) : base(driver)
        {
            
        }

        public bool IsSearchResultDisplayed(string keys)
        {
			return Driver.FindElementWithWait(_finalContent).Text.Contains($"{keys}", StringComparison.OrdinalIgnoreCase);
		}
	}
}
