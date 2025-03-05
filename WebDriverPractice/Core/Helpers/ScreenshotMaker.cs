using OpenQA.Selenium;
using Serilog;

namespace WebDriverPractice.Core.Helpers
{
	public static class ScreenshotMaker
	{
		public static void TakeBrowserScreenshot(ITakesScreenshot driver)
		{
			if (driver is ITakesScreenshot)
			{
				var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");

				string screenshotDirectory = Path.Combine(Environment.CurrentDirectory, "Screenshots");

				Directory.CreateDirectory(screenshotDirectory);
				Log.Information($"Created directory: {screenshotDirectory}");

				var screenshotPath = Path.Combine(screenshotDirectory, $"Display_{timestamp}.png");

				var screenshot = driver.GetScreenshot();

				//using (var fileStream = new FileStream(screenshotPath, FileMode.Create))
				//{
				screenshot.SaveAsFile(screenshotPath);
				//fileStream.Flush();
				Log.Information($"Screenshot saved at: {screenshotPath}");
				//}
			}
			else
			{
				Log.Information("Driver does not allow to take screenshots.");
			}

		}
	}
}
