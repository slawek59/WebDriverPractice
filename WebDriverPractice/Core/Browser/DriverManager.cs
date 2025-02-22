using OpenQA.Selenium;
using Serilog;

namespace WebDriverPractice.Core.Browser
{
	public static class DriverManager
	{
		private static IWebDriver? _driver;

		public static IWebDriver GetDriver()
		{
			if (_driver == null)
			{
				_driver = BrowserFactory.CreateBrowser();
			}

			return _driver;
		}

		public static void QuitDriver()
		{
			Log.Information("Quit Driver");
			_driver?.Quit();
			_driver = null;
		}
	}
}
