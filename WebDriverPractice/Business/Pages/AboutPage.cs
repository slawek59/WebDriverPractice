using OpenQA.Selenium;
using Serilog;
using WebDriverPractice.Core.Config;
using WebDriverPractice.Core.Helpers;

namespace WebDriverPractice.Business.Pages
{
	public class AboutPage : BasePage
	{
		public readonly string DownloadFilePath = ConfigManager.GetSetting("BrowserSettings:DownloadFile");
		private readonly By _section = By.XPath("//span[contains(text(), 'EPAM at')]");
		private readonly By _downloadButton = By.XPath("//span[contains(text(), 'DOWNLOAD')]/parent::span/parent::a");

		public AboutPage(IWebDriver driver) : base(driver)
		{
			Log.Information($"Create instance of {GetType().Name} page.");
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