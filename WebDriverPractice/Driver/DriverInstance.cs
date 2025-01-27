using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverPractice.Data;

namespace WebDriverPractice.Driver
{
	public static class DriverInstance
	{
		public static IWebDriver GetInstance()
		{
			var isHeadlessModeOn = Environment.GetEnvironmentVariable("setting") == "headless";

			var chromeOptions = new ChromeOptions();

			if (isHeadlessModeOn)
			{
				chromeOptions.AddArgument("--headless");
				chromeOptions.AddArgument("--window-size=1920,1080");
			}

			chromeOptions.AddUserProfilePreference("download.default_directory", DataConstants.DownloadDirectory);
			chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
			chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");


			var driver = new ChromeDriver(chromeOptions);

			if (!isHeadlessModeOn)
			{
				driver.Manage().Window.Maximize();
			}

			return driver;
		}
	}
}
