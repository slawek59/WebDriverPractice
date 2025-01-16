﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class CarrerSearchPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly Actions _actions;
        private readonly WebDriverHelper _driverHelper;

        private readonly By _remoteOptionCheckbox = By.XPath("//input[@name='remote']");
        private readonly By _keywordsInputField = By.Id("new_form_job_search-keyword");
        private readonly By _locationsDropdown = By.CssSelector("span.select2-selection__rendered");
        private readonly By _allLocationsOption = By.XPath("//li[contains(text(),'All Locations')]");
        private readonly By _findButton = By.XPath("//form/child::button");

        public CarrerSearchPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
        {
            _driver = driver;
            _wait = wait;
            _actions = actions;
            _driverHelper = driverHelper;
        }

        public CarrerSearchResultsPage PerfromCarrerSearchOperations(string keys)
        {
            _driverHelper.Click(_remoteOptionCheckbox);
            _driverHelper.SendKeys(_keywordsInputField, keys);
            _driverHelper.Click(_locationsDropdown);
            _driverHelper.Click(_allLocationsOption);
            _driverHelper.Click(_findButton);

            return new CarrerSearchResultsPage(_driver, _wait, _actions, _driverHelper);
        }
    }
}
