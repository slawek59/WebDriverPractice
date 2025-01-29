using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using WebDriverPractice.Business;
using WebDriverPractice.Core.Helpers;

namespace WebDriverPractice.Business.Pages
{
	public class CarrerSearchResultsPage : BasePage
	{
		private readonly By _sortLegend = By.XPath("//div[@class='search-result__sorting-menu']");
		private readonly By _sortByDate = By.XPath("//input[@id='sort-time']");
		private readonly By _latestViewAndApplyButton = By.XPath("//ul[@class='search-result__list']/li[1]//a[contains(text(), 'View and apply')]");

		public CarrerSearchResultsPage(IWebDriver driver) : base(driver)
		{
			Log.Information($"Open {GetType().Name} page.");
		}

		public JobDetailsPage NavigateToLatestResult()
		{
			Log.Information($"Scroll to {nameof(_sortLegend)}.");
			Driver.ScrollToElement(_sortLegend);

			var date = Driver.FindElementWithWait(_sortByDate);

			Log.Information($"Click {nameof(date)}.");
			Driver.ClickWithJS(date);

			Log.Information($"Click {nameof(_latestViewAndApplyButton)}.");
			Driver.Click(_latestViewAndApplyButton);

			return new JobDetailsPage(Driver);
		}
	}
}
