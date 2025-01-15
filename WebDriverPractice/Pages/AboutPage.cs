using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class AboutPage
	{
		public readonly string DownloadFilePath = "C:\\Users\\wassl\\Downloads\\EPAM_Corporate_Overview_Q4_EOY.pdf";

		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;
		private readonly Actions _actions;
		private readonly WebDriverHelper _driverHelper;

		private readonly By _section = By.XPath("//span[contains(text(), 'EPAM at')]");
		private readonly By _downloadButton = By.XPath("//span[contains(text(), 'DOWNLOAD')]/parent::span/parent::a");

		public AboutPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public bool ClickDownloadButtonAndWaitUntilDone()
		{
			_driverHelper.ScrollToElement(_section);
			_driverHelper.Click(_downloadButton);
			
			return _wait.Until(driver => File.Exists(DownloadFilePath));
		}
	}
}
