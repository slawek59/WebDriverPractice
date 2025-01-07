using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPractice
{
	public class EpamMainPage
	{
		private const string BaseURL = "https://www.epam.com";
		private readonly IWebDriver _driver;


		public EpamMainPage(IWebDriver driver)
        {
			_driver = driver;
		}

		public void MaximizeWindow() => _driver.Manage().Window.Maximize();
		public void OpenPage() => _driver.Navigate().GoToUrl(BaseURL);
    }
}
