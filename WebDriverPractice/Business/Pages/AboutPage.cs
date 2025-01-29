using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using WebDriverPractice.Business;
using WebDriverPractice.Core.Helpers;

namespace WebDriverPractice.Business.Pages
{
	public class AboutPage : BasePage
	{
		public const string DownloadFilePath = "C:\\Users\\wassl\\Downloads\\EPAM_Corporate_Overview_Q4_EOY.pdf";

		private readonly By _section = By.XPath("//span[contains(text(), 'EPAM at')]");
		private readonly By _downloadButton = By.XPath("//span[contains(text(), 'DOWNLOAD')]/parent::span/parent::a");

		public AboutPage(IWebDriver driver) : base(driver)
		{
			Log.Information($"Open {GetType().Name} page.");
		}

		public bool ClickDownloadButtonAndWaitUntilDone()
		{
			Log.Information($"Scroll to {nameof(_section)}.");
			Driver.ScrollToElement(_section);

			Log.Information($"Click {nameof(_downloadButton)}.");
			Driver.Click(_downloadButton);

			return _wait.Until(driver => File.Exists(DownloadFilePath));
		}
	}
}
