using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
		private readonly WebDriverWait _wait;
		private readonly Actions _actions;

		public EpamMainPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
			_driver = driver;
			_wait = wait;
			_actions = actions;
		}

		public void MaximizeWindow() => _driver.Manage().Window.Maximize();
		public void OpenPage() => _driver.Navigate().GoToUrl(BaseURL);
    }
}
