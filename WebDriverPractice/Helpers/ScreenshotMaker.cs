using OpenQA.Selenium;

namespace WebDriverPractice.Helpers
{
	public static class ScreenshotMaker
	{
		public static string TakeBrowserScreenshot(ITakesScreenshot driver)
		{
			var now = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff");
			var screenshotPath = Path.Combine(Environment.CurrentDirectory, $"Display_{now}.png");
			driver.GetScreenshot().SaveAsFile(screenshotPath);

			return screenshotPath;
		}
	}
}
