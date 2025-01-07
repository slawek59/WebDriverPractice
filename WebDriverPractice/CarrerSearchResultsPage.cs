using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPractice
{
	public class CarrerSearchResultsPage
	{
		private IWebDriver _driver;
		private WebDriverWait _wait;
		private Actions _actions;
		private WebDriverHelper _driverHelper;

		public CarrerSearchResultsPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}
	}
}
