using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Serilog;

namespace WebDriverPractice.Core.Browser
{
	public static class DriverManager
	{
		private static IWebDriver? _driver;

		public static IWebDriver GetDriver(TestContext testContext)
		{
			if (_driver == null)
			{
				_driver = BrowserFactory.CreateBrowser(testContext);
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
