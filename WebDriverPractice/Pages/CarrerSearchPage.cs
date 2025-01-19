using OpenQA.Selenium;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class CarrerSearchPage : BasePage
    {
        private readonly By _remoteOptionCheckbox = By.XPath("//input[@name='remote']");
        private readonly By _keywordsInputField = By.Id("new_form_job_search-keyword");
        private readonly By _locationsDropdown = By.CssSelector("span.select2-selection__rendered");
        private readonly By _allLocationsOption = By.XPath("//li[contains(text(),'All Locations')]");
        private readonly By _findButton = By.XPath("//form/child::button");

		public CarrerSearchPage(IWebDriver driver) : base(driver)
		{

		}

		public CarrerSearchResultsPage PerfromCarrerSearchOperations(string keys)
        {
            Driver.Click(_remoteOptionCheckbox);
            Driver.SendKeys(_keywordsInputField, keys);
            Driver.Click(_locationsDropdown);
            Driver.Click(_allLocationsOption);
            Driver.Click(_findButton);

            return new CarrerSearchResultsPage(base.Driver);
        }
    }
}
