﻿using OpenQA.Selenium;
using Serilog;

namespace WebDriverPractice.Core.Helpers
{
	public static class ScreenshotMaker
	{
		public static string TakeBrowserScreenshot(ITakesScreenshot driver)
		{
			string screenshotDirectory = Path.Combine(Environment.CurrentDirectory, "Screenshots");

			Directory.CreateDirectory(screenshotDirectory);
			Log.Information($"Created directory: {screenshotDirectory}");

			var now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
			var screenshotPath = Path.Combine(screenshotDirectory, $"Display_{now}.png");

			var screenshot = driver.GetScreenshot();

			using (var fileStream = new FileStream(screenshotPath, FileMode.Create))
			{
				screenshot.SaveAsFile(screenshotPath);
				fileStream.Flush();
				Log.Information($"Screenshot saved at: {screenshotPath}");
			}

			return screenshotPath;
		}
	}
}
