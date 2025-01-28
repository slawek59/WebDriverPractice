using OpenQA.Selenium;
using WebDriverPractice.Helpers;
using Serilog;

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
			Log.Information($"Open {this.GetType().Name} page.");
		}

		public CarrerSearchResultsPage PerfromCarrerSearchOperations(string keys)
        {
			Log.Information($"Click {nameof(_remoteOptionCheckbox)}.");
            Driver.Click(_remoteOptionCheckbox);

			Log.Information($"Send '{keys}' to {nameof(_keywordsInputField)}.");
            Driver.SendKeys(_keywordsInputField, keys);

			Log.Information($"Click {nameof(_locationsDropdown)}.");
            Driver.Click(_locationsDropdown);

			Log.Information($"Click {nameof(_allLocationsOption)}.");
            Driver.Click(_allLocationsOption);

			Log.Information($"Click {nameof(_findButton)}.");
            Driver.Click(_findButton);

            return new CarrerSearchResultsPage(base.Driver);
        }
    }
}
