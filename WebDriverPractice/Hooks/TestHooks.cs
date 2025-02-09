using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using Serilog;
using WebDriverPractice.Business.Pages;
using WebDriverPractice.Core.Browser;
using WebDriverPractice.Core.Helpers;
using WebDriverPractice.Core.Logging;

namespace WebDriverPractice.Hooks
{
	[Binding]
	public sealed class TestHooks
	{

		public IWebDriver Driver = null!;
		public EpamMainPage EpamMainPage = null!;
		private readonly ScenarioContext _scenarioContext;

		public TestHooks(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			LogManager.Initialize();
			Log.Information("Global test setup started.");
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			Driver = DriverManager.GetDriver();
			//EpamMainPage = new EpamMainPage(Driver);
			//EpamMainPage.OpenPage();
			//EpamMainPage.ClickCookieAcceptButton();

			Log.Information($"Test initialization for {_scenarioContext.ScenarioInfo.Title}.");
		}

		[AfterScenario]
		public void AfterScenario()
		{
			if (_scenarioContext.TestError != null)
			{
				Log.Error($"\n!---{_scenarioContext.ScenarioInfo.Title} FAILED.---!\n");
				var screenshotDriver = (ITakesScreenshot)Driver;
				ScreenshotMaker.TakeBrowserScreenshot(screenshotDriver);
			}
			else
			{
				Log.Information($"{_scenarioContext.ScenarioInfo.Title} PASSED.");
			}

			Log.Information($"Closing WebDriver.\n");
			DriverManager.QuitDriver();
		}

		[AfterTestRun]
		public static void AfterTestRun()
		{
			Log.Information("Assembly cleanup.");
			LogManager.Close();
		}
	}
}