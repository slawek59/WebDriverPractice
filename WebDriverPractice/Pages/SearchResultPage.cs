using OpenQA.Selenium;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class SearchResultPage : BasePage
	{
		private readonly By _searchResultContainer = By.XPath("//div[@class='search-results__items']//a");

		public SearchResultPage(IWebDriver driver) : base(driver)
		{

		}

		public bool DoAllLinksContainKeyword(string keyword)
		{
			IList<IWebElement> searchResultsContainer = Driver.FindElementsWithWait(_searchResultContainer);
			_wait.Until(driver => searchResultsContainer.All(element => element.Displayed));

			return searchResultsContainer.All(item => item.Text.Contains(keyword));
		}
	}
}
