using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverPractice.Data;
using Serilog;

namespace WebDriverPractice.Driver
{
	public static class DriverInstance
	{
		public static IWebDriver GetInstance(bool isHeadlessModeOn = false)
		{
			var chromeOptions = new ChromeOptions();

			if (isHeadlessModeOn)
			{
				Log.Information("Open in headless mode.");
				chromeOptions.AddArgument("--headless");
				chromeOptions.AddArgument("--window-size=1920,1080");
			}

			chromeOptions.AddUserProfilePreference("download.default_directory", DataConstants.DownloadDirectory);
			chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
			chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

			Log.Information("Initialize driver.");
			var driver = new ChromeDriver(DataConstants.ChromeDriverDirectory, chromeOptions);

			if (!isHeadlessModeOn)
			{
				driver.Manage().Window.Maximize();
			}

			return driver;
		}
	}
}
