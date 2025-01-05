using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPractice
{
	public class EpamMainPage
	{
		private readonly IWebDriver driver;


		public EpamMainPage(IWebDriver driver)
        {
			this.driver = driver;
		}
    }
}
