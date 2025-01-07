﻿using Newtonsoft.Json.Bson;
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

		private readonly By _cookieAcceptButton = By.Id("onetrust-accept-btn-handler");

		private readonly By _careersButton = By.XPath("//span/a[contains(@class, 'top-navigation__item-link js-op') and @href='/careers']");

		public EpamMainPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
			_driver = driver;
			_wait = wait;
			_actions = actions;
		}

		public void MaximizeWindow() => _driver.Manage().Window.Maximize();
		public void OpenPage() => _driver.Navigate().GoToUrl(BaseURL);

		public void ClickCookieAcceptButton()=> Click(_cookieAcceptButton);
		public void ClickCareersButton() => Click(_careersButton);

		public void Click(By locator)
		{
			var webElement = _wait.Until(driver => driver.FindElement(locator));

			_actions
				.MoveToElement(webElement)
				.Click()
				.Perform();
		}

	}
}
