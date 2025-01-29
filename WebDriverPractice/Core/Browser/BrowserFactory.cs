using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace WebDriverPractice.Core.Browser
{
	public static class BrowserFactory
	{
		public static IWebDriver CreateBrowser(string browser)
		{
			IWebDriver driver;
			switch (browser)
			{
				case "chrome":
					driver = new ChromeDriver();
					break;
				case "edge":
					driver = new EdgeDriver();
					break;
				default:
					driver = new ChromeDriver();
					break;
			}

			return driver;
		}
	}
}