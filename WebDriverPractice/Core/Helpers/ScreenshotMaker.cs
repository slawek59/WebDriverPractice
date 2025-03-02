using OpenQA.Selenium;

namespace WebDriverPractice.Core.Helpers
{
	public static class ScreenshotMaker
	{
		public static string TakeBrowserScreenshot(ITakesScreenshot driver)
		{
			string screenshotDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestResults");

			var now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
			var screenshotPath = Path.Combine(screenshotDirectory, $"Display_{now}.png");
			driver.GetScreenshot().SaveAsFile(screenshotPath);

			return screenshotPath;
		}
	}
}
