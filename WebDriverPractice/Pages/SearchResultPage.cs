﻿using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class SearchResultPage
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;
		private readonly Actions _actions;
		private readonly WebDriverHelper _driverHelper;

		private readonly By _searchResultContainer = By.XPath("//div[@class='search-results__items']//a");

		public SearchResultPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public bool DoAllLinksContainKeyword(string keyword)
		{
			IList<IWebElement> searchResultsContainer = _driverHelper.FindElementsWithWait(_searchResultContainer);
			_wait.Until(driver => searchResultsContainer.All(element => element.Displayed));

			return searchResultsContainer.All(item => item.Text.Contains(keyword));
		}
	}
}
