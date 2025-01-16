﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverPractice.Data;

namespace WebDriverPractice.Driver
{
	public static class DriverInstance
	{
		public static IWebDriver GetInstance(bool isHeadlessModeOn = false)
		{
			

			var chromeOptions = new ChromeOptions();
			if (isHeadlessModeOn)
			{
				chromeOptions.AddArgument("--headless");
				chromeOptions.AddArgument("--window-size=1920,1080");
			}

			chromeOptions.AddUserProfilePreference("download.default_directory", DataConstants.DownloadDirectory);
			chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
			chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");


			var driver = new ChromeDriver(DataConstants.ChromeDriverDirectory, chromeOptions);

			if (!isHeadlessModeOn)
			{
				driver.Manage().Window.Maximize();
			}

			return driver;
		}
	}
}
