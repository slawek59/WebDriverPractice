using OpenQA.Selenium;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class InsightsReadMorePage : BasePage
	{
		private readonly By _readMorePageTitle = By.XPath("//span[@class='font-size-80-33']/span[@class='museo-sans-light']");

		public InsightsReadMorePage(IWebDriver driver) : base(driver)
		{

		}

		public string GetReadMorePageTitle() => Driver.FindElementWithWait(_readMorePageTitle).Text.Trim();
	}
}