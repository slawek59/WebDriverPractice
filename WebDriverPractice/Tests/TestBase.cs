using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Serilog;
using WebDriverPractice.Business.Pages;
using WebDriverPractice.Core.Browser;
using WebDriverPractice.Core.Helpers;

namespace WebDriverPractice.Tests
{
	public abstract class TestBase
	{
		public IWebDriver Driver = null!;
		public EpamMainPage EpamMainPage = null!;
		public TestContext TestContext { get; set; } = null!;


		[TestInitialize]
		public void Setup()
		{
			Driver = DriverManager.GetDriver(TestContext);
			EpamMainPage = new EpamMainPage(Driver);
			EpamMainPage.OpenPage();
			EpamMainPage.ClickCookieAcceptButton();

			Log.Information($"Test initialization for {TestContext.TestName}.");
		}

		[TestCleanup]
		public void Cleanup()
		{
			if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
			{
				Log.Error($"\n!---{TestContext.TestName} FAILED.---!\n");
				var screenshotDriver = (ITakesScreenshot)Driver;
				ScreenshotMaker.TakeBrowserScreenshot(screenshotDriver);
			}
			else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
			{
				Log.Information($"{TestContext.TestName} PASSED.");
			}

			Log.Information($"Closing WebDriver.\n");
			DriverManager.QuitDriver();
		}
	}
}