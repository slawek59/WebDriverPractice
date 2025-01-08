using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebDriverPractice
{
	public class CarrerSearchPage
	{
		private IWebDriver _driver;
		private WebDriverWait _wait;
		private Actions _actions;
		private WebDriverHelper _driverHelper;

		private readonly By _remoteOptionCheckbox = By.XPath("//input[@name='remote']");
		private readonly By _keywordsInputField = By.Id("new_form_job_search-keyword");
		private readonly By _locationsDropdown = By.CssSelector("span.select2-selection__rendered");
		private readonly By _allLocationsOption = By.XPath("//li[contains(text(),'All Locations')]");
		private readonly By _findButton = By.XPath("//form/child::button");
		private readonly By _sortLegend = By.XPath("//div[@class='search-result__sorting-menu']");
		private readonly By _sortByDate = By.XPath("//input[@id='sort-time']");
		private readonly By _latestViewAndApplyButton = By.XPath("//ul[@class='search-result__list']/li[1]//a[contains(text(), 'View and apply')]");
		private readonly By _finalContent = By.XPath("//div[@class='section__wrapper']");

		public CarrerSearchPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public bool PerfromCarrerSearchOperations(string keys)
		{
			_driverHelper.Click(_remoteOptionCheckbox);
			_driverHelper.SendKeys(_keywordsInputField, keys);
			_driverHelper.Click(_locationsDropdown);
			_driverHelper.Click(_allLocationsOption);
			_driverHelper.Click(_findButton);

			_actions.ScrollToElement(_driverHelper.FindTheElement(_sortLegend)).Perform();
			//_actions.MoveToElement(_driverHelper.FindTheElement(_sortByDate)).Click().Perform();
			var date = _driverHelper.FindTheElement(_sortByDate);

			((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", date);


			_driverHelper.Click(_latestViewAndApplyButton);

			return _driverHelper.FindTheElement(_finalContent).Text.Contains($"{keys}", StringComparison.OrdinalIgnoreCase);
		}

		//public void ClickRemoteOptionCheckbox() => _driverHelper.Click(_remoteOptionCheckbox);
		//public void SendKeysToKeywordsInputField(string keys) => _driverHelper.SendKeys(_keywordsInputField, keys);
		//public void ClickLocationsDropdownButton() => _driverHelper.Click(_locationsDropdown);
		//public void SelectAllLocationsOption() => _driverHelper.Click(_allLocationsOption);


	}
}
