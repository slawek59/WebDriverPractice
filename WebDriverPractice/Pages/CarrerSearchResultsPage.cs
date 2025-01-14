using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class CarrerSearchResultsPage
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;
		private readonly Actions _actions;
		private readonly WebDriverHelper _driverHelper;

		private readonly By _sortLegend = By.XPath("//div[@class='search-result__sorting-menu']");
		private readonly By _sortByDate = By.XPath("//input[@id='sort-time']");
		private readonly By _latestViewAndApplyButton = By.XPath("//ul[@class='search-result__list']/li[1]//a[contains(text(), 'View and apply')]");

		public CarrerSearchResultsPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public JobDetailsPage NavigateToLatestResult()
		{
			_driverHelper.ScrollToElement(_sortLegend);

			var date = _driverHelper.FindElementWithWait(_sortByDate);

			_driverHelper.ClickWithJS(date);
			_driverHelper.Click(_latestViewAndApplyButton);

			return new JobDetailsPage(_driver, _wait, _actions, _driverHelper);
		}
	}
}
