using OpenQA.Selenium;

namespace WebDriverPractice.Core.Helpers
{
	public static class ScreenshotMaker
	{
		public static string TakeBrowserScreenshot(ITakesScreenshot driver)
		{
			string projectRoot = Directory.GetCurrentDirectory();
			string screenshotDirectory = Path.Combine(projectRoot, "Screenshots");

			if (!Directory.Exists(screenshotDirectory))
			{
				Directory.CreateDirectory(screenshotDirectory);
			}

			var now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
			var screenshotPath = Path.Combine(screenshotDirectory, $"Display_{now}.png");
			driver.GetScreenshot().SaveAsFile(screenshotPath);

			return screenshotPath;
		}
	}
}
