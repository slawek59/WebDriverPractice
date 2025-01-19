using OpenQA.Selenium;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class CarrerSearchResultsPage : BasePage
	{
		private readonly By _sortLegend = By.XPath("//div[@class='search-result__sorting-menu']");
		private readonly By _sortByDate = By.XPath("//input[@id='sort-time']");
		private readonly By _latestViewAndApplyButton = By.XPath("//ul[@class='search-result__list']/li[1]//a[contains(text(), 'View and apply')]");

		public CarrerSearchResultsPage(IWebDriver driver) : base(driver)
		{

		}

		public JobDetailsPage NavigateToLatestResult()
		{
			Driver.ScrollToElement(_sortLegend);

			var date = Driver.FindElementWithWait(_sortByDate);

			Driver.ClickWithJS(date);
			Driver.Click(_latestViewAndApplyButton);

			return new JobDetailsPage(base.Driver);
		}
	}
}
