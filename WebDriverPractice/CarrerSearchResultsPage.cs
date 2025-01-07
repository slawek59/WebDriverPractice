using OpenQA.Selenium;
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
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;

		public CarrerSearchResultsPage(IWebDriver driver, WebDriverWait wait)
        {
			_driver = driver;
			_wait = wait;
		}
    }
}
