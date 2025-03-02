using OpenQA.Selenium;
using Serilog;

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
				Log.Information($"Created directory: {screenshotDirectory}");
			}

			var now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
			var screenshotPath = Path.Combine(screenshotDirectory, $"Display_{now}.png");

			try
			{
				driver.GetScreenshot().SaveAsFile(screenshotPath);
				Console.WriteLine($"Screenshot saved at: {screenshotPath}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to save screenshot: {ex.Message}");
			}

			return screenshotPath;
		}
	}
}
