using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class AboutPage : BasePage
	{
		public const string DownloadFilePath = "C:\\Users\\wassl\\Downloads\\EPAM_Corporate_Overview_Q4_EOY.pdf";

		private readonly By _section = By.XPath("//span[contains(text(), 'EPAM at')]");
		private readonly By _downloadButton = By.XPath("//span[contains(text(), 'DOWNLOAD')]/parent::span/parent::a");

		public AboutPage(IWebDriver driver) : base(driver)
		{

		}

		public bool ClickDownloadButtonAndWaitUntilDone()
		{
			Driver.ScrollToElement(_section);
			Driver.Click(_downloadButton);
			
			return _wait.Until(driver => File.Exists(DownloadFilePath));
		}
	}
}
