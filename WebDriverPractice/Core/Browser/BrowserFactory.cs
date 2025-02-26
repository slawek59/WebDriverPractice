using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Serilog;
using WebDriverPractice.Core.Config;

namespace WebDriverPractice.Core.Browser
{
	public static class BrowserFactory
	{
		public static IWebDriver CreateBrowser()
		{
			string browser = ConfigManager.GetSetting("BrowserSettings:Browser")?.ToLower() ?? "chrome";
			var isHeadlessModeOn = ConfigManager.GetBoolSetting("BrowserSettings:Headless");

			switch (browser)
			{
				case "chrome":
					return CreateChromeDriver(isHeadlessModeOn);
				case "edge":
					return CreateEdgeDriver(isHeadlessModeOn);
				default:
					return CreateChromeDriver(isHeadlessModeOn);
			}
		}

		private static IWebDriver CreateChromeDriver(bool isHeadlessModeOn)
		{
			var options = new ChromeOptions();

			if (isHeadlessModeOn)
			{
				Log.Information("Open in headless mode.");
				options.AddArgument("--no-sandbox");
				options.AddArgument("--disable-gpu");
				options.AddArgument("disable-infobars");
				options.AddArgument("--headless");
				options.AddArgument("--disable-dev-shm-usage");
				options.AddArgument("--window-size=1920,1080");
			}

			options.AddUserProfilePreference("download.default_directory", ConfigManager.GetSetting("BrowserSettings:DownloadDirectory"));
			options.AddUserProfilePreference("download.prompt_for_download", false);
			options.AddUserProfilePreference("disable-popup-blocking", "true");

			var driver = new ChromeDriver(options);

			Log.Information($"Initialize {driver.GetType()}.");

			if (!isHeadlessModeOn)
			{
				driver.Manage().Window.Maximize();
			}

			return driver;
		}

		private static IWebDriver CreateEdgeDriver(bool isHeadlessModeOn)
		{
			var options = new EdgeOptions();

			if (isHeadlessModeOn)
			{
				Log.Information("Open in headless mode.");
				options.AddArgument("--no-sandbox");
				options.AddArgument("--disable-gpu");
				options.AddArgument("--headless=new");
				options.AddArgument("--window-size=1920,1080");
			}

			options.AddUserProfilePreference("download.default_directory", ConfigManager.GetSetting("BrowserSettings:DownloadDirectory"));
			options.AddUserProfilePreference("download.prompt_for_download", false);
			options.AddUserProfilePreference("disable-popup-blocking", "true");

			var driver = new EdgeDriver(options);

			Log.Information($"Initialize {driver.GetType()}.");

			if (!isHeadlessModeOn)
			{
				driver.Manage().Window.Maximize();
			}

			return driver;
		}
	}
}