﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

		public TestContext TestContext { get; set; }


		[TestInitialize]
		public void Setup()
		{
			Driver = BrowserFactory.CreateBrowser("chrome");
			EpamMainPage = new EpamMainPage(Driver);
			EpamMainPage.OpenPage();
			EpamMainPage.ClickCookieAcceptButton();

			Log.Information($"Test initialization for {TestContext.TestName}.");
		}

		[TestCleanup]
		public void Cleanup()
		{
			///TODO this stuff as non-specific should probably be also placed into a separate place

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
			Driver.Quit();
		}
	}
}
