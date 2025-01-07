using OpenQA.Selenium;
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

		public CarrerSearchResultsPage(IWebDriver driver)
        {
			_driver = driver;
		}
    }
}
